using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Changing menu selection with left and right keyboard selection
 * 
 * */
public class GameSelectionController : MonoBehaviour {

	Vector3 target;
	float x_position;

	readonly float speed = 50; //Speed of animation choosing game

	bool left, right, enter, space; //Keyboard input

	int current_index; //Currently pointing at game #
	readonly int max_index = 1; //Amount of games on the board

	string level_name; //Current Chosen level name

	public AudioClip soundEffect; //SFX when something is picked

	void Start() {
		x_position = this.GetComponent<Transform> ().position.x;
		target = new Vector3 (x_position, 0, 0);
		current_index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		left = Input.GetKeyDown (KeyCode.LeftArrow);
		right = Input.GetKeyDown (KeyCode.RightArrow);
		enter = Input.GetKeyDown (KeyCode.Return);
		space = Input.GetKeyDown (KeyCode.Space);

		//Make sure cannot go more to the left.
		if (left && (current_index-1 < 0)) {
			current_index++;
			x_position = this.GetComponent<Transform> ().position.x - 5;

		}

		//Make sure Cannot go more to the right.
		if (right && (current_index+1 > max_index)) {
			current_index--;
			x_position = this.GetComponent<Transform> ().position.x + 5;
		}

		//Chosen Level change when going through different games in selection menu (Main Menu).
		if (this.GetComponent<Transform> ().position.x == 0 &&
		    this.GetComponent<Transform> ().position.y == 0) {
			level_name = this.name;
		} else {
			level_name = null;
		}

		//Select the level
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
		SceneManager.LoadScene (level_name);
	}
}
