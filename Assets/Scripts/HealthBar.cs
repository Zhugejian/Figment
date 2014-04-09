using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public float something = 200f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Damageable damage = this.gameObject.GetComponent(typeof(Damageable)) as Damageable;
		//float bar = this.gameObject.Health;
//		if (damage != null)
//		{
//			something = damage.getHealth();
//		}
		renderer.transform.localScale = new Vector3 (something/200, transform.localScale.y, transform.localScale.z);
		Debug.Log (something);
//		if (something > 0)
//		{
//			something = something - 1f;
//		}
	}
}
