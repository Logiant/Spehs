using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject winScreen;
	public GameObject loseScreen;

	PlayerScript player;

	bool lose;
	bool win;
	bool inConsole;

	HelmScript helm;
	WeaponsBayScript weapons;
	ConsoleHandler consoleHandler;

	// Use this for initialization
	void Start () {
		consoleHandler = GetComponentInChildren<ConsoleHandler> ();
		weapons = GameObject.FindGameObjectWithTag ("WeaponSystem").GetComponent<WeaponsBayScript> ();
		helm = GameObject.FindGameObjectWithTag ("HelmSystem").GetComponent<HelmScript> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();
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
		if (weapons.victoryTime <= 0) {
			GameObject[] fires = GameObject.FindGameObjectsWithTag ("Fire");
			if (fires.Length == 0) {
				win = true;
				inConsole = false;
			}
		} if (player.getHealth() <= 0 || helm.lose) {
			win = false;
			lose = true;
			inConsole = false;
		}
	}

	public void closeConsole() {
		inConsole = false;
		consoleHandler.Show (false);
	}
}