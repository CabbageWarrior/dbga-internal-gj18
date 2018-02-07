using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondannatoSkin : MonoBehaviour
{
    [Header("Prefabs da spawnare")]
    public GameObject capelliPrefab;
    public GameObject baffiPrefab;

    [Header("Spawn Points delle personalizzazioni")]
    public GameObject capelliSpawnPoint;
    public GameObject baffiSpawnPoint;

    // Use this for initialization
    void Start()
	{
		if (capelliPrefab)
		{
			if (capelliSpawnPoint && capelliSpawnPoint.transform.childCount == 0) 
			{
				capelliSpawnPoint.GetComponent<Renderer> ().enabled = false;

				GameObject dioBubu = Instantiate (capelliPrefab, capelliSpawnPoint.transform.position, new Quaternion(0f, capelliSpawnPoint.transform.rotation.y, 0f, 0f));
				dioBubu.transform.SetParent(capelliSpawnPoint.transform);
			}
		}

		if (baffiPrefab) 
		{
			if (baffiSpawnPoint && baffiSpawnPoint.transform.childCount == 0)
			{
				baffiSpawnPoint.GetComponent<Renderer> ().enabled = false;

				GameObject dioBubu2 = Instantiate (baffiPrefab, baffiSpawnPoint.transform.position, baffiSpawnPoint.transform.rotation);
				dioBubu2.transform.SetParent(baffiSpawnPoint.transform);
			}
		}
	
    }

    // Update is called once per frame
    void Update()
    {

    }
}
