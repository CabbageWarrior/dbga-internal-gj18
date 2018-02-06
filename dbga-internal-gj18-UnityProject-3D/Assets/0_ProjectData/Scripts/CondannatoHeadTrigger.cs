using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondannatoHeadTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Cube") {
			GetComponent<Rigidbody> ().AddForce ((Camera.main.transform.position - transform.position).normalized * 4, ForceMode.Impulse);
		}
	}
}
