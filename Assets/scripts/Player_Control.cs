using UnityEngine;
using System.Collections;

public class Player_Control : MonoBehaviour {
	public bool left = false;
	public bool right = false;
	public bool down = false;

	public float last_x_position = -1;

	Animator anim;

	GameObject global;

	void Start(){
		anim = GetComponent<Animator> ();
		last_x_position = 3;
		global = GameObject.Find ("TextScore");
	}

	void Update () {
		left = Input.GetKeyUp (KeyCode.LeftArrow);
		right = Input.GetKeyUp (KeyCode.RightArrow);
		down = Input.GetKeyUp (KeyCode.DownArrow);

		int position_x = (int) transform.position.x;

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

	void moveCharacter(string animation, float x) {
		last_x_position = transform.position.x;
		anim.SetTrigger(animation);
		global.GetComponent<ScoreScript> ().update_score (x);
	}
	

}
