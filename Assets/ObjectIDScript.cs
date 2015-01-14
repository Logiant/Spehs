using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectIDScript : MonoBehaviour {

	public Text descriptor;
	public int rayDist = 5;
	Vector2 screenSize;

	// Use this for initialization
	void Start () {
		screenSize = new Vector2 (Screen.width / 2f, Screen.height / 2f);
	}
	
	// Update is called once per frame
	void Update () {
		descriptor.text = "";
		RaycastHit hit;
		Physics.Raycast (Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 1)), Camera.main.transform.forward,out hit, rayDist);
		if (hit.collider != null && !hit.collider.CompareTag("Fire")) {
			descriptor.text = hit.collider.gameObject.name;
			if (hit.collider.gameObject.GetComponent<HealthScript>() != null) {
				HealthScript h = hit.collider.gameObject.GetComponent<HealthScript>();
				descriptor.text += "\n" + (Mathf.RoundToInt(h.getHealthPercent() * 100) / 100f)*100 + "%";
			}
		}
	}
}
