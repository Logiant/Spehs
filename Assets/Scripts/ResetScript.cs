using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {

	public void ReloadLevel() {
		Application.LoadLevel (0);
	}
}
