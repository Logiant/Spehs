using UnityEngine;
using System.Collections;

public class PlasmaScript : MonoBehaviour {

	public GameObject groundFire;
	public GameObject wallFire;

	Vector3 velocity;

	void Awake() {
		velocity = new Vector3 (0, Random.Range (-9f, -15f));
		transform.Rotate (Random.Range (0, 60f), 0f, Random.Range (0, 60f));
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Floor")){
			Instantiate (groundFire, transform.position, new Quaternion());
		}else if (!other.CompareTag ("Ceiling") && !other.isTrigger){ //dont start the ceiling on fire...
			Vector3 newPos = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
			Instantiate (wallFire, newPos, wallFire.transform.rotation);
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = transform.position + transform.rotation * velocity * Time.deltaTime;
		transform.position = newPos;
		if (newPos.y <= 0)
			Destroy (this.gameObject);
	}
}
