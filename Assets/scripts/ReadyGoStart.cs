using UnityEngine;
using System.Collections;

public class ReadyGoStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (start_Animation ());
	}
	
	IEnumerator start_Animation() {
		yield return new WaitForSeconds (0.9f);
		this.GetComponent<SpriteRenderer> ().sprite = Resources.Load ("go", typeof(Sprite)) as Sprite;
		yield return new WaitForSeconds (0.7f);
		this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);

	}
}
