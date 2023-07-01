using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public Text CoinCountTXT;
    public Text CoinCountTXT_GameOver;
    public Text CoinCountTXT__Lv_Complete;
    int count = 0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinCountTXT.text=count.ToString();
        CoinCountTXT_GameOver.text=count.ToString();
        CoinCountTXT__Lv_Complete.text=count.ToString();
    }
    public void AddCount()
    {
        count++;
    }
}