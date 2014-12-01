using UnityEngine;
using System.Collections;

public class ExtinguisherScript : MonoBehaviour {

	public bool firing;
	public float propellant = 10f;
	public float decay = 1f; //units per second
	ParticleRenderer particles;

	void Start() {
		particles = GameObject.Find ("Particles").GetComponent<ParticleRenderer> ();
	}

	void Update() {
		if (firing) {
			propellant -= decay * Time.deltaTime;
		}
		firing = firing && (propellant > 0);
		if (firing) {

		} if (Input.GetButtonDown ("Fire1")) {
			firing = !firing;
		}
		particles.enabled = firing;
	}

	void OnTriggerEnter(Collider other) {
		if (firing && other.CompareTag ("Fire") ){
			Destroy(other.gameObject);
		}
	}
}
