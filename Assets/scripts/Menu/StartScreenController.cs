using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour {

	bool any = false;
	// Update is called once per frame
	void Update () {
		any = Input.anyKeyDown;

		if (any) {
			StartCoroutine(changeLevel ());
			Debug.Log ("pressing any");
		}

	}

	IEnumerator changeLevel() {
		Debug.Log ("Inside");
		float fadeTime = this.GetComponent<ScreenFading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (1);
	}
}
