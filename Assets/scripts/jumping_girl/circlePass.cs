using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class circlePass : MonoBehaviour {

	GameObject timer;
	GameObject scoreScript;
	// Use this for initialization
	void Start () {
		scoreScript = GameObject.Find ("TextScore");
		timer = GameObject.Find ("Timer");
		this.GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		int qualify = scoreScript.GetComponent<ScoreScript> ().qualify;
		int score = scoreScript.GetComponent<ScoreScript> ().get_score ();
		if (!timer.GetComponent<Timer> ().get_gameRunning ()) {
			if (score >= qualify)
				this.GetComponent<SpriteRenderer>().sprite = Resources.Load("circle-outline-xxl",typeof(Sprite)) as Sprite;
			else
				this.GetComponent<SpriteRenderer>().sprite = Resources.Load("cross",typeof(Sprite)) as Sprite;

			Invoke ("showShape", 6f);
		}
	}

	void showShape() {
		this.GetComponent<SpriteRenderer> ().color = new Color (1,1,1,(float)0.45);
	}
}
