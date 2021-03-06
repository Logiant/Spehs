﻿using UnityEngine;
using System.Collections;

public class ShieldGenScript : MonoBehaviour {

	float maxHealth = 100;
	float startHealth = 100;
	float currentHealth;

	HealthScript health;

	public float healthRatio;
	void Start () {
		health = GetComponent<HealthScript> ();
		health.initialize(maxHealth, startHealth);
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = health.getHealth ();
		healthRatio = (currentHealth/maxHealth);
	}
}
