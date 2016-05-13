using UnityEngine;
using System.Collections;
using System.Linq;

public class dice_Randomizer : MonoBehaviour {

	int[] value = new int[3];

	float min, max;

	// Use this for initialization
	void Start () {
		min = 1;
		max = 5;
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

		if (max <= 16) { max++; }
		Debug.Log ("L :" + value [0] + " | M :" + value [1] + " | R :" + value [2]);
	}

	public int get_value(int i) {
		//TODO - TRY CATCH FOR ARRAY OUT OF BOUNDS
		return value[i];
	}

	public int get_max_value(){
		return value.Max ();
	}
}
