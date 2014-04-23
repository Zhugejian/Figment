using UnityEngine;
using System.Collections;

public class HealthUpdate : MonoBehaviour 
{
	float curr_health = 200;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnLevelWasLoaded(int level)
	{
		if (level < 6) 
		{
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			obj.SendMessage("updateHealth", curr_health, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void updateCurrHealth(float tag)
	{
		curr_health = tag;
	}
}
