using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level_loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lv1()
    {
        SceneManager.LoadScene("Level 1");        
    }
    public void Lv2()
    {
        SceneManager.LoadScene("Level 2");        
    }
    public void Lv3()
    {
        SceneManager.LoadScene("Level 3");        
    }
    public void Lv4()
    {
        SceneManager.LoadScene("Level 4");        
    }
    public void Lv5()
    {
        SceneManager.LoadScene("Level 5");        
    }
    public void Lv6()
    {
        SceneManager.LoadScene("Level 6");        
    }
    public void Lv7()
    {
        SceneManager.LoadScene("Level 7");        
    }public void ReloadLv1()
    {
        SceneManager.LoadScene("Level 1");        
    }
    public void ReloadLv2()
    {
        SceneManager.LoadScene("Level 2");        
    }
    public void ReloadLv3()
    {
        SceneManager.LoadScene("Level 3");        
    }
    public void ReloadLv4()
    {
        SceneManager.LoadScene("Level 4");        
    }
    public void ReloadLv5()
    {
        SceneManager.LoadScene("Level 5");        
    }
    public void ReloadLv6()
    {
        SceneManager.LoadScene("Level 6");        
    }
    public void ReloadLv7()
    {
        SceneManager.LoadScene("Level 7");        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
