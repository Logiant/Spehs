using UnityEngine;
using System.Collections;

public class EngineScript : MonoBehaviour {

	public float maxHealth = 100;
	public float startHealth = 100;
	float currentHealth;

	HealthScript health;

	public bool isBroken;
	public bool isMalfunctioning;

	// Use this for initialization
	void Start () {
		health.initialize(maxHealth, startHealth);
	}
	
	// Update is called once per frame
	void Update () {
		currentHealth = health.getHealth ();
		if(currentHealth > .5*maxHealth){
			isBroken = false;
			isMalfunctioning = false;
		}
		else if(currentHealth <= 0){
			isBroken= true;
			isMalfunctioning = false;
		}else{
			isBroken = false;
			isMalfunctioning = true;
		}
	}
}
