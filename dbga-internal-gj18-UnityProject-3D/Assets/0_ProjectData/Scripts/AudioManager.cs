using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public Sound[] sounds;

	public static AudioManager instance;

	void Awake () {



		if (instance == null) {
			instance = this;
		} 
		else 
		{
			Destroy (gameObject);
			return;
		
		}
				
		DontDestroyOnLoad (gameObject);

		sounds = new Sound[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
		
			sounds[i] = transform.GetChild (i).GetComponent<Sound>();
		}

		foreach (Sound s in sounds) {

			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;

		}
	}

	void Start(){

		Scene currentScene = SceneManager.GetActiveScene ();

		string sceneName = currentScene.name;
			
		if (sceneName == "Menu") {
			
			Play ("MenuTheme");
				
		} else if (sceneName == "Main") {
		
			Play ("MainTheme");
		}

		 else if (sceneName == "GameOver") {

			Play ("GameOver");
		}

		else if (sceneName == "Victory") {

			Play ("Victory");
		}

	}

	
		public void Play(string name){

		Sound s = Array.Find (sounds, sound => sound.name == name);
		s.source.Play ();

		}
}
