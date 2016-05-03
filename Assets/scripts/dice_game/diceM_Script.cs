using UnityEngine;
using System.Collections;

public class diceM_Script : MonoBehaviour {

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
		if (space && ablePress ) {
			this.GetComponent<Animator> ().enabled = true;
			ablePress = false;
			Invoke ("set_ablePress_true",1f);

			anim.SetTrigger ("randomizeDice");
			value = diceValue.GetComponent<dice_Randomizer> ().get_value (1);
			Debug.Log (value);
			Invoke ("UpdateSprite", 1.5f);
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
