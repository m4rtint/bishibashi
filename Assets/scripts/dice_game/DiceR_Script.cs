using UnityEngine;
using System.Collections;

public class DiceR_Script : MonoBehaviour {
	
	Animator anim;
	bool space = false;

	int value;

	GameObject diceValue;
	dice_Randomizer dice;

	void Start() {
		anim = GetComponent<Animator> ();
		diceValue = GameObject.Find ("randomizer");
		dice = diceValue.GetComponent<dice_Randomizer> ();
		anim.SetInteger ("Value", dice.get_value (2));
	}

	void Update() {
		space = Input.GetKeyDown (KeyCode.Space);
		if (space && !anim.GetCurrentAnimatorStateInfo (0).IsName ("spin")) {
			value = diceValue.GetComponent<dice_Randomizer> ().get_value (2);
			anim.SetInteger ("Value", value);
			anim.SetTrigger ("randomizeDice");
		}
	}
}
