using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public float health = 10;
	public float damage = 150; //dps

	public GameObject floorFire;
	public GameObject wallFire;

	public float spread = .01f; //spread percent per frame
	float pauseTime = 1.85f; //min seconds between spreads
	float cd = 2;

	float range = 4;

	public void Quench(float amt) {
		health -= amt;
	}

	void OnTriggerStay(Collider other) {
		HealthScript hp = other.GetComponent<HealthScript> ();
		if (hp != null) {
			hp.damage(damage * Time.deltaTime);
		}

	}

	void Update() {
		cd -= Time.deltaTime;
		if (cd <= 0 && Random.value < spread){
			cd = pauseTime;
			//check nearby area
			Quaternion rot = Quaternion.Euler (0, Random.Range (0, 360), 0);
			Vector3 target = (rot * new Vector3 (0, 0, range)) + new Vector3(transform.position.x, 0, transform.position.z);
			//raycast out 4
			RaycastHit hit;
			if (Physics.Raycast (transform.position + new Vector3(0, 0.2f, 0), rot * (new Vector3 (0, 0, 1)), out hit, range + 2)) {
				if (hit.transform.CompareTag("Wall")) {
					Vector3 point = new Vector3(transform.position.x, 1.5f, transform.position.z) + rot * new Vector3(0, 0, hit.distance - 0.5f);
					//ensure nothing excep the wall is there
					if (fireClearance (point))
						Instantiate (wallFire, point, wallFire.transform.rotation);
				}
			} else {
				if (fireClearance (target))
					Instantiate (floorFire, target, new Quaternion());
			}
		}	
		if (health <= 0) 
			Destroy(this.gameObject);
	}

	//check if there is already a fire within a 1m radius
	bool fireClearance(Vector3 point) {
		bool clear = true;
		bool floor = false;
		Collider[] objs = Physics.OverlapSphere (point, 1);
		for (int i = 0; i < objs.Length; i++) {
			if (objs[i].CompareTag ("Fire")) {
				clear = false;
			}
		}
		return clear;
	}
}
