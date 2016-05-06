using UnityEngine;
using System.Collections;

public class diceAnim_Script : MonoBehaviour {

	Animator anim;
	int value;

	public int dicePosition;

	GameObject diceValue;
	dice_Randomizer dice;
	diceScoreScript dScoreScript;

	void Start() {
		anim = GetComponent<Animator> ();
		diceValue = GameObject.Find ("randomizer");
		dice = diceValue.GetComponent<dice_Randomizer> ();
		dScoreScript = diceValue.GetComponent<diceScoreScript> ();

		anim.SetInteger ("Value", dice.get_value (dicePosition));
	}

	void Update() {
		int startAnim = dScoreScript.get_startAnim();
		if ((startAnim > 0) && !anim.GetCurrentAnimatorStateInfo (0).IsName ("spin")) {
			value = dice.get_value (dicePosition);
			anim.SetInteger ("Value", value);
			anim.SetTrigger ("randomizeDice");

			dScoreScript.set_startAnim_minus ();
		}
	}
}
