using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;

public class CharacterActions : MonoBehaviour {
	string character =@"";
	string text = @"</b>- We are <b>not</b> amused";
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		bool Fire1=Input.GetKeyDown ("Fire1");
		bool Fire2=Input.GetKeyDown ("Fire2");
		bool Fire3=Input.GetKeyDown ("Fire3");
		bool Jump=Input.GetKeyDown ("Jump");
		bool Submit=Input.GetKeyDown ("Submit");
		bool Cancel=Input.GetKeyDown ("Cancel");

	}
}
