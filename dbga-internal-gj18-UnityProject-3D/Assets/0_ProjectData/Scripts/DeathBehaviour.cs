﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour : StateMachineBehaviour {
	bool hasSangue = false;
	Condannati myCondannatiComponent;

	 //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		myCondannatiComponent = animator.GetComponentInParent<Condannati> ();
		hasSangue = myCondannatiComponent && myCondannatiComponent.sangue;

		if (hasSangue) {
			myCondannatiComponent.sangue.SetActive (true);
		}

		Transform head = animator.transform.Find ("Sphere001");

		if (head) {
			

			//GameObject newHead = Instantiate (head.gameObject);

			head.gameObject.SetActive (false);


//			//newHead.GetComponent<Renderer> ().enabled = false;
//			Destroy(newHead.GetComponent("SkinnedMeshRenderer"));
//
//				
//			Rigidbody aaa = newHead.gameObject.AddComponent<Rigidbody>();
//			aaa.useGravity = false;
//			aaa.isKinematic = true;
//			aaa.AddForce ((Camera.main.transform.position - newHead.transform.position).normalized * 4, ForceMode.Impulse);
		}
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (hasSangue) {
			myCondannatiComponent.sangue.SetActive (false);
		}
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
