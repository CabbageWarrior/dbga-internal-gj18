﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Condannati : MonoBehaviour
{
    float tempoDiAttesaMorte = 1.7f;
    public bool enableSangue = true;

    [Space]
    public GameObject sangue;
    public GameObject singleHeadPrefab;

    public enum Rank { NOBILE, POPOLANO }

    [Header("Scores")]
    public float crowdScoreMod = 20;
    public float kingScoreMod = -10;

    [Header("Character")]
    public Rank rank;
    public string Nome;

    public string crimine;
    public string circostanza;

    [TextArea(1, 5)]
    public string description;

    [Space(10)]
    [Header("Possible Matches")]
    public GameObject[] possibleMatches;

    [HideInInspector] public Vector3 defaultTransform;

    [Header("Positions")]
    public GameObject deathPosition;
    public float walkSpeed = .5f;
    public float proximityTolerance = .1f;
    public float rotationMaxTime = .15f;
    GameManager GM;
    // Private data
    public bool isAlive = true;
    [HideInInspector] public Animator animator;
    //GameObject singleHeadInstance;

    private void Awake()
    {
        defaultTransform = transform.position;

        //if (singleHeadPrefab)
        //{
        //    OcchiEPelame thisOcchiEPelame = GetComponentInChildren<OcchiEPelame>();

        //    singleHeadInstance = Instantiate(singleHeadPrefab, thisOcchiEPelame.transform.parent);
        //    GameObject newPelameVario = Instantiate(thisOcchiEPelame.gameObject, singleHeadInstance.transform);

        //    //singleHeadInstance.SetActive(false);
        //}
    }

    void Start()
    {
        GM = FindObjectOfType<GameManager>();

        animator = GetComponentInChildren<Animator>();

    }

    // Public Methods
    public void Select()
    {
        //Debug.Log("\"" + name + "\" Selected...");
    }
    public void Unselect()
    {
        //Debug.Log("\"" + name + "\" Unselected...");
    }

    public void Survive()
    {
        //Debug.Log("\"" + name + "\" survived.");
        animator.SetTrigger("Sopravvissuto");
    }
    public void PrepareToDie()
    {
        // Debug.Log("\"" + name + "\" sas to die.");
        StartCoroutine(PrepareToDie_Coroutine());
    }

    IEnumerator PrepareToDie_Coroutine()
    {
        animator.SetTrigger("Morente");
        yield return null;

        transform.DOLookAt(deathPosition.transform.position, rotationMaxTime, AxisConstraint.Y);
        yield return new WaitForSeconds(rotationMaxTime);

        while (Mathf.Abs((transform.position - deathPosition.transform.position).sqrMagnitude) > proximityTolerance * proximityTolerance)
        {
            //Debug.Log (Mathf.Abs ((transform.position - deathPosition.transform.position).sqrMagnitude));
            transform.position += (deathPosition.transform.position - transform.position).normalized * walkSpeed * Time.deltaTime;
            yield return null;
        }

        transform.DOLookAt(deathPosition.transform.parent.position, rotationMaxTime, AxisConstraint.Y);
        yield return new WaitForSeconds(rotationMaxTime);

        animator.SetTrigger("Posizionato");
        yield return new WaitForSeconds(tempoDiAttesaMorte);
        animator.SetTrigger("Morto");

        yield return new WaitForSeconds(2);
        GM.checkState(GameManager.State.INTERMEZZO);
        //yield return new WaitForSeconds(0.5f);
        //transform.position = defaultTransform;
        isAlive = false;

    }

    public void ShotTesta()
    {
        GetComponent<Rigidbody>().AddForce((Camera.main.transform.position - transform.position).normalized * 4, ForceMode.Impulse);
    }
}
