using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{
	public float MeleeRange = 2;
	public float CollisionDiameter = 0.2f;
	public int DamageAmount = 9999;
	//public GameObject AttackPrefab;
	
	// Use this for initialization
	void Start()
	{
		
	}
	
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
					Damageable damage = hit.collider.gameObject.GetComponent(typeof(Damageable)) as Damageable;
					if (damage != null)
					{
						damage.TakeDamage(DamageAmount);
						return;
					}
				}
			}
		}
	}
}