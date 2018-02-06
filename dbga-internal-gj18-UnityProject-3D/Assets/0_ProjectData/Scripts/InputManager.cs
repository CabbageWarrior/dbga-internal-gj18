using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManager : MonoBehaviour {
	
	public GameObject victim;
	public GameObject selected;

	private GameObject Human;
	private GameObject Human1;

	private Condannati condannati;

	public Text crowdScore;
	public Text kingScore;
	public Text descriptionText;
	public Text nobiliUccisi;
	public Text popolaniUccisi;

	private float currentCrowdScore = 0;
	private float currentKingScore = 0;
	private int currentNobiliUccisi = 0;
	private int currentPopolaniUccisi = 0;

	void Start()
	{
		Human = GameObject.Find ("Condannato1");
		Human1 = GameObject.Find ("Condannato2");

	}

	void Update(){
		
		if (Input.GetMouseButtonDown (0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (ray, out hit))
			{
				if (hit.transform.name == "Condannato1") {
					
					Debug.Log ("This is a Human");
					selected = Human;
					descriptionText.text = selected.GetComponent<Condannati> ().description;

				} else if (hit.transform.name == "Condannato2") {
					
					Debug.Log ("This is a Human1");   
					selected = Human1;
					descriptionText.text  = selected.GetComponent<Condannati> ().description;

				} else if (hit.transform.name == "Ceppo" && selected != null) {
					
					victim = selected;
					Debug.Log ( victim + " sgozzato" );

					currentCrowdScore += victim.GetComponent<Condannati> ().crowdScoreMod;
					currentKingScore += victim.GetComponent<Condannati> ().kingScoreMod;

					crowdScore.text = "Punteggio Popolo : " + currentCrowdScore;
					kingScore.text = "Punteggio Re : "  + currentKingScore;
					selected = null;
					descriptionText.text = ""; 

					if (victim.GetComponent<Condannati> ().name == "Popolano") {
						currentPopolaniUccisi += 1;
						popolaniUccisi.text = "Popolani uccisi : " + (currentPopolaniUccisi);
					} else if(victim.GetComponent<Condannati> ().name == "Nobile") {
						currentNobiliUccisi += 1;
						nobiliUccisi.text = "Nobili uccisi : " + (currentNobiliUccisi);
					}
						

				}else {
					
					selected = null;
					Debug.Log ("This isn't a Player"); 
					descriptionText.text = "";
				}

			}
		}
	}
}
