﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using cakeslice;

public class InputManager : MonoBehaviour
{
    private Vector2 piccola = new Vector2(50, 50);
    private Vector2 media = new Vector2(100, 100);
    private Vector2 grande = new Vector2(150, 150);

    private Image kingSphere;
    private Image crowdSphere;

    private GameObject victim;
    private GameObject selected;
    private GameObject survivor;

    public GameObject Condannato1;
    public GameObject Condannato2;

    private Condannati condannati;

    private Image crowdScore;
   // private cakeslice.Outline ceppo;

    private Image kingScore;
    private Text descriptionText;
    private Text nobiliUccisi;
    private Text popolaniUccisi;
    private Text nome;
    private Text crimine;
    private Text circostanza;
    public GameObject mypanel;

    GameManager GM;
    public float currentCrowdScore = 50;
    public float currentKingScore = 50;
    public int currentNobiliUccisi = 0;
    public int currentPopolaniUccisi = 0;

    private Animator myAnimator;

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("NobiliWaiting");
        //Condannato1 = GameObject.Find("Vittima");
        //Condannato2 = GameObject.Find("Vittima1");
        GM = FindObjectOfType<GameManager>();
        crowdScore = GameObject.Find("PunteggioAttualePopolo").GetComponent<Image>();
        kingScore = GameObject.Find("PunteggioAttualeRe").GetComponent<Image>();
        descriptionText = GameObject.Find("Description").GetComponent<Text>();
        nobiliUccisi = GameObject.Find("Nobili").GetComponent<Text>();
        popolaniUccisi = GameObject.Find("Popolani").GetComponent<Text>();
        nome = GameObject.Find("Nome").GetComponent<Text>();
        crimine = GameObject.Find("Crimine").GetComponent<Text>();
        circostanza = GameObject.Find("Circostanza").GetComponent<Text>();
        crowdSphere = GameObject.Find("CrowdCircle").GetComponent<Image>();
        kingSphere = GameObject.Find("KingCircle").GetComponent<Image>();
        mypanel = GameObject.Find("Panel");
        mypanel.SetActive(false);
        //ceppo = GetComponentInChildren<cakeslice.Outline>();
        //ceppo.enabled = false;
    }

    void Update()
    {
        if (selected != null)
        {
            //ceppo.enabled = true;
            //selected.GetComponentInChildren<Outline>().enabled = false;

            mypanel.SetActive(true);
        }
        else
        {
            //ceppo.enabled = false;
        }


        crowdScore.rectTransform.sizeDelta = new Vector2(40, currentCrowdScore * 2);
        kingScore.rectTransform.sizeDelta = new Vector2(40, currentKingScore * 2);

        if (Input.GetMouseButtonDown(0) && GM.currentState == GameManager.State.GIOCO)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.GetComponent<Condannati>())
                {

                    if (hit.transform.gameObject == Condannato1)
                    {

                        //Debug.Log("This is a Human1");
                        selected = Condannato1;
                        //Debug.Log(selected.name);
                        survivor = Condannato2;
                        descriptionText.text = selected.GetComponent<Condannati>().description;
                        nome.text = Condannato1.GetComponent<Condannati>().Nome;
                        crimine.text = Condannato1.GetComponent<Condannati>().crimine;
                        circostanza.text = Condannato1.GetComponent<Condannati>().circostanza;


                    }
                    else
                    {
                        mypanel.SetActive(true);
                        //Debug.Log("This is a Human");
                        selected = Condannato2;
                        //Debug.Log(selected.name);
                        survivor = Condannato1;
                        descriptionText.text = selected.GetComponent<Condannati>().description;
                        nome.text = Condannato2.GetComponent<Condannati>().Nome;
                        crimine.text = Condannato2.GetComponent<Condannati>().crimine;
                        circostanza.text = Condannato2.GetComponent<Condannati>().circostanza;
                    }

                    if (Mathf.Abs(selected.GetComponent<Condannati>().crowdScoreMod) < 6)
                    {

                        crowdSphere.rectTransform.sizeDelta = piccola;
                    }

                    if (5 < (int)Mathf.Abs(selected.GetComponent<Condannati>().crowdScoreMod) && (int)Mathf.Abs(selected.GetComponent<Condannati>().crowdScoreMod) < 11)
                    {

                        crowdSphere.rectTransform.sizeDelta = media;
                    }
                    if (10 < (int)Mathf.Abs(selected.GetComponent<Condannati>().crowdScoreMod) && (int)Mathf.Abs(selected.GetComponent<Condannati>().crowdScoreMod) < 16)
                    {

                        crowdSphere.rectTransform.sizeDelta = grande;
                    }

                    if ((int)Mathf.Abs(selected.GetComponent<Condannati>().kingScoreMod) < 6)
                    {

                        kingSphere.rectTransform.sizeDelta = piccola;
                    }

                    if (5 < (int)Mathf.Abs(selected.GetComponent<Condannati>().kingScoreMod) && (int)Mathf.Abs(selected.GetComponent<Condannati>().kingScoreMod) < 11)
                    {

                        kingSphere.rectTransform.sizeDelta = media;
                    }
                    if (10 < (int)Mathf.Abs(selected.GetComponent<Condannati>().kingScoreMod) && (int)Mathf.Abs(selected.GetComponent<Condannati>().kingScoreMod) < 16)
                    {

                        kingSphere.rectTransform.sizeDelta = grande;
                    }
                }

                else if (hit.transform.name == "Ceppo" && selected != null)

                {
                    if (selected.GetComponent<Condannati>().kingScoreMod > selected.GetComponent<Condannati>().crowdScoreMod)
                    {

                        FindObjectOfType<AudioManager>().Play("NobiliSoddisfatti");

                    }
                    else
                    {

                        FindObjectOfType<AudioManager>().Play("FollaSoddisfatta");
                    }


                    FindObjectOfType<AudioManager>().Stop("NobiliWaiting");
                    FindObjectOfType<AudioManager>().Play("BarFill");

                    GM.checkState(GameManager.State.ENDTURN);
                    survivor.GetComponent<Condannati>().Survive();

                    victim = selected;

                    Condannati victimCondamnedData = victim.GetComponent<Condannati>();

                    victimCondamnedData.PrepareToDie();

                    currentCrowdScore += victimCondamnedData.crowdScoreMod;
                    currentKingScore += victimCondamnedData.kingScoreMod;

                    selected = null;
                    mypanel.SetActive(false);
                    //descriptionText.text = "";

                    if (victimCondamnedData.rank == Condannati.Rank.NOBILE)
                    {
                        currentNobiliUccisi += 1;
                        nobiliUccisi.text = (currentNobiliUccisi) + " :";
                    }
                    else if (victimCondamnedData.rank == Condannati.Rank.POPOLANO)
                    {
                        currentPopolaniUccisi += 1;
                        popolaniUccisi.text = ": " + (currentPopolaniUccisi);
                    }

                }

                else
                {

                    selected = null;
                    survivor = null;
                    //Debug.Log("This isn't a Player");
                    // descriptionText.text = "";
                    //nome.text = "";
                    //crimine.text = "";
                    //circostanza.text = "";
                    mypanel.SetActive(false);
                    kingSphere.rectTransform.sizeDelta = new Vector2(0, 0);
                    crowdSphere.rectTransform.sizeDelta = new Vector2(0, 0);
                }

            }

        }

    }
}
