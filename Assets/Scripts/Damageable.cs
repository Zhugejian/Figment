using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {

	public bool isDamageable = true;
	public int Health = 10;
	public bool isPlayer = true;
	public bool isRMemory = false;
	public static bool chestOpened = false;
	public static int CurrentLevel;

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
		if(Input.GetKeyDown(KeyCode.F))
		{
			if(Application.loadedLevelName == "Room2")
			{
				CurrentLevel = 2;
			}
			else if ((Application.loadedLevelName == "Room3L") || (Application.loadedLevelName == "Room3R"))
			{
				CurrentLevel = 3;
			}
			else if (Application.loadedLevelName == "Room4")
			{
				CurrentLevel = 4;
			}
			else
			{
				CurrentLevel = 1;
			}
			//CurrentLevel = Application.loadedLevelName;
			Debug.Log(CurrentLevel);
			chestOpened = true;
		}

		if (isPlayer) {
						if (Health <= 0) {
								if (chestOpened) {
										if (CurrentLevel == 2) {
												Application.LoadLevel ("Room2");
										} else if (CurrentLevel == 3) {
												Application.LoadLevel ("Room3");
										} else if (CurrentLevel == 4) {
												Application.LoadLevel ("Room4");
										} else {
												Application.LoadLevel ("Start Room Left Door");
										}
										chestOpened = false;
								} else {
										Application.LoadLevel ("Game Over");
								}
						}
		}

		else if (isRMemory)
		{
			if (Health <= 0)
			{
				Application.LoadLevel ("Victory");
			}
		}

		else if(Health <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	public int getHealth()
	{
		return Health;
	}
}
