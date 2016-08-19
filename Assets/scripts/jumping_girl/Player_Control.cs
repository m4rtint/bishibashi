using UnityEngine;
using System.Collections;

public class Player_Control : MonoBehaviour {
	bool left = false;
	bool right = false;
	bool down = false;

	public int player_num;

	Animator anim;

	GameObject global,timer;

	void Start(){
		anim = GetComponent<Animator> ();
		if (player_num == 1) {
			global = GameObject.Find ("TextScore");
		} else {
			global = GameObject.Find ("TextScore_g");
		}
		timer = GameObject.Find ("Timer");
	}

	void Update () {
		if (timer.GetComponent<Timer>().get_gameRunning()) {
			inputControl ();
		} else {
			anim.Stop ();
		}
	}



	void inputControl() {
		//Get input control depending on player 1 or 2
		if (player_num == 1) {
			left = Input.GetKeyDown (KeyCode.LeftArrow);
			right = Input.GetKeyDown (KeyCode.RightArrow);
			down = Input.GetKeyDown (KeyCode.DownArrow);
		} else {
			left = Input.GetKeyDown (KeyCode.A);
			right = Input.GetKeyDown (KeyCode.D);
			down = Input.GetKeyDown (KeyCode.S);
		}
		int position_x = (int)transform.position.x;

		switch (position_x) {
		case 3:
			if (down) {
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
			if (down) {
				moveCharacter ("Ljumpright", (float)-1);
			}
			break;
		default:
			break;
		}
	}

	void moveCharacter(string animation, float landing_x) {
		anim.SetTrigger(animation);
		global.GetComponent<ScoreScript> ().update_score (landing_x);
	}
}
