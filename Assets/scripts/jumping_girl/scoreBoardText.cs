using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreBoardText : MonoBehaviour {

	GameObject timer;
	GameObject scoreScript;

	// Use this for initialization
	void Start () {
		scoreScript = GameObject.Find ("TextScore");
		timer = GameObject.Find ("Timer");
		this.GetComponent<Text> ().CrossFadeAlpha (0, 0, true);
	}
	
	// Update is called once per frame
	void Update () {
		if (!timer.GetComponent<Timer> ().get_gameRunning ()) {
			Invoke ("showText", 4f);
			Invoke ("countUpScore", 5f);
		}
	}

	void showText() {
		this.GetComponent<Text> ().CrossFadeAlpha (100, 10, true);
	}

	void countUpScore() {
		int qualify = scoreScript.GetComponent<ScoreScript> ().qualify;
		int score = scoreScript.GetComponent<ScoreScript> ().get_score ();
		this.GetComponent<Text>().text = "Qualify     "+qualify+"\nScore       "+score;
	}
}
