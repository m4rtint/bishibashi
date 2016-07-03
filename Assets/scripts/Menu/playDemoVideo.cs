using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]
public class playDemoVideo : MonoBehaviour {

	public string game_selection;
	public MovieTexture movie;

	bool ready_click;
	void Start(){
		ready_click = false;
		StartCoroutine (waitToClick());
		GetComponent<Renderer> ().material.mainTexture = movie as MovieTexture;
		GetComponent<AudioSource> ().clip = movie.audioClip;
	
		movie.Play();
		GetComponent<AudioSource> ().Play ();
	}

	void Update() {
				if (Input.anyKey && ready_click ) {
					movie.Stop ();
					SceneManager.LoadScene (game_selection);
				}
	}

	IEnumerator waitToClick() {
		yield return new WaitForSeconds (10);
		ready_click = true;
	}

}
