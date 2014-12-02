using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public float health = 10;
	public float damage = 150; //dps

	public void Quench(float amt) {
		health -= amt;
	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("Player")) {
			PlayerScript ps = other.GetComponent<PlayerScript>();
			ps.Damage(damage * Time.deltaTime);
		}

	}

	void Update() {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
	}
}
