﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class racketLeftPlayer_SinglePlayerLeap : MonoBehaviour {

	Controller controller;


	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update ()
	{
		controller = new Controller ();


		Frame current = controller.Frame ();
		Frame previous = controller.Frame (1);

		HandList hands = current.Hands;
		Hand firstHand = current.Hands.Leftmost;
		Vector handCenter = firstHand.PalmPosition;

		float TheLeapY = (float)(handCenter.y-100);
		float TheVecY = (float)((TheLeapY/19.333333333)-7.5);

		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		Vector linearMovement = current.Translation (previous);

		if ((handCenter.x<0)&&(TheVecY<7.5)&&(TheVecY>-7.5)){
			

			Debug.Log ("The Y value is:" + linearMovement.y);
			transform.position = new Vector3 (TheVecY, 0.0f, transform.position.z);
			Debug.Log ("The Hand Position is:" + handCenter);


	}
}
}