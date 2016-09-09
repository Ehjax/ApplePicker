using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

	public GameObject		basketPrefab;
	public int		 		numBaskets = 3;
	public float			basketBottomY = -14f;
	public float			basketSpacingY = 2f;
	public List<GameObject>	basketList;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject> ();
		for (int i=0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate (basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add(tBasketGO);
		}
	}
	public void AppleDestroyed() {
		//destroy all of the falling apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag ("Apple");
		foreach (GameObject tGo in tAppleArray) {
			Destroy (tGo);
		}
		//Destroy one of the baskets
		//Get the index of the last Basket in basketList
		int basketIndex = basketList.Count - 1;
		//get a reference to that Basket GameObject
		GameObject tBasketGo = basketList [basketIndex];
		//Remove the basket from the list and destroy the GameObject
		basketList.RemoveAt (basketIndex);
		Destroy (tBasketGo);

	}



	// Update is called once per frame
	void Update () {
	
	}
}
