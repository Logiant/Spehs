using UnityEngine;
using System.Collections;

public class ShieldGenScript : MonoBehaviour {

	float maxHealth = 100;
	float startHealth = 100;
	float currentHealth;

	HealthScript health;

	public float healthRatio;
	// Use this for initialization
	void Start () {
		health = new HealthScript (maxHealth, startHealth);
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = health.getHealth ();
		healthRatio = (currentHealth/maxHealth);
	}
}
