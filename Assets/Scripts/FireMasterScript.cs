﻿using UnityEngine;
using System.Collections;

public class FireSpawnScript : MonoBehaviour {

	public GameObject[] fireSpawns;
	public float cooldownTime;
	float shieldMod = 10;
	float malEngineMod = 5;
	float engineMod = 10;
	
	private float timer;
	public ShieldGenScript shields;
	public EngineScript engines;
	
	
	// Use this for initialization
	void Start () {
		fireSpawns = GameObject.FindGameObjectsWithTag ("FireSpawner");
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
			//int index = Random.Range (0, fireSpawns.GetLength());
			//fireSpawns[index].create fire
		}
	}
}
