﻿using UnityEngine;
using System.Collections;

public class PickBat : MonoBehaviour {

	//public ItemUpdate IU;

	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player") {
			GameObject picker = GameObject.Find ("Item Cube");
			picker.SendMessage("itemSetter", "bbat", SendMessageOptions.DontRequireReceiver);
			//IU.itemSetter("bbat");
		}
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
