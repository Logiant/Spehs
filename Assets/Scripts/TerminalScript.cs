using UnityEngine;
using System.Collections;

public class TerminalScript : MonoBehaviour {

	public DoorScript door;

	void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player") && Input.GetButtonDown ("Action")) {
			door.Toggle();
		}
	}
}