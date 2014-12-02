using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Application.LoadLevel(0);

		}
	}

	public void Damage(float amt) {
		health -= amt;
	}
}
