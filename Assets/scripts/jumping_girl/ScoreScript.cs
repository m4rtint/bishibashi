using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Updating Scores for players
 */ 
public class ScoreScript : MonoBehaviour {

	//whether or not player is currently in the middle
	bool up;
	//Player's score
	int score;
	//next player location to increase score
	int next_step;

	//Coordinates of the three locations player must jump to.
	float[] step;

	//GameObject for timer
	GameObject timer;

	// Use this for initialization
	void Start () {
		//Players start off NOT in the middle
		up = false;
		//Start Players scores as 0
		score = 0;
		//initialize Position of the next step (1 = middle)
		next_step = 1;
		//Setup three coordinates of the three location player must jump to.
		step = new float[] {(float)-4.75,-1,3};
		//Get Timer GameObject
		timer = GameObject.Find ("Timer");
	}

	//If timer runs out, score on RHS scoreboard is faded out
	void Update() {
		if (!timer.GetComponent<Timer> ().get_gameRunning ()) {
			this.GetComponent<Text> ().CrossFadeAlpha (0, 0, true);
		}
	}

	/*
	 * Update new score of player depending on their current x coordinate / location
	 * Input: (float -4.75,-1,3) current player x coordinate
	 * Output: Update score depending on where player going to
	 * 
	 * */
	public void update_score(float x){
		//If the new X matches the supposed step
		if (x == step [next_step]) {
			score++;

			//Update the supposed step
			if (next_step == 0)
				up = true;
			if (next_step == 2)
				up = false;
			
			if (up)
				next_step++;
			else
				next_step--;

			this.GetComponent<Text> ().text = ""+score;
		} else
			return;
		
	}

	/*
	 * Return player score
	 * Output: (int) Player score
	 * 
	 * */
	public int get_score() {
		return score;
	}
}
