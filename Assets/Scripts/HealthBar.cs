using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public int something = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Damageable damage = this.gameObject.GetComponent(typeof(Damageable)) as Damageable;
		//float bar = this.gameObject.Health;
		int something = 1;
		if (damage != null)
		{
			something = damage.getHealth();
		}
		renderer.transform.localScale = new Vector3 (something, transform.localScale.y, transform.localScale.z);
	}
}
