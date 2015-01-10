using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(HealthScript))]
public class PlayerScript : MonoBehaviour {

	HealthScript health;
	public float maxHealth = 100;
	public float speed = 6; // m/s
	public Text uiText;
	public float mouseSensitivity = 10;

	public bool UIup;

	//private vars
	CharacterController cc; //used to move and for physics
	CamScript cam; //used to move the camera up and down
	ExtinguisherScript extinguisher; //used to control the extinguisher
	
	// Use this for initialization
	void Start () {
		health = GetComponent<HealthScript>();
		health.initialize (maxHealth, maxHealth);
		cc = GetComponent<CharacterController> ();
		cam = Camera.main.GetComponent<CamScript> ();
		extinguisher = GetComponentInChildren<ExtinguisherScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int percent = (int)(health.getHealth () / maxHealth * 100);
		uiText.text = "HP: " + percent + "%";
		if (health.getHealth () > 0 && !UIup) {
			Motion();
			extinguisher.enabled = true;
		} else {
			extinguisher.firing = false;
			extinguisher.enabled = false;
		}

	}

	public float getHealth() {
		return health.getHealth ();
	}

	public void damage(float amt) {
		health.damage (amt);
	}

	public float refill(float amt) {
		return extinguisher.refill (amt);
	}

	void Motion() {
		//translation
		Vector3 velocity = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		velocity = velocity.normalized * speed + (Physics.gravity * Time.fixedDeltaTime);
		//rotation
		Vector3 look = new Vector3(0, Input.GetAxis ("Mouse X"), 0) * mouseSensitivity;
		transform.Rotate (look);
		cam.Rotate (Input.GetAxis ("Mouse Y") * mouseSensitivity);
		//move CC
		cc.Move(transform.rotation * velocity * Time.fixedDeltaTime);
	}
}
