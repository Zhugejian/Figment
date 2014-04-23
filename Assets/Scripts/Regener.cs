using UnityEngine;
using System.Collections;

public class Regener : MonoBehaviour {

	void OnTriggerEnter()
	{
		Debug.Log ("asd;lkf");
		GameObject obj = GameObject.FindGameObjectWithTag("HealthCube");
		obj.SendMessage("updateCurrHealth", 200f, SendMessageOptions.DontRequireReceiver);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
