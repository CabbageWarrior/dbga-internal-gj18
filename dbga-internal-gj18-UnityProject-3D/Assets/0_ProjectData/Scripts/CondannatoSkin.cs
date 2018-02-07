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
			if (capelliSpawnPoint)
			{
				capelliSpawnPoint.GetComponent<Renderer> ().enabled = false;

				if (capelliSpawnPoint.transform.childCount == 0)
				{
					//GameObject dioBubu = Instantiate (capelliPrefab, capelliSpawnPoint.transform.position, new Quaternion(0f, capelliSpawnPoint.transform.rotation.y, 0f, 0f));
					//dioBubu.transform.SetParent(capelliSpawnPoint.transform);
				}
			}
		}

		if (baffiPrefab) 
		{
			if (baffiSpawnPoint)
			{
				baffiSpawnPoint.GetComponent<Renderer> ().enabled = false;

				if (baffiSpawnPoint.transform.childCount == 0)
				{
					//GameObject dioBubu2 = Instantiate (baffiPrefab, baffiSpawnPoint.transform.position, baffiSpawnPoint.transform.rotation);
					//dioBubu2.transform.SetParent(baffiSpawnPoint.transform);
				}
			}
		}
    }
}
