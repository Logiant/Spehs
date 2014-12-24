using UnityEngine;
using System.Collections;

public class ExtinguisherScript : MonoBehaviour {

	public bool firing;
	public float maxPropellant = 10f;
	public float propellantLeft = 10f;
	public float decay = 1f; //units per second
	public float muzzleVelocity = 7f;
	public GameObject propellant;
	public CharacterController player;

	public Transform spawn;

	private float currentRot = 0;
	private float dRot = 3;
	private float maxRot = 10;

	private Transform needle; //rotate about Y as the extinguisher empties
	private float fullAngle = 0f;
	private float emptyAngle = -130f;
//	ParticleRenderer particles;

	void Start() {
//		particles = GameObject.Find ("Particles").GetComponent<ParticleRenderer> ();
		needle = GameObject.Find ("Needle").transform;
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
		float newAngle = Mathf.Lerp (emptyAngle, fullAngle, propellantLeft/maxPropellant);
		needle.localRotation = Quaternion.Euler (needle.localEulerAngles.x, newAngle, needle.localEulerAngles.z);
	}

	public float refill(float amt) {
		float used = maxPropellant - propellantLeft;
		propellantLeft = Mathf.Min (maxPropellant, propellantLeft + amt);
		return used;
	}

	void OnTriggerEnter(Collider other) {
		if (firing && other.CompareTag ("Fire") ){
			Destroy(other.gameObject);
		}
	}
}
