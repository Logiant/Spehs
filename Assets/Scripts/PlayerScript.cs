using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float health = 100;
	public float speed = 6; // m/s
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (health <= 0) {
		//	Motion();
		}
	}
	
	public void Damage(float amt) {
		health -= amt;
	}
}
