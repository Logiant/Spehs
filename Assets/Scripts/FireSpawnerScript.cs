using UnityEngine;
using System.Collections;

public class FireSpawnerScript : MonoBehaviour {
	public GameObject groundFire;

	void spawnFire(){
		Instantiate (groundFire, transform.position, new Quaternion());
	}
}
