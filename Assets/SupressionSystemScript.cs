using UnityEngine;
using System.Collections;

public class SupressionSystemScript : MonoBehaviour {
	
	public float maxPropellant = 10f;
	public bool running;
	public float drainRate = 0.75f; //drain rate per spout
	public float propellant;

	SupressorHeadScript[] spouts;


	// Use this for initialization
	void Start () {
		spouts = GetComponentsInChildren<SupressorHeadScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (running)
			propellant -= (drainRate * spouts.Length * Time.deltaTime);


		running = running && propellant > 0;

		for (int i = 0; i < spouts.Length; i++) {
			spouts[i].spouting = running;
		}
	}
}
