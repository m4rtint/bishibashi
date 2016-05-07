using UnityEngine;
using System.Collections;

public class diceScoreScript : MonoBehaviour {

	//Scoreboard
	int p1_score,p2_score;

	//P1 - Controls
	bool left,down,right, P1_allowPress;

	//P2 - Controls
	bool a,s,d, P2_allowPress;

	//Whether or not to randomize
	bool startRandomize;
	int startAnim;

	//Reference to other scripts
	GameObject value;
	GameObject dice_L_obj, dice_M_obj, dice_R_obj;
	dice_Randomizer diceValue;

	// Use this for initialization
	void Start () {
		//Set whether or not to randomize
		startAnim = 0;
		startRandomize = false;


		//Allow players to press
		P1_allowPress = true;
		P2_allowPress = true;

		//Players scores
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
		dice_L_obj = GameObject.Find ("result_L");
		dice_M_obj = GameObject.Find ("result_M");
		dice_R_obj = GameObject.Find ("result_R");

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

		if (P1_allowPress) {
			//Dice Position - P1 - 0
			if (a) {
				updateScore (1, 0);
			}

			//Dice Position - P1 - 1
			if (s) {
				updateScore (1, 1);
			}

			//Dice Position - P1 - 2
			if (d) {
				updateScore (1, 2);
			}
		}

		if (P2_allowPress) {
			//Dice Position - P2 - 0
			if (left) {
				updateScore (2, 0);
			}

			//Dice Position - P2 - 1
			if (down) {
				updateScore (2, 1);
			}

			//Dice Position - P2 - 2
			if (right) {
				updateScore (2, 2);
			}
		}

		if (!P1_allowPress && !P2_allowPress) {
			start_Randomize ();
		}
	}

	void updateScore(int player, int diceLocation) {
		if (Compare_Max_Value (diceLocation)) {
		//Correct Match
			//Circle Sprite appears
			set_result(true, diceLocation, player);

			//Randomize Numbers
			start_Randomize();

			//Add up score
			if (player == 1) {
				p1_score += diceValue.get_value (diceLocation);
				Debug.Log ("P1 :"+p1_score);
			} else {
				p2_score += diceValue.get_value (diceLocation);
				Debug.Log ("P2 :"+p2_score);
			}
		} else {
		//Incorrect Match
			//Cross Sprite appears
			set_result(false,diceLocation, player);

			//Freeze buttons
			if (player == 1) {
				P1_allowPress = false;
				Debug.Log ("P1 :"+p1_score);
			} else {
				P2_allowPress = false;
				Debug.Log ("P2 :"+p2_score);
			}
		}
	}

	void resultAppear(bool result, int diceLocation) {

	}

	bool Compare_Max_Value(int dice_position) {
		if (diceValue.get_value (dice_position) == diceValue.get_max_value ()) {
			return true;
		} else {
			return false;
		}
	}

	void start_Randomize() {
		P1_allowPress = true;
		P2_allowPress = true;
		startRandomize = true;
		Invoke ("set_startAnim_full", 1f);
		Invoke ("set_disappearIcon", 1f);

	}

	void set_disappearIcon(){
		dice_L_obj.GetComponent<DiceResultScript> ().set_disappear_icon ();
		dice_M_obj.GetComponent<DiceResultScript> ().set_disappear_icon ();
		dice_R_obj.GetComponent<DiceResultScript> ().set_disappear_icon ();
	}

	void set_startAnim_full() {
		startAnim = 3;
	}

	void set_result(bool rightwrong, int diceLocation,int player){
		switch (diceLocation) {
		case 0:
			dice_L_obj.GetComponent<DiceResultScript> ().set_Result(rightwrong);
			break;
		case 1:
			dice_M_obj.GetComponent<DiceResultScript> ().set_Result(rightwrong);
			break;
		case 2:
			dice_R_obj.GetComponent<DiceResultScript> ().set_Result(rightwrong);
			break;
		default:
			return;
		}
	}


	// Public Methods
	public bool get_startRandomize() {
		return startRandomize;
	}

	public void set_startRandomize_false() {
		startRandomize = false;
	}

	public int get_startAnim() {
		return startAnim;
	}

	public void set_startAnim_minus() {
		startAnim--;
	}


}
