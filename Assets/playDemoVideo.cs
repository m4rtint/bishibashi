using UnityEngine;
using System.Collections;
[RequireComponent (typeof(AudioSource))]
public class playDemoVideo : MonoBehaviour {

	public MovieTexture movie;

	void Start(){
		GetComponent<Renderer> ().material.mainTexture = movie as MovieTexture;
		GetComponent<AudioSource> ().clip = movie.audioClip;
	
			movie.Play();
		GetComponent<AudioSource> ().Play ();
	}
}
