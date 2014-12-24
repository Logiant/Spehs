using UnityEngine;
using System.Collections;

public class PlasmaSpawnScript : MonoBehaviour {

	public GameObject plasmaBolt;
	public float cooldownTime;

	private float timer;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0) {
			timer = cooldownTime;
			Instantiate (plasmaBolt, transform.position, new Quaternion());
		}
	}
}
