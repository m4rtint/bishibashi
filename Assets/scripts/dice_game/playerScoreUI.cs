using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerScoreUI : MonoBehaviour {

	public int player;
	GameObject score;
	diceScoreScript textScore;
	// Use this for initialization
	void Start () {
		score = GameObject.Find("randomizer");
		textScore = score.GetComponent<diceScoreScript> ();
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = textScore.get_score (player).ToString();
	}
}
