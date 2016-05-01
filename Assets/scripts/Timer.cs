using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	float timeLeft = 15.0f;

	void Update()
	{
		timeLeft -= Time.deltaTime;

		this.GetComponent<Text> ().text = ""+Mathf.Round(timeLeft * 100f) / 100f;
		if(timeLeft < 0)
		{
			//Debug.Log ("Finished");
		}
	}
}
