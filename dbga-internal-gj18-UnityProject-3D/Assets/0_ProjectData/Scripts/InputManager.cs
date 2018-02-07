using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManager : MonoBehaviour
{

    private GameObject victim;
    private GameObject selected;
    private GameObject survivor;

    private GameObject Condannato1;
    private GameObject Condannato2;

    private Condannati condannati;

    private Image crowdScore;
    private Image kingScore;
    private Text descriptionText;
    private Text nobiliUccisi;
    private Text popolaniUccisi;
	private Text nome;
	private Text crimine;
	private Text circostanza;
   

    private float currentCrowdScore = 0;
    private float currentKingScore = 0;
    private int currentNobiliUccisi = 0;
    private int currentPopolaniUccisi = 0;
    private int currentSpecialiUccisi = 0;

    private Animator myAnimator;

    void Start()
    {
        Condannato1 = GameObject.Find("Vittima");
        Condannato2 = GameObject.Find("Vittima1");
        crowdScore = GameObject.Find("PunteggioAttualePopolo").GetComponent<Image>();
        kingScore = GameObject.Find("PunteggioAttualeRe").GetComponent<Image>();
        descriptionText = GameObject.Find("Description").GetComponent<Text>();
        nobiliUccisi = GameObject.Find("Nobili").GetComponent<Text>();
        popolaniUccisi = GameObject.Find("Popolani").GetComponent<Text>();
		nome = GameObject.Find ("Nome").GetComponent<Text> ();
		crimine = GameObject.Find ("Crimine").GetComponent<Text> ();
		circostanza = GameObject.Find ("Circostanza").GetComponent<Text> ();


    }

    void Update()
    {

        crowdScore.rectTransform.sizeDelta = new Vector2(40, currentCrowdScore * 2);
        kingScore.rectTransform.sizeDelta = new Vector2(40, currentKingScore * 2);
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.GetComponent<Condannati>())
                {

                    if (hit.transform.gameObject == Condannato1)
                    {

                        Debug.Log("This is a Human1");
                        selected = Condannato1;
						Debug.Log (selected.name);
                        survivor = Condannato2;
                        descriptionText.text = selected.GetComponent<Condannati>().description;
						nome.text = Condannato1.GetComponent<Condannati> ().Nome;
						crimine.text = Condannato1.GetComponent<Condannati> ().crimine;
						circostanza.text = Condannato1.GetComponent<Condannati> ().circostanza;

                    }
                    else
                    {

                        Debug.Log("This is a Human");
                        selected = Condannato2;
						Debug.Log (selected.name);
                        survivor = Condannato1;
                        descriptionText.text = selected.GetComponent<Condannati>().description;
						nome.text = Condannato2.GetComponent<Condannati> ().Nome;
						crimine.text = Condannato2.GetComponent<Condannati> ().crimine;
						circostanza.text = Condannato2.GetComponent<Condannati> ().circostanza;
                    }

                }
                else if (hit.transform.name == "Ceppo" && selected != null)
                {
					survivor.GetComponent<Condannati> ().Survive ();
					
					victim = selected;

					Condannati victimCondamnedData = victim.GetComponent<Condannati> ();

					victimCondamnedData.PrepareToDie ();

					currentCrowdScore += victimCondamnedData.crowdScoreMod;
					currentKingScore += victimCondamnedData.kingScoreMod;

                    selected = null;
                    descriptionText.text = "";

					if (victimCondamnedData.rank == Condannati.Rank.NOBILE)
                    {
                        currentNobiliUccisi += 1;
                        nobiliUccisi.text = "Nobili : " + (currentNobiliUccisi);
                    }
					else if (victimCondamnedData.rank == Condannati.Rank.POPOLANO)
                    {
                        currentPopolaniUccisi += 1;
                        popolaniUccisi.text = "Popolani : " + (currentPopolaniUccisi);
                    }
                    
                }

                else
                {

                    selected = null;
                    survivor = null;
                    Debug.Log("This isn't a Player");
                    descriptionText.text = "";
					nome.text = "";
					crimine.text = "";
					circostanza.text = "";
                }

            }

        }

    }
}
