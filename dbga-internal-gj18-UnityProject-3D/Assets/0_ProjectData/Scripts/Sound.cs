﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound : MonoBehaviour {

	public string name;

	public AudioClip clip;
	[Range(0f,1f)]
	public float volume;
	[Range(.1f,3f)]
	public float pitch;

	[HideInInspector]
	public AudioSource source;

	public bool loop;

	void Start () {
		
	}
	
	void Update () {
		
	}
}
