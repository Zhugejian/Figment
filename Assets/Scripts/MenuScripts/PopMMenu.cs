using UnityEngine;
using System.Collections;

public class PopMMenu : MonoBehaviour {
	
	GameObject instructme;
	GameObject mainmenu;
	
	void OnMouseDown() {
		instructme.transform.position += Vector3.down * 100F;
		mainmenu.transform.position += Vector3.down * 100F;
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
