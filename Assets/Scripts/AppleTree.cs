using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {

	// Prefab for instantiating apples
	public GameObject applePrefab;

	//Speed at which the AppleTree moves in meters/second
	public float speed = 20f;

	//Distance where AppleTree turns around
	public float leftAndRightEdge = 20f;

	//Chance that the AppleTree will change direction
	public float chanceToChangeDirections = 0.05f;

	//Rate at which Apples will be instantiated
	public float secondsBetweenAppleDrops = 0.5f;

	//Level of difficulty, for the speed
	public float[] difficultyLevel = {2f, 3f, 5f, 9f, 12f, 14f, 18f, 22f, 27f, 30f};

	//seconds before the next difficulty level
	public float diffSec = 30f;

	// Use this for initialization
	void Start () {
		//Dropping apples every second
		InvokeRepeating( "DropApple", 2f, secondsBetweenAppleDrops);

		//Using coroutines to up the difficulty after a set time
		StartCoroutine(difficultyUp());
	}

	IEnumerator difficultyUp() 
	{
		//Using the difficultyLevel array, this for loop will increase the tree speed 
		//to the amount in the index than wait for the scheduled time until the next change
		for (int i = 0; i < 10; i++) 
		{
			Debug.Log("Increasing difficulty");
			speed = difficultyLevel[i];
			yield return new WaitForSeconds(diffSec);
		}	
	}

	void DropApple () {
		GameObject apple = Instantiate( applePrefab ) as GameObject;
		apple.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		//Changing direction
		if ( pos.x < -leftAndRightEdge ) {
			speed = Mathf.Abs(speed); //Move Right
		} else if ( pos.x > leftAndRightEdge ) {
			speed = -Mathf.Abs(speed); //Move left
		}
	}

	void FixedUpdate () {
		//Changing direction randomly
		if ( Random.value < chanceToChangeDirections ) {
			speed *= -1; //Change direction
		}
	}
}
