using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class scoreboard_script : MonoBehaviour {
	
	Animator anim;
	bool is_game_finished;
	bool oneTime =  false;
	GameObject scoreboardText;
	GameObject winnerCircle;

	//Sound Effects
	AudioSource postGame;

	//Player scores
	int p1_score;
	int p2_score;

	Text scoreText;

	// Use this for initialization
	void Start () {
		//Setup scoreboard audio
		postGame = GetComponent<AudioSource>();
		is_game_finished = false;

		//Setup Animation of scoreboard falling
		anim = GetComponent<Animator> ();

		//Setup Finished Scoreboard text
		scoreboardText = GameObject.Find("scoreBoard_Text");
		scoreText = scoreboardText.GetComponent<Text>();
		scoreText.CrossFadeAlpha (0, 0, true);

		//Setup Winner Circle - transparent
		winnerCircle = GameObject.Find("Winner");
		winnerCircle.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (is_game_finished && !oneTime) {
			Invoke ("activateAnim", 2);
			postGame.Play ();
			Invoke ("showText", 5);
			Invoke ("endGame", 12);
			oneTime = true;
		}
	}

	public void set_finish_game(int p1, int p2) {
		is_game_finished = true;
		p1_score = p1;
		p2_score = p2;
	}

	void activateAnim() {
		anim.SetTrigger ("end");
	}

	void showText() {

		//Show Score text on scoreboard
		scoreText.text = p1_score+"         "+p2_score;
		scoreText.CrossFadeAlpha (100, 10, true);

		//Circle the winnner
		winnerCircle.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
		if (p1_score >= p2_score) {
			winnerCircle.GetComponent<Transform> ().position = new Vector3 (-2.0f, -1.5f, -1.0f);
		} else {
			winnerCircle.GetComponent<Transform> ().position = new Vector3 (2.24f, -1.5f, -1.0f);
		}
	}

	void endGame() {
		SceneManager.LoadScene ("MainMenu");
	}
}
