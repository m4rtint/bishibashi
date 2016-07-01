using UnityEngine;
using System.Collections;

public class FadeObjectInOut : MonoBehaviour
{
	float duration = 1;
	float alpha = 0;


	public void Update(){
		lerpAlpha();
	}

	private void lerpAlpha(){
		float lerp = Mathf.PingPong (Time.time, duration) / duration;

		alpha = Mathf.Lerp (0, 1, lerp);
		//renderer.GetComponent<Renderer>().color.a = alpha;
	}


}