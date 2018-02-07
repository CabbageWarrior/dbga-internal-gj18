using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condannati : MonoBehaviour
{ 
    public enum Rank { NOBILE, POPOLANO }

	public float crowdScoreMod = 20;
	public float kingScoreMod = -10;

    public Rank rank;
    bool isAlive = true;
	public string Nome;

    public string crimine;
    public string circostanza;

	[TextArea(1,5)]
	public string description;
    

    public GameObject[] possibleMatches;


	void Start () {
		
	}

	void Update () {
		
	}
		
}
