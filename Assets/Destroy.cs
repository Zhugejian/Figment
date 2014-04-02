using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	int Health = 3;

    void Update () {

    	if (Input.GetMouseButtonDown(0)) {
		    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		    RaycastHit hit;
		    if(Physics.Raycast(ray, out hit)) {
				if(hit.collider.gameObject.name == "Enemy") {
					Health--;
					if (Health == 0) {
						Destroy(this.gameObject);
					}
				}
    		}
	    }
    }
}