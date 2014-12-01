using UnityEngine;
using System.Collections;

public class ExtinguisherScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Fire") ){
			Debug.Log (other.tag);
			Destroy(other.gameObject);
		}
	}
}
