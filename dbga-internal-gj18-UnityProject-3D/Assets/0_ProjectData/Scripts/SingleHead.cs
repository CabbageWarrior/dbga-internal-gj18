using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleHead : MonoBehaviour {

    public float timeAlive = 3;
    [Space]
    public GameObject sangueGameObject;

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyMe());
	}

    private IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(this.gameObject);
    }
}
