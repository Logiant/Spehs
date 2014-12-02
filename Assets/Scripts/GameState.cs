using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public GameObject winScreen;
	public GameObject loseScreen;
	public GameObject console;

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
		winScreen.SetActive (win);
		loseScreen.SetActive (lose);
		console.SetActive (console);
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
}