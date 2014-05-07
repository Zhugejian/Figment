using UnityEngine;
using System.Collections;

public class ItemUpdate : MonoBehaviour 
{

	public GameObject greenScreen;
	public Vector3 spawnSpot = new Vector3(0,2,0);

	bool bat = false;
	bool cap = false;
	bool board = false;
	bool sweater = false;
	bool ticket = false;
	bool pencil = false;


	public void itemSetter(string log) {
		if (log.Equals ("bbat")) {
			bat = true;
		} else if (log.Equals ("dcap")) {
			cap = true;
		} else if (log.Equals ("fboard")) {
			board = true;
		} else if (log.Equals ("gsweater")) {
			sweater = true;
		} else if (log.Equals ("tticket")) {
			ticket = true;
		} else if (log.Equals ("spencil")) {
			pencil = true;
		}
	}

	public bool dropItem() {
		Destroy(GameObject.Find("greenScreen(Clone)"));
		if (GameObject.Find ("greenScreen(Clone)") == null) {
			return false;
		}
		return true;
	}
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bat) {
			spawnSpot = new Vector3 (0.016f, 0.92f, 0f);
			GameObject itemHeld0 = (GameObject)Instantiate (greenScreen, spawnSpot, transform.rotation);
			bat = false;
		} else if (cap) {
			spawnSpot = new Vector3 (0.09f, 0.82f, 0f);
			GameObject itemHeld1 = (GameObject)Instantiate (greenScreen, spawnSpot, transform.rotation);
			cap = false;
		} else if (board) {
			spawnSpot = new Vector3 (0.02f, 0.63f, 0f);
			GameObject itemHeld2 = (GameObject)Instantiate (greenScreen, spawnSpot, transform.rotation);
			board = false;
		} else if (sweater) {
			spawnSpot = new Vector3 (0.024f, 0.765f, 0f);
			GameObject itemHeld3 = (GameObject)Instantiate (greenScreen, spawnSpot, transform.rotation);
			sweater = false;
		} else if (ticket) {
			spawnSpot = new Vector3 (0.085f, 0.67f, 0f);
			GameObject itemHeld4 = (GameObject)Instantiate (greenScreen, spawnSpot, transform.rotation);
			ticket = false;
		}  else if (pencil) {
			spawnSpot = new Vector3 (0.06f, 0.92f, 0f);
			GameObject itemHeld5 = (GameObject)Instantiate (greenScreen, spawnSpot, transform.rotation);
			pencil = false;
		}
	}
//	
//	void OnLevelWasLoaded(int level)
//	{
//		if (level < 6) 
//		{
//			if((Application.loadedLevelName != "OpeningCinematic") && (Application.loadedLevelName != "OpeningCinematic2") && (Application.loadedLevelName != "Instructions") && (Application.loadedLevelName != "MainMenu"))
//			{
//				GameObject obj = GameObject.FindGameObjectWithTag("Player");
//				obj.SendMessage("updateHealth", curr_health, SendMessageOptions.DontRequireReceiver);
//			}
//		}
//	}
}
