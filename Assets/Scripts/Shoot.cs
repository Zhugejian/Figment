using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public AudioClip swipe;
	public string direction = "up";
	public GameObject bullet;
	public Vector3 spawnSpot = new Vector3(0,2,0);

	float scaler = 0.25f;

	void Start() {
	}

	void updateScaler(float log) {
		scaler = log;
	}

	void Update() {

		spawnSpot = this.gameObject.transform.position;

		if (Input.GetKeyUp (KeyCode.H)) {

			bullet.rigidbody.transform.transform.localScale = new Vector3(scaler, scaler, scaler);
//			bullet.rigidbody.AddForce(transform.forward * 1000 * scaler);
			audio.PlayOneShot (swipe);
			GameObject bulletSpawn = (GameObject)Instantiate (bullet, spawnSpot, transform.rotation);

		}
	}
}