using UnityEngine;
using System.Collections;

public class PartAbsorby : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void ParticlesAppear () {
		particleSystem.Play ();
	}

	public void ParticlesDisappear () {
		particleSystem.Stop ();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
