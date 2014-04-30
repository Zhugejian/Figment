using UnityEngine;
using System.Collections;

public class Damageable : MonoBehaviour {
	public bool isDamageable = true;
	public float Health = 200;
	public bool isPlayer = true;
	//public bool isWrath = false;
	public bool isRMemory = false;
	public static bool chestOpened = false;
	public static int CurrentLevel;

	public void TakeDamage(float amount)
	{
		Health = Health - amount;
		if (isPlayer) 
		{
			GameObject obj = GameObject.FindGameObjectWithTag("HealthCube");
		    obj.SendMessage("updateCurrHealth", Health, SendMessageOptions.DontRequireReceiver);
		}
		//renderer.material.color = Color.red;
		//renderer.material.mainTexture = Texture.Opaque;
		//yield WaitForSeconds(.1);
		//renderer.material.color = Color.white;
	}
	public void DealDamage(float amount, Damageable d)
	{
		d.Health = d.Health - amount;
//		if(isWrath)
//		{
//			BroadcastMessage("EnableEnemyHitAnimatorFlag", "Wrath_Hit", SendMessageOptions.DontRequireReceiver);
//		}
	}
	
	// Use this for initialization
	void Start () {
	
	}

	void GameOver()
	{
		Application.LoadLevel ("Game Over");
	}

	IEnumerator WaitForIt()
	{
		yield return new WaitForSeconds (1.0f);

		GameOver ();

	}

	void Victory()
	{
		Application.LoadLevel ("Victory");
	}

	IEnumerator WaitForIt2()
	{
		yield return new WaitForSeconds (0.7f);
		
		Victory ();
		
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

		if (isPlayer)
		{
			if (Health <= 0)
			{
				//temp fix
				GameObject obj = GameObject.FindGameObjectWithTag("HealthCube");
				obj.SendMessage("updateCurrHealth", Health, SendMessageOptions.DontRequireReceiver);

				if (chestOpened)
				{
					SendMessageUpwards("updateHealth", 200f, SendMessageOptions.DontRequireReceiver);

					if (CurrentLevel == 2)
					{
						Application.LoadLevel ("Room2");
					}
					else if (CurrentLevel == 3)
					{
					    Application.LoadLevel ("Room3");
					}
					else if (CurrentLevel == 4)
					{
						Application.LoadLevel ("Room4");
					}
					else
					{
						Application.LoadLevel ("Start Room Left Door");
					}
				    chestOpened = false;
				}
				else
				{
					//GameObject plyr = GameObject.FindGameObjectWithTag("Player");
					BroadcastMessage("EnablePlayerDeathAnimatorFlag", "Killed", SendMessageOptions.DontRequireReceiver);
					StartCoroutine(WaitForIt());
					//Application.LoadLevel ("Game Over");
				}
			}
		}

		else if (isRMemory)
		{
			if (Health <= 0)
			{
				BroadcastMessage("EnableOpenChestAnimatorFlag", "Opened", SendMessageOptions.DontRequireReceiver);
				StartCoroutine(WaitForIt2());
				//Application.LoadLevel ("Victory");
			}
		}

		else if(Health <= 0)
		{
			Destroy(this.gameObject);
		}
	}

	public float getHealth()
	{
		return Health;
	}

	public void updateHealth(float tag)
	{
		Health = tag;
	}
}
