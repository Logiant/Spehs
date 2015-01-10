using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HealthScript))]
public class WeaponsBayScript : MonoBehaviour {

	public float maxHealth = 100;
	public float startingHealth = 100;

	HealthScript health;
	public float victoryTime = 240; //seconds before enemy ship is destroyed
	public bool malfunction;
	public bool broken;

	void Start () {
		health = GetComponent<HealthScript> ();
		health.initialize(maxHealth, startingHealth);
	}
	
	// Update is called once per frame
	void Update () {
		float hp = health.getHealth ();
		if (hp > maxHealth / 2) {
			broken = false;
			malfunction = false;
		} else if (hp > maxHealth / 3) {
			broken = false;
			malfunction = true;
		} else {
			broken = true;
			malfunction = false;
		}
		if (!broken && !malfunction) {
			victoryTime -= Time.deltaTime;
		} else if (malfunction) {
			victoryTime -= Time.deltaTime / 2f;
		}
	}
}
