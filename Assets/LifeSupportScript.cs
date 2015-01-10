using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HealthScript))]
public class LifeSupportScript : MonoBehaviour {

	public float maxHealth;
	public float startingHealth;

	public float oxegynLevel = 100; //percent
	float oxegynGain = 2; //percent per second

	HealthScript health;

	// Use this for initialization
	void Start () {
		health.initialize(maxHealth, startingHealth);
	}
	
	// Update is called once per frame
	void Update () {
		float hp = health.getHealth ();
		if (hp < maxHealth / 3) { //broken
			oxegynLevel -= oxegynGain * Time.deltaTime;
		} else if (hp > maxHealth / 2) {
			oxegynLevel += oxegynGain * Time.deltaTime;
		}
		oxegynLevel = Mathf.Clamp (oxegynLevel, 0, 100);
	}
}
