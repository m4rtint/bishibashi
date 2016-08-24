using UnityEngine;
using System.Collections;
using System.Linq;

/*
 * Generate new dice values for each dice
 *
 * */
public class dice_Randomizer : MonoBehaviour {

	//Storage for the three dice values
	int[] value = new int[3];

	//Current Min and Max of dice value that are available
	float min, max;

	// Use this for initialization
	void Start () {
		min = 1;
		max = 5;
		//Setup randomize dice values
		randomizeValues ();
	}


	public void randomizeValues() {
		//Generate random number into value.
		do {
			for(int x = 0; x < 3; x++) 
			{
				value [x] = (int)Random.Range (min, max);
			}
		} while(value.Distinct ().Count () != value.Count ());

		//Max value of dice goes up till 16.
		if (max <= 16) { max++; }
		Debug.Log ("L :" + value [0] + " | M :" + value [1] + " | R :" + value [2]);
	}

	/*
	 * Return value of dice location
	 * Input: (int - 0,1,2) dice location
	 * Output: (int - 1...16) dice value
	 * 
	 * */
	public int get_value(int i) {
		try{
			return value[i];
		}catch(System.Exception e){
			Debug.Log (e);
			return 1;
		}
	}

	/*
	 * Get current biggest dice value out of all 3 dice values
	 * Output: current biggest dice value out of all 3 dice values
	 * */
	public int get_max_value(){
		return value.Max ();
	}
}
