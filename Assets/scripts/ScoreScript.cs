﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	int score;

	float[] step;
	int next_step;
	Text store_count;
	bool up;

	// Use this for initialization
	void Start () {
		up = false;
		score = 0;
		next_step = 1;
		step = new float[] {(float)-4.75,-1,3};
	}

	//Update score given current X position.
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

}
