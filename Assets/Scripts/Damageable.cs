using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

	public bool isDamageable = true;
	public int Health = 10;

	public void TakeDamage(int amount)
	{
		Health = Health - amount;
		//renderer.material.color = Color.red;
		//renderer.material.mainTexture = Texture.Opaque;
		//yield WaitForSeconds(.1);
		//renderer.material.color = Color.white;
	}
	public void DealDamage(int amount, Damageable d)
	{
		d.Health = d.Health - amount;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Health == 0)
		{
			Destroy(this.gameObject);
		}
	}

	public int getHealth()
	{
		return Health;
	}
}
