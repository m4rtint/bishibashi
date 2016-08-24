using UnityEngine;
using System.Collections;


/*
 * Setup and change the animation speed depending on the score.
 * 
 * */
public class diceAnim_Script : MonoBehaviour {

	//Animation speed
	float animSpeed;
	//Animation component of this object
	Animator anim;

	//randomizer gameobject
	GameObject diceValue;
	dice_Randomizer dice;
	diceScoreScript dScoreScript;

	int value;

	//Dice position of current dice gameobject
	public int dicePosition;

	//Initialization of values
	void Start() {
		//Initial Animation Dice spin Speed
		animSpeed = 1f;
		//Getting animation component of this object
		anim = GetComponent<Animator> ();
		//Get GameObject of randomizer - scripts: dice_Randomizer, diceScoreScript
		diceValue = GameObject.Find ("randomizer");
		dice = diceValue.GetComponent<dice_Randomizer> ();
		dScoreScript = diceValue.GetComponent<diceScoreScript> ();

		//Setup Initial animation value
		anim.SetInteger ("Value", dice.get_value (dicePosition));
		anim.SetFloat ("Speed", animSpeed);
	}

	void Update() {
		//Get value to check if animation can be started
		int startAnim = dScoreScript.get_startAnim();
		//Check if there are enough values to start animation
		//Check if dice is currently in animation
		if ((startAnim > 0) && !anim.GetCurrentAnimatorStateInfo (0).IsName ("spin")) {
			//Grab the randomized value of certain dice position
			value = dice.get_value (dicePosition);
			//Start animation
			anim.SetInteger ("Value", value);
			anim.SetTrigger ("randomizeDice");

			//Decrement amount of dice animation value available
			dScoreScript.set_startAnim_minus ();
			//increase speed on animation
			increaseSpeed ();
		}
	}

	/*
	 * Increase the speed of dice animation
	 * Output: Incrase 0.1f each time, max out is 2.5f
	 * 
	 * */
	public void increaseSpeed() {
		if (animSpeed <= 2.5f) {
			animSpeed += 0.1f;
			anim.SetFloat ("Speed", animSpeed);
		}
	}

	/*
	 * Return the speed of the animation 
	 * Output: (float) Current speed of dice animation
	 * */
	public float get_animSpeed() {
		return animSpeed;
	}
}
