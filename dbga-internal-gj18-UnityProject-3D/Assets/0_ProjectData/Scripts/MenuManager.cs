using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public bool finaleBello = false;
    public Canvas schermataFinale;
    bool paused = false;

    public string[] finali;

    public Text finalText;
    public int margineDiVittoria;
    public int turniMax;
    

    public void Pause()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
        }
        else if (paused)
        {
            paused = false;
            Time.timeScale = 1;
        }
    }


    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }



}
