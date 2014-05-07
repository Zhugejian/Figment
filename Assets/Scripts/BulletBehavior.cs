using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	
	public AvatarCtrl2 avt2;
	public float scaler;

	// Use this for initialization
	void Start () {
		scaler = avt2.getReadiedPower();
		Debug.Log (scaler);
		rigidbody.transform.Rotate(0, 60, 0);
		rigidbody.AddForce(transform.forward * 1000 * scaler);
		rigidbody.transform.transform.localScale = new Vector3(scaler, scaler, scaler);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
