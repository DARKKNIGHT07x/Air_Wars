using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public float BulletSpawnTime;
    public GameObject PlayerBullet;
    public GameObject MuzzleFlash;
    public Transform SpawnPoint_R;
    public Transform SpawnPoint_L;
    public AudioSource BulletSound;
    

    // Start is called before the first frame update
    void Start()
    {
        MuzzleFlash.SetActive(false);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
           
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
            BulletSound.Play();
            MuzzleFlash.SetActive(true);
            yield return new WaitForSeconds(0.07f);
            MuzzleFlash.SetActive(false);
        }
    }
}
