using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Healthbar : MonoBehaviour
{
    public Image Bar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void SetAmmount (float ammount)
     {
        Bar.fillAmount = ammount;
     }
}
