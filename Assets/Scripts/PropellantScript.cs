using UnityEngine;
using System.Collections;

public class PropellantScript : MonoBehaviour {

	public float damage = 1;

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (!other.isTrigger && !other.CompareTag ("Propellant") && !other.CompareTag ("Player"))
			Destroy(this.gameObject);
		if (other.CompareTag ("Fire")) {
			FireScript fs = other.GetComponent<FireScript>();
			fs.Quench(damage);
		}
	}
}
