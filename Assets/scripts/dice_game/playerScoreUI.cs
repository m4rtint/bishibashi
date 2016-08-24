using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Show the UI score of players on the RHS scoreboard
 * 
 * */
public class playerScoreUI : MonoBehaviour {

	//Player Number - 1,2
	public int player;

	//Object showing the score.
	GameObject score;
	diceScoreScript textScore;

	// Use this for initialization
	void Start () {
		//Getting Randomizer object: script - diceScoreScript
		score = GameObject.Find("randomizer");
		textScore = score.GetComponent<diceScoreScript> ();
	}

	// Update is called once per frame
	void Update () {
		string UIstring;
		//Update text of the RHS scoreboard
		UIstring = textScore.get_score (player).ToString();
		if (textScore.get_score (1) >= 100 || textScore.get_score (2) >= 100)
			UIstring = "";

		//Change score on the RHS scoreboard
		this.GetComponent<Text> ().text = UIstring;
	}
}
