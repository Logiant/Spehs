using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	float maxHealth;
	public float health = 100;
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
		maxHealth = health;
		cc = GetComponent<CharacterController> ();
		cam = Camera.main.GetComponent<CamScript> ();
		extinguisher = GetComponentInChildren<ExtinguisherScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		health = Mathf.Clamp (health, 0, maxHealth);
		int percent = (int)(health / maxHealth * 100);
		uiText.text = "HP: " + percent + "%";
		if (health > 0 && !UIup) {
			Motion();
		} else {
			extinguisher.enabled = false;
		}

	}
	
	public void Damage(float amt) {
		health -= amt;
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
