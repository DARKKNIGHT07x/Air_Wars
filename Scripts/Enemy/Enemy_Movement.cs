using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed; 
    
    
    void Start()
    {
        
    }


    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*Speed*Time.deltaTime);
    }
}