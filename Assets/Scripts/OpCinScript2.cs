﻿using UnityEngine;
using System.Collections;

public class OpCinScript2 : MonoBehaviour {

	//GameObject intsong;
	GameObject back;

	void OnMouseDown()
	{
		//Destroy (intsong);
		Application.LoadLevel ("TutorialRoom1");
	}

	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds (10.0f);

		back.transform.position += Vector3.back * 10F;

		yield return new WaitForSeconds (1.0f);

		//Destroy (intsong);
		Application.LoadLevel ("TutorialRoom1");
	}

	// Use this for initialization
	void Start ()
	{
		//intsong = GameObject.Find ("intro song");
		back = GameObject.Find ("Background");
	    StartCoroutine(WaitForIt());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
