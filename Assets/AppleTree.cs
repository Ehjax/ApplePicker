using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

	// Prefab for instantiating apples
	public GameObject applePrefab;

	//Speed at which the ApppleTree moves in meters/second
	public float speed = 1f;

	//Distance where AppleTree turns around
	public float leftAndRightEdge = 10f;

	//Chance that the AppleTree will change directions
	public float chanceToChangeDirections = 0.1f;

	//Rate at which Apples will be instantiated
	public float secondsBetweenAppleDrops = 1f;


	void Start () {
		//Dropping apples every second
	}
	

	void Update () {
		//Basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		//Changing directions
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs (speed); //move right
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs (speed); //move left
		} 
	}

	void FixedUpdate() {
		//change directions randomly
	if (Random.value < chanceToChangeDirections) {
		speed *= -1; //change directions
	}
}
}
