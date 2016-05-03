using UnityEngine;
using System.Collections;

public class mainMenuController : MonoBehaviour {

	int player;

	bool down = false;
	bool up = false;
	// Use this for initialization
	void Start () {
		player = 1;
	}
	
	// Update is called once per frame
	void Update () {
		down = Input.GetKeyUp (KeyCode.DownArrow);
		up = Input.GetKeyUp (KeyCode.UpArrow);
		if (up) {
			this.GetComponent<SpriteRenderer> ().sprite = Resources.Load("main_1",typeof(Sprite)) as Sprite;
			player = 1;
		}
		if (down) {
			this.GetComponent<SpriteRenderer> ().sprite = Resources.Load("main_2",typeof(Sprite)) as Sprite;
			player = 2;
		}
	}

	public int get_Player() {
		return player;
	}
}
