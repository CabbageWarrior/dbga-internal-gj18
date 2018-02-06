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
        if (capelliSpawnPoint.transform.childCount == 0)
        {
            Instantiate(capelliPrefab, capelliSpawnPoint.transform);
        }
        if (baffiSpawnPoint.transform.childCount == 0)
        {
            Instantiate(baffiPrefab, baffiSpawnPoint.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
