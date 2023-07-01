using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    public float BulletSpawnTime;
    public GameObject PlayerBullet;
    public GameObject MuzzleFlash;
    public GameObject Explosion;
    public Transform SpawnPoint_R;
    public Transform SpawnPoint_L;
    public HealthBar healthBar;   
    public GameObject DamageEffect; 
    public float Health = 10f;
    public GameObject Coin;
    public float DamageOnPlayer;
    public AudioSource audioSource;
    public AudioClip Damage_Sfx;
    public AudioClip Bullet_Sfx;
    public AudioClip Explosion_Sfx;
    


    float BarSize = 1f;
    float Damage = 0f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        MuzzleFlash.SetActive(false);
        StartCoroutine(Shoot());
        Damage = BarSize/Health;
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag=="PlayerBullet")
        {
            audioSource.PlayOneShot(Damage_Sfx);
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject DamageEffx = Instantiate(DamageEffect,collision.transform.position,Quaternion.identity);
            Destroy(DamageEffx,0.1f);
            if (Health <= 0)
            {
                AudioSource.PlayClipAtPoint(Explosion_Sfx,Camera.main.transform.position,0.5f);
                Instantiate(Coin,transform.position,Quaternion.identity);
                Destroy(gameObject);
                GameObject EnemyExplosion = Instantiate(Explosion,transform.position,Quaternion.identity);
                Destroy(EnemyExplosion,0.4f);

            }
            
        }
    }

    void DamageHealthBar()
    {
        if (Health > 0)
        {
            
            Health -= DamageOnPlayer;
            BarSize = BarSize - Damage;
            healthBar.SetSize(BarSize);
        }
    }
    void Fire()
    {
            Instantiate(PlayerBullet,SpawnPoint_R.position,Quaternion.identity);            
            Instantiate(PlayerBullet,SpawnPoint_L.position,Quaternion.identity);
            
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(BulletSpawnTime);
            Fire();
            audioSource.PlayOneShot(Bullet_Sfx,0.5f);
            MuzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.07f);
            MuzzleFlash.SetActive(false);
        }
    }
}
