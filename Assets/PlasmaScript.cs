using UnityEngine;
using System.Collections;

public class PlasmaScript : MonoBehaviour {

	public GameObject groundFire;
	public GameObject wallFire;

	Vector3 velocity;

	void Awake() {
		velocity = new Vector3 (0, Random.Range (-1f, -3.5f));
		transform.Rotate (Random.Range (0, 60f), 0f, Random.Range (0, 60f));
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Floor"))
			Instantiate (groundFire, transform.position, new Quaternion());
		else if (!other.CompareTag ("Ceiling")) //dont start the ceiling on fire...
			Instantiate (wallFire, transform.position, new Quaternion());
		Destroy (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = transform.position + transform.rotation * velocity * Time.deltaTime;
		transform.position = newPos;
		if (newPos.y <= 0)
			Destroy (this.gameObject);
	}
}
