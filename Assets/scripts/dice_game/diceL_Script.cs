using UnityEngine;
using System.Collections;

public class diceL_Script : MonoBehaviour {

	Sprite[] dice;
	Animator anim;
	bool space = false;
	bool ablePress = true;

	int value;

	GameObject diceValue;

	void Start() {
		dice = Resources.LoadAll<Sprite> ("sprite/Dice_Sprite_Sheet");
		anim = GetComponent<Animator> ();
		diceValue = GameObject.Find ("randomizer");
	}

	void Update() {
		space = Input.GetKeyDown (KeyCode.Space);

		if (space && ablePress) {
			this.GetComponent<Animator> ().enabled = true;
			ablePress = false;

			anim.SetTrigger ("randomizeDice");
			value = diceValue.GetComponent<dice_Randomizer> ().get_value (0);
		
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Dice_1")) {
				this.GetComponent<Animator> ().enabled = true;
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("idle")) {
				//Invoke ("UpdateSprite", 1.5f);
				set_ablePress_true();
				this.GetComponent<Animator> ().enabled = true;
				this.GetComponent<SpriteRenderer> ().sprite = dice[value+3];
			}
		

		}
	}

	void UpdateSprite() {
		this.GetComponent<Animator> ().enabled = false;
		this.GetComponent<SpriteRenderer> ().sprite = dice[value+3];
	}

	public void set_ablePress_true() {
		ablePress = true;
	}
}
