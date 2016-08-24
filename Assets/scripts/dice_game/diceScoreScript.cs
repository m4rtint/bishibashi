using UnityEngine;
using System.Collections;

/*
 * Player 1 and Player 2 Keyboard input
 * starting and stopping dice randomization and dice animation
 * 
 */
public class diceScoreScript : MonoBehaviour {

	//Scoreboard
	int p1_score,p2_score;

	//P1 - Controls
	bool left,down,right,up, P1_allowPress;

	//P2 - Controls
	bool a,s,d,w, P2_allowPress;

	//Whether or not to randomize
	bool startRandomize;
	//This value determines if any dice can start animation
	//If value = 3, any one of the three dice can take a value.
	//Since there are 3 dice, each one takes one value.
	//Once it reaches 0, none of the dice can start animating anymore.
	//(This is to make sure no dice can animate more than once in one round)
	int startAnim;

	//Reference to other scripts
	GameObject value, result_L_obj, result_M_obj, result_R_obj, dice;
	GameObject Player_Text_L, Player_Text_M, Player_Text_R;
	dice_Randomizer diceValue;

	//Sound Effects
	AudioSource gun_shot_sfx;

	// Use this for initialization
	void Start () {
		//Sound effect set
		gun_shot_sfx = GetComponent<AudioSource>();

		//Set whether or not to randomize
		startAnim = 0;
	
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
		dice = GameObject.Find("dice_L");
		value = GameObject.Find("randomizer");
		diceValue = value.GetComponent<dice_Randomizer> ();
		result_L_obj = GameObject.Find ("result_L");
		result_M_obj = GameObject.Find ("result_M");
		result_R_obj = GameObject.Find ("result_R");
		Player_Text_L = GameObject.Find ("result_L_Text");
		Player_Text_M = GameObject.Find ("result_M_Text");
		Player_Text_R = GameObject.Find ("result_R_Text");
	}
	
	// Update is called once per frame
	void Update () {
		//Player 1 - KeyInput
		left = Input.GetKeyDown (KeyCode.LeftArrow);
		down = Input.GetKeyDown (KeyCode.DownArrow);
		up = Input.GetKeyDown (KeyCode.UpArrow);
		right = Input.GetKeyDown (KeyCode.RightArrow);

		//Player 2 - KeyInput 
		a = Input.GetKeyDown (KeyCode.A);
		s = Input.GetKeyDown (KeyCode.S);
		w = Input.GetKeyDown (KeyCode.W);
		d = Input.GetKeyDown (KeyCode.D);

		//END GAME
		//When Someone reaches winning score
		if (p1_score >= 100 || p2_score >= 100){
			//Stop Sound Effects and background music
			gun_shot_sfx.Stop ();
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Stop ();
			//Set the finishing scores and set endgame value as true.
			GameObject.Find ("scoreboard_final").GetComponent<scoreboard_script>().set_finish_game(p1_score,p2_score);
			return;
		}

		/*
		 * If dice is not in mid animation - Allow players to press. 
		 * 		See which button the players presses
		 */
		if (P1_allowPress) {
			//Dice Position - P1 - 0
			if (a) {
				//Add up score
				updateScore (1, 0);
				//Show if P1 or P2 win/lose the round on UI.
				Player_Text_L.GetComponent<PlayerResultUI> ().setText (1);
			}

			//Dice Position - P1 - 1
			if (s||w) {
				updateScore (1, 1);
				Player_Text_M.GetComponent<PlayerResultUI> ().setText (1);
			}

			//Dice Position - P1 - 2
			if (d) {
				updateScore (1, 2);
				Player_Text_R.GetComponent<PlayerResultUI> ().setText (1);
			}
		}

		if (P2_allowPress) {
			//Dice Position - P2 - 0
			if (left) {
				updateScore (2, 0);
				Player_Text_L.GetComponent<PlayerResultUI> ().setText (2);
			}

			//Dice Position - P2 - 1
			if (down||up) {
				updateScore (2, 1);
				Player_Text_M.GetComponent<PlayerResultUI> ().setText (2);
			}

			//Dice Position - P2 - 2
			if (right) {
				updateScore (2, 2);
				Player_Text_R.GetComponent<PlayerResultUI> ().setText (2);
			}
		}
	}

