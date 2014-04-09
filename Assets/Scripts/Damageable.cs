using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

	public bool isDamageable = true;
	public int Health = 10;
	public bool isPlayer = true;
	public static bool chestOpened = false;

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
		if (Application.loadedLevelName.Equals ("Room2"))
		{
			if(Input.GetKeyDown(KeyCode.F))
			{
				chestOpened = true;
			}
		}
		if (isPlayer)
		{
			if(Health == 0)
			{
				if(chestOpened)
				{
					Application.LoadLevel("Room2");
					chestOpened = false;
				}
				else
				{
					Application.LoadLevel ("Game Over");
				}
			}
		}

		else if(Health == 0)
		{
			Destroy(this.gameObject);
		}
	}

	public int getHealth()
	{
		return Health;
	}
}
