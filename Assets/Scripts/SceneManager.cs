using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	public void changeScene (string sceneName) {
		//SceneManager.LoadScene is not working for some reason, have to make do with this	
		Application.LoadLevel(sceneName);
	}

	public void resetScore() {
		//This is just to reset the score once the game starts up again
		HighScore.score = 1000;
	}
}
