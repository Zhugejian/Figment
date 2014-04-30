using UnityEngine;
using System.Collections;

public class PartAbsorby : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void ParticlesAppear () {
		Debug.Log ("partabyyah");
		particleSystem.Play ();
	}

	void ParticlesDisappear () {
		Debug.Log ("partabynah");
		particleSystem.Stop ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
