﻿using UnityEngine;
using System.Collections;

public class Basket : MonoBehaviour {

	public GUIText		scoreGT;



	
	// Update is called once per frame
	void Update () {

		// get the current screen position of the mouse from Input
		Vector3 mousePos2D = Input.mousePosition; //1

		// the camera's z position sets the how far to push the mouse into #d
		mousePos2D.z = -Camera.main.transform.position.z;  //2

		//convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D); //3

		//move the x postion of this Basket to the x position of the Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	// Use this for initialization
	void Start () {
		//find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find ("ScoreCounter");
		// Get the GUIText component of that GameObject
		scoreGT = scoreGO.GetComponent<GUIText> ();
		//Set the starting number of points to 0
		scoreGT.text = "0";

	}

	void OnCollisionEnter (Collision coll) {
		//find out what hit this basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") {
			Destroy (collidedWith);
		}

		//parse the text of the scoreGT into an int
		int score = int.Parse (scoreGT.text);
		//add points for catching the apple
		score += 100;
		// convert the score back to a string and display it
		scoreGT.text = score.ToString ();

		//track the high score
		if (score > HighScore.score) {
			HighScore.score = score;
		}
	}
}
