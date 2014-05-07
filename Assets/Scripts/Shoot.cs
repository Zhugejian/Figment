using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public string direction = "up";
	public GameObject bullet;
	public Vector3 spawnSpot = new Vector3(0,2,0);

	void Start() {
	}
	
	void Update() {

		spawnSpot = this.gameObject.transform.position;

		if (Input.GetKeyUp (KeyCode.H)) {

			GameObject bulletSpawn = (GameObject)Instantiate (bullet, spawnSpot, transform.rotation);
		}
	}
}