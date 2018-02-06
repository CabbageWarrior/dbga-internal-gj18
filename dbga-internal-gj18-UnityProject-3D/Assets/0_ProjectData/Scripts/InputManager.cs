using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
	
	private GameObject victim;
	private GameObject Human;
	private GameObject Human1;

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
					victim = Human;

				} else if (hit.transform.name == "Human1") {
					Debug.Log ("This is a Human1");   
					victim = Human1;

				} else if (hit.transform.name == "Ceppo" && victim != null) {
					Debug.Log ( victim + " sgozzato" );   
					victim = Human1;

				}else {
					
					Debug.Log ("This isn't a Player"); 
				}

			}
		}
	}
}
