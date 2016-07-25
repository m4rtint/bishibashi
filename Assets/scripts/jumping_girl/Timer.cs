using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	
	float timeLeft = 15.0f;

	bool gameRunning = true;

	void Update()
	{
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
		} else {
			timeLeft = 0;
			set_false_gameRunning ();
			GameObject.Find("scoreboard_final").GetComponent<scoreboard_script>().set_finish_game(1,2);
			this.GetComponent<Text> ().CrossFadeAlpha (0,0,true);
		}
		this.GetComponent<Text> ().text = string.Format ("{0:0.00}", Mathf.Round (timeLeft * 100.0f) / 100.0f);
	}

	public bool get_gameRunning() {
		return gameRunning;
	}

	void set_false_gameRunning() {
		gameRunning = false;
	}
}
