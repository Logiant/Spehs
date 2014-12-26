using UnityEngine;
using System.Collections;

public class ConsoleHandler : MonoBehaviour {

	GameState game;
	DoorScript door; //reassigned when console opens
	SupressionSystemScript suppressor; //reassigned when console opens
	public GameObject ConsoleUI;

	void Awake() {
		game = GetComponentInParent<GameState> ();
	}

	public void SetComponents(DoorScript door, SupressionSystemScript suppressor) {
		this.door = door;
		this.suppressor = suppressor;
	}


	public void ToggleLock() {
		door.locked = !door.locked;
	}

	public void ToggleSuppression() {
		suppressor.running = !suppressor.running;
	}

	public void CloseTerminal() {
		game.closeConsole();
	}

	public void Show(bool show) {
		ConsoleUI.SetActive (show);
	}
}
