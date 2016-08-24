using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Timer of the game
 * 
 * */
public class Timer : MonoBehaviour {

	//Starting Time
	float timeLeft = 15.0f;

	//If the game is running or not
	bool gameRunning = true;


	void Update()
	{
		//If there is time left, let it run down
		if (timeLeft > 0) {
			timeLeft -= Time.deltaTime;
		} else {
			//Grab the final score for the two players
			int score = GameObject.Find ("TextScore").GetComponent<ScoreScript> ().get_score ();
			int score_g = GameObject.Find ("TextScore_g").GetComponent<ScoreScript> ().get_score ();

			//Set the time to be 0
			timeLeft = 0;
			gameRunning = false;
			//Set the score for the finished game
			GameObject.Find("scoreboard_final").GetComponent<scoreboard_script>().set_finish_game(score,score_g);
			//Set the scores on the RHS to not show up
			this.GetComponent<Text> ().CrossFadeAlpha (0,0,true);
			//stop music
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Stop ();
		}
		//Update the timer UI
		this.GetComponent<Text> ().text = string.Format ("{0:0.00}", Mathf.Round (timeLeft * 100.0f) / 100.0f);
	}

	/*
	 * Return a bool whether the game is still runnning
	 * Ouput:(bool) true or false if the game is running
	 * */
	public bool get_gameRunning() {
		return gameRunning;
	}
}
