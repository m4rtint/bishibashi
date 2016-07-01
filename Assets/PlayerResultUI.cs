using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerResultUI : MonoBehaviour {

	public int player;

	string P1;
	string P2;

	// Use this for initialization
	void Start () {
		P1 = "";
		P2 = "";
		this.GetComponent<Text> ().text = "";
	}

	public void setText(int player) {
		switch (player) {
		case 0:
			P1 = "";
			P2 = "";
			break;
		case 1:
			P1 = "P1";
			break;
		case 2:
			P2 = "P2";
			break;
		default:
			return;
		}
		this.GetComponent<Text> ().text = P1 + "\n" + P2;
	}
}
