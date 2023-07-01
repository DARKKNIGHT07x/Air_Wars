using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementClamp : MonoBehaviour
{
    public float Speed;
    public float padding = 0.8f;
    public GameObject Explosion;
    public Player_Healthbar PlayerHP;
    public float Health = 20f;
    public CoinCount CoinCountScript;
    float minX;
    float maxX;
    float minY;
    float maxY;
    float BarFillAmount = 1f;
    float Damage = 0;
    public GameObject DamageEffect;
    public GameController gameController;
    public AudioSource audioSource;
    public AudioClip Damage_Sfx;
    public AudioClip Explosion_Sfx;
    public AudioClip Coin_Sfx;

    private bool useGyro; // Flag to enable/disable gyroscopic movement
    public float gyroSensitivity = 0.2f; // Sensitivity of gyroscopic movement

    void Start()
    {
        FindBoundaries();
        Damage = BarFillAmount / Health;

        // Check if gyroscope is available
        useGyro = SystemInfo.supportsGyroscope;
        if (useGyro)
        {
            Input.gyro.enabled = true; // Enable the gyroscopic input
        }
    }

    void FindBoundaries()
    {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    void Update()
    {
        // Handle gyroscopic movement if available, otherwise fallback to regular input
        float deltaX, deltaY;
        if (useGyro)
        {
            // Use gyro input for movement
            deltaX = -Input.gyro.rotationRate.y * gyroSensitivity;
            deltaY = Input.gyro.rotationRate.x * gyroSensitivity;
        }
        else
        {
            // Use regular input for movement
            deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            deltaY = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        }

        float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
        float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);

        transform.position = new Vector2(newXpos, newYpos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(Damage_Sfx, 0.5f);
            DamagePlayerHealthBar();
            Destroy(collision.gameObject);
            GameObject DamageEffx = Instantiate(DamageEffect, collision.transform.position, Quaternion.identity);
            Destroy(DamageEffx, 0.5f);
            if (Health <= 0)
            {
                Destroy(gameObject);
                GameObject Blast = Instantiate(Explosion, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(Explosion_Sfx,Camera.main.transform.position,0.7f);
                Destroy(Blast, 2f);
                gameController.GameOver();
            }
        }

        if (collision.gameObject.tag == "Coin")
        {
            AudioSource.PlayClipAtPoint(Coin_Sfx,Camera.main.transform.position,1f);
            Destroy(collision.gameObject);
            CoinCountScript.AddCount();
        }
    }

    void DamagePlayerHealthBar()
    {
        if (Health > 0)
        {
            Health -= 1;
            BarFillAmount = BarFillAmount - Damage;
            PlayerHP.SetAmmount(BarFillAmount);
        }
    }
}
