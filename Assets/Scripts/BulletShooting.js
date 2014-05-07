#pragma strict

function Start () {
	rigidbody.transform.Rotate(0, 60, 0);
}

function Update () {
	rigidbody.transform.transform.localScale = new Vector3(2, 2, 2);
//	rigidbody.transform.Rotate(0, 60, 0);
	rigidbody.AddForce(transform.forward * 5000);
}