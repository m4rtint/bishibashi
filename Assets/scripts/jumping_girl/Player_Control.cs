using UnityEngine;
using System.Collections;

/*
 * Player Controls and animation
 * 
 */ 
public class Player_Control : MonoBehaviour {

	//Player Input
	bool left,right,down,up = false;

	//Which player is using this script 1 or 2
	public int player_num;

	//Animation for character
	Animator anim;

	//Used for calling outside methods
	GameObject global,timer;

	//Setup Audio source
	AudioSource[] audio;
	AudioSource jump1;
	AudioSource jump2;
	bool altingJump;

	void Start(){
		//Initiate animation
		anim = GetComponent<Animator> ();

		//Get corresponding object to update textscore
		if (player_num == 1) {
			global = GameObject.Find ("TextScore");
		} else {
			global = GameObject.Find ("TextScore_g");
		}

		//Get object for timer
		timer = GameObject.Find ("Timer");

		//Setup audio
		audio = GetComponents<AudioSource>();
		jump1 = audio [0];
		jump2 = audio [1];
		altingJump = true;
	
	}

	void Update () {
		//Check if timer is still running. 
		//allow user input if timer > 0, else stop animation
		if (timer.GetComponent<Timer>().get_gameRunning()) {
			inputControl ();
		} else {
			anim.Stop ();
		}
	}


	/*
	 * Check for player controller input, starts animation
	 * Output - Starts animation depending on key input
	 * 
	 * */
	void inputControl() {
		//Get input control depending on player 1 or 2
		if (player_num == 1) {
			left = Input.GetKeyDown (KeyCode.LeftArrow);
			right = Input.GetKeyDown (KeyCode.RightArrow);
			down = Input.GetKeyDown (KeyCode.DownArrow);
			up = Input.GetKeyDown (KeyCode.UpArrow);
		} else {
			left = Input.GetKeyDown (KeyCode.A);
			right = Input.GetKeyDown (KeyCode.D);
			down = Input.GetKeyDown (KeyCode.S);
			up = Input.GetKeyDown (KeyCode.W);
		}
		int position_x = (int)transform.position.x;

		//Algorithm for making sure that character uses correct animation
		//depending on the character location
		switch (position_x) {
		case 3:
			if (down||up) {
				moveCharacter ("Rjumpleft", (float)-1);
			}
			break;
		case -1:
		case 0:
			if (left) {
				moveCharacter ("Ljumpleft", (float)-4.75);
			}
			if (right) {
				moveCharacter ("Rjumpright", (float)3);
			}
			break;
		case -4:
			if (down||up) {
				moveCharacter ("Ljumpright", (float)-1);
			}
			break;
		default:
			break;
		}
	}

	//Activate animation and update the score and start jump sound effect.
	void moveCharacter(string animation, float landing_x) {
		jump_sound ();
		anim.SetTrigger(animation);
		global.GetComponent<ScoreScript> ().update_score (landing_x);
	}

	//Alternating jump sound effects.
	void jump_sound() {
		if (altingJump)
			jump1.Play ();
		else
			jump2.Play ();

		altingJump = !altingJump;
	}
}
