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
		string curr_level = Application.loadedLevelName;
		if ((curr_level == "Game Over") || (curr_level == "Victory"))
		{
			curr_health = 200f;
		}
	}

	void OnLevelWasLoaded(int level)
	{
		if (level < 6) 
		{
			if((Application.loadedLevelName != "OpeningCinematic") && (Application.loadedLevelName != "OpeningCinematic2") && (Application.loadedLevelName != "Instructions") && (Application.loadedLevelName != "MainMenu"))
			{
			    GameObject obj = GameObject.FindGameObjectWithTag("Player");
			    obj.SendMessage("updateHealth", curr_health, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public void updateCurrHealth(float tag)
	{
		Debug.Log ("receiving" + curr_health);
		curr_health = tag;
	}
}
