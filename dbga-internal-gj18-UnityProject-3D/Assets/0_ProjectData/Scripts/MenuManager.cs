using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    bool paused = false;

   public void Pause()
   {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
        }
        else if (paused)
        {
            paused =  false;
            Time.timeScale = 1;
        }
   }


    public void NewGame()
	{
		SceneManager.LoadScene (1);
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
