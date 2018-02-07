using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Condannati vittima1;
    private Condannati vittima2;

    private void Awake()
    {
        Application.targetFrameRate = -1;
    }

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
        }
        else if (newState == State.INTERMEZZO && currentState != State.INTERMEZZO)
        {
            currentState = State.INTERMEZZO;
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
        if (!isClosed)
        {
            isClosed = true;
            palco.SetBool("close", true);
            //checkState(State.RESPAWN);
        }
        else if (isClosed)
        {
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
