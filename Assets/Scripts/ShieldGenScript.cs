﻿using UnityEngine;
using System.Collections;

public class ShieldGenScript : MonoBehaviour {

	int health;
	int currentHealth;
	bool shieldsUp;
	// Use this for initialization
	void Start () {
		shieldsUp = true;
		health = 15;
		currentHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		shieldsUp = (health != 0);
	}
}
