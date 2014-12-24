using UnityEngine;
using System.Collections;

public class MedicalScript : MonoBehaviour {

	public float healRate = 10f;

	bool healing;
	ParticleSystem particles;
	PlayerScript player;

	void Awake() {
		particles = GetComponentInChildren<ParticleSystem> ();
	}
	// Use this for initialization
	void OnTriggerEnter (Collider other) {
		if ( other.CompareTag("Player") ) {
			healing = true;
			if (player == null) {
				player = other.GetComponent<PlayerScript>();
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if ( other.CompareTag("Player") ) {
			healing = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (healing) {
			if (!particles.isPlaying)
				particles.Play ();
			player.Damage (-healRate * Time.deltaTime);
		} else if (particles.isPlaying)
			particles.Stop ();
	}
}
