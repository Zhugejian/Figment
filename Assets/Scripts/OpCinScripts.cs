using UnityEngine;
using System.Collections;

public class OpCinScripts : MonoBehaviour {

	GameObject gooey1;
	GameObject gooey2;
	GameObject gooey3;
	GameObject gooey4;

	GameObject intsong;

	void OnMouseDown()
	{
		Destroy(intsong);
		Application.LoadLevel ("OpeningCinematic2");

	}

	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds (3.0f);

		gooey1.transform.position += Vector3.up * 10F;
		gooey2.transform.position += Vector3.up * 10F;

		yield return new WaitForSeconds (3.0f);

		gooey2.transform.position += Vector3.up * 10F;
		gooey3.transform.position += Vector3.up * 10F;

		yield return new WaitForSeconds (2.0f);

		gooey3.transform.position += Vector3.up * 10F;
		gooey4.transform.position += Vector3.up * 10F;

		yield return new WaitForSeconds (5.0f);

		Destroy (intsong);
		Application.LoadLevel("OpeningCinematic2");
		
	}

	// Use this for initialization
	void Start () {
	
		gooey1 = GameObject.Find ("My mind");
		gooey2 = GameObject.Find ("I feel");
		gooey3 = GameObject.Find ("I can't");
		gooey4 = GameObject.Find ("Please put");

		intsong = GameObject.Find ("intro song");


		StartCoroutine(WaitForIt());

	}
	
	// Update is called once per frame
	void Update () {

	}
}
