using UnityEngine;
using System.Collections;

public class SupressorHeadScript : MonoBehaviour {

	public bool spouting;
	public GameObject propellant;

	Transform[] spouts;
	// Use this for initialization
	void Start () {
		spouts = transform.GetComponentsInChildren<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (spouting) {
			for (int i = 1; i < spouts.Length; i ++) {
				GameObject p = (GameObject)Instantiate (propellant, spouts[i].position, spouts[i].rotation);
				//rotate += 45 degrees
				float yRot = Random.Range (-45, 46);
				p.transform.Rotate (new Vector3(0, yRot, 0));
				p.rigidbody.velocity = p.transform.rotation * new Vector3(0, 0, Random.Range (0, 7f));

			}

		}
	}
}
