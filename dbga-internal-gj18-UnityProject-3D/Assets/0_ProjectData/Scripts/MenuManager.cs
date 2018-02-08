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
	bool triggered = false;

    public string[] finali;

    public Text finalText;
    public int margineDiVittoria;
    public int turniMax;
    

    public void Pause()
    {
		
        if (!paused)
        {
			FindObjectOfType < AudioManager> ().Stop ("MainTheme");
			FindObjectOfType<AudioManager> ().Play ("NobiliWaiting");
            paused = true;
            Time.timeScale = 0;
        }
        else if (paused)
        {
			FindObjectOfType < AudioManager> ().Play ("MainTheme");

            paused = false;
            Time.timeScale = 1;
        }
    }


    public void NewGame()
    {
		Time.timeScale = 1;
        SceneManager.LoadScene(1);
		FindObjectOfType<AudioManager> ().Stop ("Victory");
		FindObjectOfType<AudioManager> ().Stop ("GameOver");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
		
        SceneManager.LoadScene(0);
		FindObjectOfType<AudioManager> ().Stop ("Victory");
		FindObjectOfType<AudioManager> ().Stop ("GameOver");
    }

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    void Update(){
		
		if (finaleBello && !triggered ) {
			triggered = true;
			FindObjectOfType < AudioManager> ().Stop ("MainTheme");
			FindObjectOfType<AudioManager> ().Play ("Victory");
		}
		if (!finaleBello && triggered) {
			triggered = true;
			FindObjectOfType < AudioManager> ().Stop ("MainTheme");
			FindObjectOfType < AudioManager> ().Play ("GameOver");
		}
	}

}
