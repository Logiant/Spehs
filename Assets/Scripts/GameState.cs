using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	PlayerScript player;

	bool lose;
	bool win;
	bool inConsole;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ();;
	}
	
	// Update is called once per frame
	void Update () {
		CheckWin ();
	}


	void CheckWin() {
		GameObject[] fires = GameObject.FindGameObjectsWithTag ("Fire");
		if (player.health <= 0) {
			win = false;
			lose = true;
		} else if (fires.Length == 0) {
			win = true;
		}
	}

	void OnGUI() {
		if (lose) {
			WinGUI();
		}else if (win) {
			LoseGUI();
		} else if(inConsole) {
			Console();
		}
	}

	void Console() {

	}
	void WinGUI() {

	}
	void LoseGUI() {

	}
}