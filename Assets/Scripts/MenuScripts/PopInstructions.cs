using UnityEngine;
using System.Collections;

public class PopInstructions : MonoBehaviour {

	GameObject instructme;
	GameObject mainmenu;

	void OnMouseDown() {
		instructme.transform.position += Vector3.up * 100F;
		mainmenu.transform.position += Vector3.up * 100F;
	}

	// Use this for initialization
	void Start () {

		instructme = GameObject.Find ("Instructions");
		mainmenu = GameObject.Find ("MMenu");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
