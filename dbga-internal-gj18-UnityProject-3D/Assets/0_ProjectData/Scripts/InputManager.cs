using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {
	
	public GameObject victim;
	public GameObject selected;

	private GameObject Human;
	private GameObject Human1;

	public Condannati condannati;

	public Text crowdScore;
	public Text kingScore;

	private float currentCrowdScore = 0;
	private float currentKingScore = 0; 

	void Start()
	{
		Human = GameObject.Find ("Human");
		Human1 = GameObject.Find ("Human1");

	}

	void Update(){
		
		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit))
			{
				if (hit.transform.name == "Human") {
					Debug.Log ("This is a Human");
					selected = Human;

				} else if (hit.transform.name == "Human1") {
					Debug.Log ("This is a Human1");   
					selected = Human1;

				} else if (hit.transform.name == "Ceppo" && selected != null) {
					
					victim = selected;
					Debug.Log ( victim + " sgozzato" );

					currentCrowdScore += victim.GetComponent<Condannati> ().crowdScoreMod;
					currentKingScore += victim.GetComponent<Condannati> ().kingScoreMod;

					crowdScore.text = "Punteggio Popolo : " + currentCrowdScore;
					kingScore.text = "Punteggio Re : "  + currentKingScore;

				}else {
					
					Debug.Log ("This isn't a Player"); 
				}

			}
		}
	}
}
