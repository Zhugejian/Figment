using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{
	public float MeleeRange = 2;
	public float CollisionDiameter = 0.2f;
	public int DamageAmount = 9999;
	//public GameObject AttackPrefab;
	public float force = 500; // adjust the impact force
	
	// Use this for initialization
	void Start()
	{
		
	}

//	void OnTriggerEnter(Collider other){
//		Vector3 dir = other.transform.position - transform.position;
//		dir.y = 0; // keep the force horizontal
//		if (other.rigidbody){ // use AddForce for rigidbodies:
//			other.rigidbody.AddForce(dir.normalized * force);
//		} else { // use a special script for character controllers:
//			// try to get the enemy's script ImpactReceiver:
//			ImpactReceiver script = other.GetComponent< ImpactReceiver>();
//			// if it has such script, add the impact force:
//			if (script) script.AddImpact(dir.normalized * force);
//		}
//	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			for (int i = 0; i<5; i++)
			{
				Vector3 dir = transform.forward;
				dir += Random.insideUnitSphere * CollisionDiameter;
				dir.Normalize();
				
				//Debug.DrawRay(transform.position, transform.position + dir * MeleeRange);
				
				RaycastHit[] hits = Physics.RaycastAll(transform.position, dir, MeleeRange);
				foreach (RaycastHit hit in hits)
				{
					GameObject obj = hit.collider.gameObject;


					//if (obj.GetComponent(typeof(Player)) != null) continue;

					Damageable damage = hit.collider.gameObject.GetComponent(typeof(Damageable)) as Damageable;
					if (damage != null)
					{
						for(int j = 0; j < hit.collider.gameObject.transform.childCount; j++)
						{
							GameObject child = hit.collider.gameObject.transform.GetChild(j).gameObject;
							child.SendMessage("EnableEnemyHitAnimatorFlag", "Hitted", SendMessageOptions.DontRequireReceiver);
						}
						damage.TakeDamage(DamageAmount);
						Vector3 dir2 = hit.collider.transform.position - transform.position;
						dir2.y = 0; // keep the force horizontal
						if (hit.collider.rigidbody){ // use AddForce for rigidbodies:
							hit.collider.rigidbody.AddForce(dir2.normalized * force);
						} else { // use a special script for character controllers:
							// try to get the enemy's script ImpactReceiver:
							ImpactReceiver script = hit.collider.GetComponent< ImpactReceiver>();
							// if it has such script, add the impact force:
							if (script) script.AddImpact(dir2.normalized * force);

						}
						return;
					}
				}
			}
		}
	}
}