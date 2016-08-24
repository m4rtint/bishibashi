using UnityEngine;
using System.Collections;

/*
 * Ready , Go, Start Animation in beginning on games
 * */
public class ReadyGoStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (start_Animation ());
	}

	//Timer to change sprite render between ready, go, start
	IEnumerator start_Animation() {
		yield return new WaitForSeconds (0.9f);
		this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("go", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (0.7f);
		this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);

	}
}
