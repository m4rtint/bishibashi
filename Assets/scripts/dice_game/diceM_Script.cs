using UnityEngine;
using System.Collections;

public class diceM_Script : MonoBehaviour {

	Sprite[] dice;
	Animator anim;
	bool space = false;

	int value;

	GameObject diceValue;

	void Start() {
		dice = Resources.LoadAll<Sprite> ("sprite/Dice_Sprite_Sheet");
		anim = GetComponent<Animator> ();
		diceValue = GameObject.Find ("randomizer");
	}

	void Update() {
		space = Input.GetKeyDown (KeyCode.Space);
		if (space && !anim.GetCurrentAnimatorStateInfo (0).IsName ("spin")) {
			value = diceValue.GetComponent<dice_Randomizer> ().get_value (1);
			anim.SetInteger ("Value", value);
			anim.SetTrigger ("randomizeDice");
		}
	}
}
