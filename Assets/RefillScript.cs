using UnityEngine;
using System.Collections;

public class RefillScript : MonoBehaviour {

	public float capacity = 10f;
	float rotSpeed = 40; //degrees per second


	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			capacity -= other.GetComponent<PlayerScript>().refill(capacity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, rotSpeed*Time.deltaTime, 0);
		if (capacity <= 0)
			Destroy (this.gameObject);
	}
}
