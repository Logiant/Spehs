using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	private Animator anim;
	private AudioSource sound;
	

	void Awake() {
		anim = GetComponent<Animator> ();
		sound = GetComponent<AudioSource> ();
	}

	public void Toggle() {
		if (!anim.IsInTransition(0)) {
			anim.SetBool ("Open", !anim.GetBool ("Open"));
			sound.Play ();
		}
	}
}