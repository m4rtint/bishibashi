using UnityEngine;
using System.Collections;

public class scoreboard_script : MonoBehaviour {
	
	GameObject timer;
	Animator anim;
	// Use this for initialization
	void Start () {
		timer = GameObject.Find ("Timer");
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!timer.GetComponent<Timer> ().get_gameRunning ()) {
			Invoke ("activateAnim", 2);
		}
	}

	void activateAnim() {
		anim.SetTrigger ("end");
	}
}
