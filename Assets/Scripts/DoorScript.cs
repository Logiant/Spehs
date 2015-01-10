using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HealthScript))]
public class DoorScript : MonoBehaviour {

	public float maxHealth = 1000;
	public float starthealth = 1000;

	private Animator anim;
	private AudioSource sound;
	HealthScript health;
	public bool locked;
	private int proximityCount;
	public bool malfunction;
	public bool broken;

	void Awake() {
		health = GetComponent<HealthScript> ();
		health.initialize (maxHealth, starthealth);
		anim = GetComponent<Animator> ();
		sound = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player"))
			proximityCount ++;
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player"))
			proximityCount --;
	}

	void Update() {
		checkStatus ();
		if (!locked && !malfunction && !broken) {
			anim.SetBool ("Open", proximityCount > 0);
			if (anim.IsInTransition(0) && !sound.isPlaying)
				sound.Play();
		} else if (malfunction && !anim.IsInTransition(0)) {
			anim.SetBool ("Open", !anim.GetBool ("Open"));
			sound.Play ();
		} else if (broken) {
			anim.SetBool ("Open", true);
		}
	}

	void checkStatus() {
		broken = false;
		malfunction = false;
		float hp = health.getHealth ();
		if (hp < .05f) {
			broken = true;
			malfunction= false;
		} else if (hp < maxHealth * 0.8f) {
			broken = false;
			malfunction = true;
		}
	}
}