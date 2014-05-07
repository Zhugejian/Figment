using UnityEngine;
using System.Collections;

public class PickTick : MonoBehaviour {
	
	void OnTriggerEnter(Collider player) {
		if (player.tag == "Player") {
			GameObject picker = GameObject.Find ("Item Cube");
			picker.SendMessage("itemSetter", "tticket", SendMessageOptions.DontRequireReceiver);
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
