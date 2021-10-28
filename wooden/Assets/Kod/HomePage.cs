using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public string Page_Number;
    public GameObject panel;
    public void Go() 
    {
        SceneManager.LoadScene(Page_Number);
    }
    public void Gameover()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("bolum"));
    }
    public void Pause()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
