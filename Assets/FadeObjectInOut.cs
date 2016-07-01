using UnityEngine;
using System.Collections;

public class FadeObjectInOut : MonoBehaviour
{
	float duration = 1;
	float alphaTemp = 0;


	public void Update(){
		lerpAlpha();
	}

	private void lerpAlpha(){
		float lerp = Mathf.PingPong (Time.time, duration) / duration;

		alphaTemp = Mathf.Lerp (0, 1, lerp);
		this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alphaTemp);
	}


}