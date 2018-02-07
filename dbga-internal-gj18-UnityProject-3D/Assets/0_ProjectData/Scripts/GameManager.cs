using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] Vittime;
    public enum State { GIOCO, RESPAWN, INTERMEZZO}

    public State currentState;
    bool isClosed;


	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    void checkState(State newState)
    {

        if(newState == 0 && currentState != State.GIOCO)
        {
            currentState = State.GIOCO;         
        }
        else if (newState == State.INTERMEZZO && currentState != State.INTERMEZZO)
        {
            currentState = State.INTERMEZZO;
        }
        else if (newState == State.RESPAWN && currentState != State.RESPAWN)
        {
            currentState = State.RESPAWN;
        }


    }

}
