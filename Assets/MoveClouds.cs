using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour {
	public Vector3 speed = new Vector3(1, 0, 1);
	public float wrapX = 1100f;
	public float wrapZ = 1100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p = transform.position;
		p += speed;
		if (p.x > wrapX) {
			p.x -= wrapX;
		}
		if (p.z > wrapZ) {
			p.z -= wrapZ;
		}
		transform.position = p;

	}
}
