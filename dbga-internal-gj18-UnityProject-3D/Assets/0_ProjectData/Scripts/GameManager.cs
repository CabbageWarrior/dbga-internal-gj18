using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class GameManager : MonoBehaviour
{

    public GameObject[] Vittime;
    public enum State { GIOCO, RESPAWN, INTERMEZZO, ENDTURN }

    public State currentState;
    bool isClosed = true;
    Animator palco;
    InputManager inputManager;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public MenuManager MM;
    private Condannati vittima1;
    private Condannati vittima2;
    private int actualTurn = 0;

    

    void Start()
    {
        inputManager = this.GetComponent<InputManager>();
        palco = this.GetComponent<Animator>();
        checkState(State.RESPAWN);
    }




    public void checkState(State newState)
    {

        if (newState == 0 && currentState != State.GIOCO)
        {
            currentState = State.GIOCO;
        }
        else if (newState == State.ENDTURN && currentState != State.ENDTURN)
        {
            currentState = State.ENDTURN;
            actualTurn++;
        }
        else if (newState == State.INTERMEZZO && currentState != State.INTERMEZZO)
        {
            currentState = State.INTERMEZZO;
            if (inputManager.currentKingScore <= 0)
            {
                MM.finalText.text = MM.finali[0];
                MM.finaleBello = false;
                MM.schermataFinale.gameObject.SetActive(true);
            }
            else if (inputManager.currentCrowdScore <= 0)
            {
                MM.finalText.text = MM.finali[1];
                MM.finaleBello = false;
                MM.schermataFinale.gameObject.SetActive(true);

            }
            else if (inputManager.currentKingScore >= 100)
            {
                MM.finalText.text = MM.finali[2];
                MM.finaleBello = false;
                MM.schermataFinale.gameObject.SetActive(true);

            }
            else if (inputManager.currentCrowdScore >= 100)
            {
                MM.finalText.text = MM.finali[3];
                MM.finaleBello = false;
                MM.schermataFinale.gameObject.SetActive(true);

            }
            else if (actualTurn == MM.turniMax && inputManager.currentNobiliUccisi >= inputManager.currentPopolaniUccisi + MM.margineDiVittoria)
            {
                MM.finalText.text = MM.finali[4];
                MM.finaleBello = true;
                MM.schermataFinale.gameObject.SetActive(true);

            }
            else if (actualTurn == MM.turniMax && (inputManager.currentNobiliUccisi < inputManager.currentPopolaniUccisi + MM.margineDiVittoria 
                    && inputManager.currentNobiliUccisi > inputManager.currentPopolaniUccisi - MM.margineDiVittoria))
            {
                MM.finalText.text = MM.finali[5];
                MM.finaleBello = true;
                MM.schermataFinale.gameObject.SetActive(true);

            }
            else if(actualTurn == MM.turniMax && inputManager.currentNobiliUccisi <= inputManager.currentPopolaniUccisi - MM.margineDiVittoria)
            {
                MM.finalText.text = MM.finali[6];
                MM.finaleBello = true;
                MM.schermataFinale.gameObject.SetActive(true);

            }
            moveSipario();
        }
        else if (newState == State.RESPAWN && currentState != State.RESPAWN)
        {
            StartCoroutine(resetPosition());
            currentState = State.RESPAWN;
            StartCoroutine(spawnPuppotto());
        }
    }

    void moveSipario()
    {
		if (!isClosed && !MM.schermataFinale.isActiveAndEnabled)
        {
			Debug.Log ("Close TRUE");

			FindObjectOfType<AudioManager> ().Play ("SiparioClosed");
            isClosed = true;
            palco.SetBool("close", true);
            //checkState(State.RESPAWN);
        }
		else if (isClosed && !MM.schermataFinale.isActiveAndEnabled)
		{
			Debug.Log ("Close FALSE");

			FindObjectOfType<AudioManager> ().Play ("NobiliWaiting");
			FindObjectOfType<AudioManager> ().Play ("SiparioClosed");
            isClosed = false;
            palco.SetBool("close", false);
            // checkState(State.GIOCO);
        }
    }

    IEnumerator spawnPuppotto()
    {
        //vittima1 = Vittime[Random.Range(0, Vittime.Length)].GetComponent<Condannati>();
        do
        {
            int random = Random.Range(0, Vittime.Length);
            vittima1 = Vittime[random].GetComponent<Condannati>();
        }
        while (!vittima1.isAlive);
        if (vittima1 != null)
        {
            vittima1.gameObject.SetActive(true);
            //vittima1.gameObject.GetComponentInChildren<Outline>().enabled = true;
            vittima1.transform.position = spawnPoint1.position;
            inputManager.Condannato1 = vittima1.gameObject;
            //vittima2 = vittima1.possibleMatches[Random.Range(0, vittima1.possibleMatches.Length)].GetComponent<Condannati>();
            do
            {
                int random = Random.Range(0, vittima1.possibleMatches.Length);
                vittima2 = vittima1.possibleMatches[random].GetComponent<Condannati>();
            }
            while (!vittima2.isAlive);

            if (vittima2 != null)
            {
                //vittima2.gameObject.GetComponentInChildren<Outline>().enabled = true;

                vittima2.gameObject.SetActive(true);
                vittima2.transform.position = spawnPoint2.position;
                inputManager.Condannato2 = vittima2.gameObject;
            }
        }

        moveSipario();


        yield return null;
    }

    IEnumerator resetPosition()
    {
        if (vittima1 != null && vittima2 != null)
        {
            vittima1.transform.position = vittima1.defaultTransform;
            vittima2.transform.position = vittima2.defaultTransform;
            vittima1.animator.SetTrigger("Reset");
            vittima2.animator.SetTrigger("Reset");
            vittima2.gameObject.SetActive(false);
            vittima1.gameObject.SetActive(false);
        }

        yield return null;
    }

}
