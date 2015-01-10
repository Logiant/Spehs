using UnityEngine;
using System.Collections;

public class PlasmaSpawnScript : MonoBehaviour {

	public GameObject plasmaBolt;
	public float cooldownTime;
	float shieldMod = 10;
	float malEngineMod = 5;
	float engineMod = 10;

	private float timer;
	public ShieldGenScript shields;
	public EngineScript engines;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		float cooldown = cooldownTime + (shieldMod * (Mathf.Pow (shields.healthRatio, 2)));
		if (engines.isMalfunctioning) {
			cooldown += malEngineMod;
		} else if (!engines.isMalfunctioning && !engines.isBroken) {
			cooldown += engineMod;
		}
		if (timer >= (cooldown)){
			timer = 0;
			Instantiate (plasmaBolt, transform.position, new Quaternion());
		}
	}
}
