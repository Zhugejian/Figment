using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	float distance = 100f;
	Transform myTransform; //current transform data of this bullet
	Transform source; //the bullet's source
	float scaler = 0.25f;
	float bulletsize = 0.25f;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			BroadcastMessage("EnableEnemyHitAnimatorFlag", "Wrath_Hit", SendMessageOptions.DontRequireReceiver);
			Damageable damage = other.collider.gameObject.GetComponent(typeof(Damageable)) as Damageable;
			if (damage != null)
			{
				for(int j = 0; j < other.collider.gameObject.transform.childCount; j++)
				{
					GameObject child = other.collider.gameObject.transform.GetChild(j).gameObject;
					child.SendMessage("EnableEnemyHitAnimatorFlag", "Wrath_Hit", SendMessageOptions.DontRequireReceiver);
				}
				damage.TakeDamage(bulletsize - 0.5f);
				Vector3 dir2 = other.collider.transform.position - transform.position;
				dir2.y = 0; // keep the force horizontal
				
				float AppliedForce = 250f * (bulletsize - 0.5f);
				
				if (other.collider.rigidbody){ // use AddForce for rigidbodies:
					other.collider.rigidbody.AddForce(dir2.normalized * AppliedForce);
				} else { // use a special script for character controllers:
					// try to get the enemy's script ImpactReceiver:
					ImpactReceiver script = other.collider.GetComponent< ImpactReceiver>();
					// if it has such script, add the impact force:
					if (script) script.AddImpact(dir2.normalized * AppliedForce);
					
				}
			}
		}
		Destroy (this.gameObject);
	}

//	void OnCollisionEnter(Collision something) {
//		Destroy (this.gameObject);
//	}

	// Use this for initialization
	void Start () {

		source = GameObject.FindWithTag("Player").transform;
		//scaler = avt2.getReadiedPower();
		rigidbody.transform.Rotate(0, 60, 0);
		rigidbody.AddForce(transform.forward * 1000 * 3);

		bulletsize = renderer.bounds.size.x;
//		rigidbody.transform.transform.localScale = new Vector3(scaler, scaler, scaler);
	}
	
	// Update is called once per frame
	void Update () {
		myTransform = transform;
		distance = Vector3.Distance(source.position, myTransform.position);
		if(distance >= 30f)
		{
			Destroy (this.gameObject);
		}
	}
}