	/*
	 * Update the score for both players 
	 * proceed to roll the dice depending on outcome.
	 * Input - (int - 1,2) player's score to update, (int - 0,1,2) Which dice location
	 * Output - score is updated
	 */
	void updateScore(int player, int diceLocation) {
		if (diceValue.get_value (diceLocation) == diceValue.get_max_value ()) {
		//Correct Match
			//Add up score
			if (player == 1) 
				p1_score += diceValue.get_value (diceLocation);
			else
				p2_score += diceValue.get_value (diceLocation);

			//roll Dice
			start_diceRoll(true, diceLocation, player);
		} else {
		//Incorrect Match
			//Freeze buttons
			if (player == 1) {
				P1_allowPress = false;
			} else {
				P2_allowPress = false;
			}

			set_result(false, diceLocation, player);

			//If Both are incorrect - roll Dice
			if (!P1_allowPress && !P2_allowPress) {
				start_diceRoll(false,diceLocation, player);
			}
		}
	}

	/*
	 * Start randomization on backend as well as animation
	 * Input - (bool) player is right/wrong, (int
	 * 
	 */ 
	void start_diceRoll(bool rw, int l, int p) {

		//Result Sprite appears
		set_result(rw, l, p);

		//Disable All Controls
		P1_allowPress = false;
		P2_allowPress = false;
				
		//Generate Randomize Numbers
		diceValue.randomizeValues();

		float delay = 1f;
		float speedUp = dice.GetComponent<diceAnim_Script> ().get_animSpeed();
		//Start the animation
		Invoke ("set_startAnim_full", delay/speedUp);  
		//Disable the result icons - cross/circle
		Invoke ("set_disappearIcon", delay/speedUp);
		//Remove Player UI Text
		Invoke("set_playerTextDisappear",delay/speedUp);
		//Enable controls
		Invoke("set_ControlEnable", (delay*2)/speedUp);

	}
		
	/*
	 * Enable controls
	 */ 
	void set_ControlEnable() {
		P1_allowPress = true;
		P2_allowPress = true;
	}

	/*
	 * Player Result Text disppear on timer
	 */
	void set_playerTextDisappear() {
		Player_Text_L.GetComponent<PlayerResultUI> ().setText (0);
		Player_Text_M.GetComponent<PlayerResultUI> ().setText (0);
		Player_Text_R.GetComponent<PlayerResultUI> ().setText (0);
	}

	/*
	 * Result Icon disappear on a timer
	 */
	void set_disappearIcon(){
		result_L_obj.GetComponent<DiceResultScript> ().set_disappear_icon ();
		result_M_obj.GetComponent<DiceResultScript> ().set_disappear_icon ();
		result_R_obj.GetComponent<DiceResultScript> ().set_disappear_icon ();
	}

	/*
	 * Start animation on a timer 
	 */
	void set_startAnim_full() {
		//Play Gunshot Sound effect
		gun_shot_sfx.Play();
		startAnim = 3;
	}

	/*
	 * Changing the sprite to become a cross or circle depending on result
	 * Input: (bool) result, (int - 0,1,2) dice location, (int - 1,2) Player Number
	 * Output: send results to corresponsing Dice object.
	 */
	void set_result(bool rightwrong, int diceLocation,int player){
		switch (diceLocation) {
		case 0:
			result_L_obj.GetComponent<DiceResultScript> ().set_Result(rightwrong);
			break;
		case 1:
			result_M_obj.GetComponent<DiceResultScript> ().set_Result(rightwrong);
			break;
		case 2:
			result_R_obj.GetComponent<DiceResultScript> ().set_Result(rightwrong);
			break;
		default:
			return;
		}
	}

	//Public Functions

	/*
	 * Amount of Dices to animate
	 */
	public int get_startAnim() {
		return startAnim;
	}

	/*
	 * Decrement the amount of dice to animate
	 */
	public void set_startAnim_minus() {
		startAnim--;
	}

	/*
	 * The Players score
	 * Input: (int - 1,2) Player number
	 * Output: (int) Return player score
	 */
	public int get_score (int player) {
		if (player == 1) {
			return p1_score;
		} else {
			return p2_score;
		}
	}
}
