using UnityEngine;
using System.Collections;

public class WeaponsBayScript : MonoBehaviour {


	public float victoryTime = 240; //seconds before enemy ship is destroyed
	public bool broken;
	
	// Update is called once per frame
	void Update () {
		if (!broken) {
			victoryTime -= Time.deltaTime;
		}
	}
}
