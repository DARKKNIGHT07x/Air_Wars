using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject GameOver_Panel;
    public GameObject LevelComplete_Panel;
    public GameObject GameComplete_Txt;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        GameComplete_Txt.SetActive(false);
        LevelComplete_Panel.SetActive(false);
        PauseMenu.SetActive(false);
        GameOver_Panel.SetActive(false);
        PauseButton.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseButton.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        GameOver_Panel.SetActive(true);
        Time.timeScale = 0.01f;
        PauseButton.SetActive(false);
    }
    public IEnumerator LevelCompletePanel()
    {
        yield return new WaitForSeconds(2f);
        GameComplete_Txt.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        LevelComplete_Panel.SetActive(true);
    }  
}