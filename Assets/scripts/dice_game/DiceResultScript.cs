using UnityEngine;
using System.Collections;

public class DiceResultScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0);
	}

	public void set_Result(bool RightWrong) {
		if (RightWrong) {
			this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("circle-outline-xxl", typeof(Sprite)) as Sprite;
			this.GetComponent<SpriteRenderer> ().color = new Color (255, 205, 0, 255);
			//Invoke ("set_disappear_icon", 0.1f);
		} else {
			this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("cross", typeof(Sprite)) as Sprite;
			this.GetComponent<SpriteRenderer> ().color = new Color (0, 192, 255, 255);
		}
	}

	public void set_disappear_icon() {
		this.GetComponent<SpriteRenderer> ().color = new Color (0,0,0,0);
	}
}
