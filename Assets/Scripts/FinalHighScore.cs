﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalHighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Text gt = this.GetComponent<Text>();
		gt.text = "Your final high score was: " + HighScore.score;
	}
}
