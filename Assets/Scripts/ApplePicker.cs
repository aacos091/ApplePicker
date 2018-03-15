using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public AppleTree treeScript;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject>();
		for (int i = 0; i < numBaskets; i++) {
			GameObject tBasketGO = Instantiate( basketPrefab ) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + ( basketSpacingY * i );
			tBasketGO.transform.position = pos;
			basketList.Add( tBasketGO );
		}
	}

	public void AppleDestroyed() {
		////Destory all the falling apples
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
		foreach ( GameObject tGO in tAppleArray ) {
			Destroy ( tGO );
		}

		////Destroy one of the Baskets
		//Get the index of the last Basket in basketList
		int basketIndex = basketList.Count - 1;
		//Get a reference ot that Basket GameObject
		GameObject tBasketGO = basketList[basketIndex];
		//Remove the basket from the List destory the GameObject
		basketList.RemoveAt( basketIndex );
		Destroy( tBasketGO );

	}
	
	// Update is called once per frame
	void Update () {
		if ( basketList.Count == 0 ) {
			//Scene manager not working
			Application.LoadLevel("_GameOver");
		}
	}
}
