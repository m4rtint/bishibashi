using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Set the UI  
 * Results of the series are shown 
 * Either P1 or P2 will be shown on each dice.
 */
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

	/*
	 * Set on UI 
	 * P1 or P2 got it wrong or right
	 * Input - (int 1,2) Player 1 or 2
	 * Output - UI of P1 or P2 shown on screen shown for this.object
	 */ 
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
