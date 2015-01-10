using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	float maxHealth;
	float health;

	public HealthScript(float max, float current) {
		maxHealth = max;
		health = current;
	}
	
	// Update is called once per frame
	void Update () {
		health = Mathf.Clamp (health, 0, maxHealth);
	}

	public void damage(float amt) {
		health -= amt;
	}

	public float getHealth() {
		return health;
	}
}