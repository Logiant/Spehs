using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HealthScript))]
public class HelmScript : MonoBehaviour {

	public bool lose;

	public float maxHealth;
	public float startingHealth;

	HealthScript health;

	// Use this for initialization
	void Start () {
		health.initialize(maxHealth, startingHealth);
	}

	void Update() {
		if (health.getHealth () <= 0) {
			lose = true;
		}
	}
}
