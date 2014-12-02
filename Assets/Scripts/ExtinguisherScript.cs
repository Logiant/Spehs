using UnityEngine;
using System.Collections;

public class ExtinguisherScript : MonoBehaviour {

	public bool firing;
	public float propellantLeft = 10f;
	public float decay = 1f; //units per second
	public float muzzleVelocity = 7f;
	public GameObject propellant;
	public CharacterController player;

	public Transform spawn;

	private float currentRot = 0;
	private float dRot = 3;
	private float maxRot = 10;
//	ParticleRenderer particles;

	void Start() {
//		particles = GameObject.Find ("Particles").GetComponent<ParticleRenderer> ();
	}

	void Update() {
		if (firing) {
			propellantLeft -= decay * Time.deltaTime;
			currentRot += dRot;
			if (currentRot > maxRot)
				currentRot -= 2*maxRot;
			Quaternion rot = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + currentRot, transform.rotation.eulerAngles.z);
			GameObject p = (GameObject) Instantiate (propellant, spawn.position, rot);
			p.rigidbody.velocity = p.transform.rotation * new Vector3(0, 0, muzzleVelocity) + player.velocity;
			//create propellant
		}
		if (Input.GetButtonDown ("Fire1")) {
			firing = !firing;
		}
		firing = firing && (propellantLeft > 0);
//		particles.enabled = firing;
	}

	void OnTriggerEnter(Collider other) {
		if (firing && other.CompareTag ("Fire") ){
			Destroy(other.gameObject);
		}
	}
}
