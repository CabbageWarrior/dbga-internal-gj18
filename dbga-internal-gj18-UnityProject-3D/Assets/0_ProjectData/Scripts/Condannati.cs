﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condannati : MonoBehaviour
{ 
    public enum Rank { NOBILE, POPOLANO }

	public float crowdScoreMod = 20;
	public float kingScoreMod = -10;

    public Rank rank;

	public string name;
	[TextArea(1,5)]
	public string description;
    


	void Start () {
		
	}

	void Update () {
		
	}
		
}
