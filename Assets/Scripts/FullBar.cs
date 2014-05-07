using UnityEngine;
using System.Collections;

public class FullBar : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		renderer.transform.localScale = new Vector3 (1, transform.localScale.y, transform.localScale.z);
	}
}
