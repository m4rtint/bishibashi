using UnityEngine;
using System.Collections;

public class diceAnim_Script : MonoBehaviour {

	Animator anim;
	int value;
	float animSpeed;
	public int dicePosition;

	GameObject diceValue;
	dice_Randomizer dice;
	diceScoreScript dScoreScript;

	void Start() {
		animSpeed = 1f;
		anim = GetComponent<Animator> ();
		diceValue = GameObject.Find ("randomizer");
		dice = diceValue.GetComponent<dice_Randomizer> ();
		dScoreScript = diceValue.GetComponent<diceScoreScript> ();

		anim.SetInteger ("Value", dice.get_value (dicePosition));
		anim.SetFloat ("Speed", animSpeed);
	}

	void Update() {
		int startAnim = dScoreScript.get_startAnim();
		if ((startAnim > 0) && !anim.GetCurrentAnimatorStateInfo (0).IsName ("spin")) {
			value = dice.get_value (dicePosition);
			anim.SetInteger ("Value", value);
			anim.SetTrigger ("randomizeDice");

			dScoreScript.set_startAnim_minus ();
			increaseSpeed ();
		}
	}

	public void increaseSpeed() {
		if (animSpeed <= 2.5f) {
			animSpeed += 0.1f;
			anim.SetFloat ("Speed", animSpeed);
		}
	}

	public float get_animSpeed() {
		return animSpeed;
	}
}
