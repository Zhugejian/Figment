using UnityEngine;
using System.Collections;

public class Destroy2 : MonoBehaviour {
	// Update is called once per frame
	void Update () {	
	}
	void OnMouseDown(){
		// this object was clicked - do something
		Destroy (this.gameObject);
	}
}
