using UnityEngine;
using System.Collections;

public class TerminalScript : MonoBehaviour {

	public DoorScript door;
	public SupressionSystemScript suppressor;

	public GameState gameState;

	void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player") && Input.GetButtonDown ("Action")) {
			gameState.EnterConsole (door, suppressor);
		}
	}
}