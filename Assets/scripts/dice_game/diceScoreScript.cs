using UnityEngine;
using System.Collections;

public class diceScoreScript : MonoBehaviour {

	//Scoreboard
	int p1_score, p2_score;

	//P1 - Controls
	bool left, down, right;

	//P2 - Controls
	bool a,s,d;

	//Reference to other scripts
	GameObject value;
	dice_Randomizer diceValue;

	// Use this for initialization
	void Start () {
		p1_score = 0;
		p2_score = 0;

		//P1 - Controls
		left = false;
		down = false;
		right = false;

		//P2 - Controls
		a = false;
		s = false;
		d = false;

		//Other Script values
		value = GameObject.Find("randomizer");
		diceValue = value.GetComponent<dice_Randomizer> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Player 1 - KeyInput
		left = Input.GetKeyDown (KeyCode.LeftArrow);
		down = Input.GetKeyDown (KeyCode.DownArrow);
		right = Input.GetKeyDown (KeyCode.RightArrow);

		//Player 2 - KeyInput 
		a = Input.GetKeyDown (KeyCode.A);
		s = Input.GetKeyDown (KeyCode.S);
		d = Input.GetKeyDown (KeyCode.D);

		//Dice Position - 0
		if (left) {
			if (Compare_Max_Value (0)) {
				//Correct Match
					//Circle Sprite appears
					//Score adds up
				p2_score += diceValue.get_value (0);
				Debug.Log (p2_score);
				Debug.Log ("Dice Value :"+diceValue.get_value (0));
			} else {
				//Incorrect Match
					//Cross Sprite appears
					//Freeze buttons
				Debug.Log (p2_score);
				Debug.Log ("Dice Value :"+diceValue.get_value (0));
			}
		}

		//Dice Position - 1
		if (down) {
			if (Compare_Max_Value (1)) {
				//Correct Match
				//Circle Sprite appears
				//Score adds up
				p2_score += diceValue.get_value (1);
				Debug.Log (p2_score);
				Debug.Log ("Dice Value :"+diceValue.get_value (1));
			} else {
				//Incorrect Match
				//Cross Sprite appears
				//Freeze buttons
				Debug.Log (p2_score);
				Debug.Log ("Dice Value :"+diceValue.get_value (1));
			}
		}

		//Dice Position - 2
		if (right) {
			if (Compare_Max_Value (2)) {
				//Correct Match
				//Circle Sprite appears
				//Score adds up
				p2_score += diceValue.get_value (2);
				Debug.Log (p2_score);
				Debug.Log ("Dice Value :"+diceValue.get_value (2));
			} else {
				//Incorrect Match
				//Cross Sprite appears
				//Freeze buttons
				Debug.Log (p2_score);
				Debug.Log ("Dice Value :"+diceValue.get_value (2));
			}
		}

	}

	bool Compare_Max_Value(int dice_position) {
		if (diceValue.get_value (dice_position) == diceValue.get_max_value ()) {
			return true;
		} else {
			return false;
		}
	}
}
