using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private Animator anim;
	private AudioSource sound;

	public bool locked;
	private int proximityCount;
//	public bool locked;
//	public bool malfunction;
//	public bool broken;

	void Awake() {
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
		if (!locked) {
			anim.SetBool ("Open", proximityCount > 0);
			if (anim.IsInTransition(0) && !sound.isPlaying)
				sound.Play();
		}
	}

	public void Toggle() {
		if (!anim.IsInTransition(0) && !locked) {
			anim.SetBool ("Open", !anim.GetBool ("Open"));
			sound.Play ();
		}
	}
}