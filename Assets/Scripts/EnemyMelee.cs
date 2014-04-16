using UnityEngine;
using System.Collections;

public class EnemyMelee : MonoBehaviour
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

	void OnTriggerEnter(Collider other){
		Vector3 dir = other.transform.position - transform.position;
		dir.y = 0; // keep the force horizontal
		if (other.rigidbody){ // use AddForce for rigidbodies:
			other.rigidbody.AddForce(dir.normalized * force);
		} else { // use a special script for character controllers:
			// try to get the enemy's script ImpactReceiver:
			ImpactReceiver script = other.GetComponent< ImpactReceiver>();
			// if it has such script, add the impact force:
			if (script) script.AddImpact(dir.normalized * force);
			Debug.Log ("getting hit now");
//			for(int i = 0; i < other.gameObject.transform.childCount; i++)
//			{
//				GameObject child = other.gameObject.transform.GetChild(i).gameObject;
//				child.SendMessage("EnableAnimatorFlag", "Hitted", SendMessageOptions.DontRequireReceiver);
//			}
			Debug.Log ("getting hit now again");
		}
	}

	// Update is called once per frame
	void Update()
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

				Damageable damage = hit.collider.gameObject.GetComponent(typeof(Damageable)) as Damageable;
				if (damage != null)
				{
					if(damage.isPlayer == true)
					{
					    //yield return new WaitForSeconds(0.1f);
						for(int j = 0; j < hit.collider.gameObject.transform.childCount; j++)
						{
							GameObject child = hit.collider.gameObject.transform.GetChild(j).gameObject;
							child.SendMessage("EnableAnimatorFlag", "GotHit", SendMessageOptions.DontRequireReceiver);
						}
						for(int k = 0; k < this.gameObject.transform.childCount; k++)
						{
							GameObject child = this.gameObject.transform.GetChild(k).gameObject;
							child.SendMessage("EnableEnemyAttackAnimatorFlag", "Attack", SendMessageOptions.DontRequireReceiver);
						}
					    damage.TakeDamage(DamageAmount);
					}
					return;// true;
				}
			
			}
		}
	}
	
}