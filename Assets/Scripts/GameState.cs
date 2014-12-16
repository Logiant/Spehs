using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject winScreen;
	public GameObject loseScreen;

	public PlayerScript player;

	bool lose;
	bool win;
	bool inConsole;

	ConsoleHandler consoleHandler;

	// Use this for initialization
	void Start () {
		consoleHandler = GetComponentInChildren<ConsoleHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		winScreen.SetActive (win);
		loseScreen.SetActive (lose);
		consoleHandler.Show (inConsole);
		CheckWin ();
		player.UIup = false;
		if (win || lose || inConsole) {
			player.UIup = true;
		}
	}

	public void EnterConsole(DoorScript door, SupressionSystemScript suppressor) {
		inConsole = true;
		consoleHandler.Show(true);
		consoleHandler.SetComponents (door, suppressor);
	}

	void CheckWin() {
		GameObject[] fires = GameObject.FindGameObjectsWithTag ("Fire");
		if (player.health <= 0) {
			win = false;
			lose = true;
			inConsole = false;
		} else if (fires.Length == 0) {
			win = true;
			inConsole = false;
		}
	}

	public void closeConsole() {
		inConsole = false;
		consoleHandler.Show (false);
	}
}