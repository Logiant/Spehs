using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {

	float rotationY;
	float yMin = -60;
	float yMax = 60;

	public void Rotate(float target) {
		rotationY += target;
	}

	// Update is called once per frame
	void Update () {
		rotationY = Mathf.Clamp (rotationY, yMin, yMax);
		transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}
