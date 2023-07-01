using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform Bar;
    // Start is called before the first frame update
    void Start()
    {
        SetSize(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetSize(float Size)
    {
        Bar.localScale = new Vector2 (Size,1f);
    }
}
