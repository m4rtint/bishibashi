using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/*
 * Start Menu/Screen controller
 */ 
public class StartScreenController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			StartCoroutine(changeLevel ());
		}

	}

	IEnumerator changeLevel() {
		float fadeTime = this.GetComponent<ScreenFading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("MainMenu");
	}
}
