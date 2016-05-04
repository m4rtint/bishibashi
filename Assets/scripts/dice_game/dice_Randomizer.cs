using UnityEngine;
using System.Collections;
using System.Linq;

public class dice_Randomizer : MonoBehaviour {

	int[] value = new int[3];

	bool ablePress = true;

	float min, max;

	bool randomize = false;
	// Use this for initialization
	void Start () {
		min = 1;
		max = 5;
		randomizeValues ();
		Debug.Log (value [0]);
		Debug.Log (value [1]);
		Debug.Log (value [2]);
	}

	// Update is called once per frame
	void Update () {
		randomize = Input.GetKeyDown(KeyCode.Space);
		if (randomize && ablePress) {
			ablePress = false;
			Invoke ("set_ablePress_true",1f);

			randomizeValues ();

			if (max <= 16) {
				max++;
			}
		}
	}

	void randomizeValues() {
		//Generate random number into value.
		value[0] = (int) Random.Range (min, max);
		do {
			value [1] = (int)Random.Range (min, max);
			value [2] = (int)Random.Range (min, max);
		} while(value [1] == value [0] || value [2] == value [1] || value [2] == value [0]);

	}

	public int get_value(int i) {
		//TODO - TRY CATCH FOR ARRAY OUT OF BOUNDS
		return value[i];
	}

	public int get_max_value(){
		return value.Max ();
	}

	public void set_ablePress_true() {
		ablePress = true;
	}
}
