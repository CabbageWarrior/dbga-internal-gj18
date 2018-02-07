using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] Vittime;
    public enum State { GIOCO, RESPAWN, INTERMEZZO }

    public State currentState;
    bool isClosed;
    public Animator palco;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    void Start()
    {
        currentState = 0;
    }


    public void checkState(State newState)
    {

        if (newState == 0 && currentState != State.GIOCO)
        {
            currentState = State.GIOCO;
        }
        else if (newState == State.INTERMEZZO && currentState != State.INTERMEZZO)
        {
            currentState = State.INTERMEZZO;
            moveSipario();
        }
        else if (newState == State.RESPAWN && currentState != State.RESPAWN)
        {
            currentState = State.RESPAWN;
            moveSipario();
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

}
