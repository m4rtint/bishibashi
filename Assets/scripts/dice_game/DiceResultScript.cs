using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
/*
 * Show the UI of whether the player input correct value or not
 * Either a Cross or a circle with color and sound effects
 * */
public class DiceResultScript : MonoBehaviour {

	AudioSource[] audio;
	AudioSource right;
	AudioSource wrong;
	// Use this for initialization
	void Start () {
		audio = GetComponents<AudioSource>();
		right = audio [0];
		wrong = audio [1];

		this.GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0);
	}

	public void set_Result(bool RightWrong) {
		if (RightWrong) {
			right.Play ();
			this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("circle-outline-xxl", typeof(Sprite)) as Sprite;
			this.GetComponent<SpriteRenderer> ().color = new Color (255, 205, 0, 255);
			//Invoke ("set_disappear_icon", 0.1f);
		} else {
			wrong.Play ();
			this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("cross", typeof(Sprite)) as Sprite;
			this.GetComponent<SpriteRenderer> ().color = new Color (0, 192, 255, 255);
		}
	}

	public void set_disappear_icon() {
		this.GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0);
	}
}
