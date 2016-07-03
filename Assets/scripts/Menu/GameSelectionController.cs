using UnityEngine;
using System.Collections;

public class GameSelectionController : MonoBehaviour {

	Vector3 target;
	float x_position;

	readonly float speed = 50;

	bool left;
	bool right;
	bool enter;
	bool space;

	int current_index;
	readonly int min_index = 2;
	readonly int max_index = 3;

	public AudioClip soundEffect;

	void Start() {
		x_position = this.GetComponent<Transform> ().position.x;
		target = new Vector3 (x_position, 0, 0);
		current_index = 2;
	}
	
	// Update is called once per frame
	void Update () {
		left = Input.GetKeyDown (KeyCode.LeftArrow);
		right = Input.GetKeyDown (KeyCode.RightArrow);
		enter = Input.GetKeyDown (KeyCode.Return);
		space = Input.GetKeyDown (KeyCode.Space);

		if (left && (current_index-1 < min_index)) {
			current_index++;
			x_position = this.GetComponent<Transform> ().position.x - 5;

		}
		if (right && (current_index+1 > max_index)) {
			current_index--;
			x_position = this.GetComponent<Transform> ().position.x + 5;
		}

		if (enter || space) {

			//Play Sound effect
			AudioSource source = GetComponent<AudioSource>();
			source.PlayOneShot (soundEffect,1.0F);

			//Start new level
			StartCoroutine(changeLevel ());
		}

		target = new Vector3(x_position,0,0);
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target, step);
	}


	IEnumerator changeLevel() {
		float fadeTime = GameObject.Find("FadeInOut").GetComponent<ScreenFading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (current_index);
	}
}
