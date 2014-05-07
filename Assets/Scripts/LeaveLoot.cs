using UnityEngine;
using System.Collections;

public class LeaveLoot : MonoBehaviour {

	public GameObject BloodyBat;
	public GameObject DadsCap;
	public GameObject FavoriteBoard;
	public GameObject GrandmasSweater;
	public GameObject RunningAwayFromHome;
	public GameObject SchoolPencil;
	public Vector3 spawnSpot = new Vector3(0,2,0);
	bool nmedestroyed = false;

	GameObject pickedLoot;

	int rando = 0;

	void leavingLoot(bool log) {
		nmedestroyed = true;
		GameObject lootSpawn = (GameObject)Instantiate (pickedLoot, spawnSpot, transform.rotation);
	}

	// Use this for initialization
	void Start () {
		rando = Random.Range (0, 5);
		if (rando == 0) {
			pickedLoot = BloodyBat;
		} else if (rando == 1) {
			pickedLoot = DadsCap;
		} else if (rando == 2) {
			pickedLoot = FavoriteBoard;
		} else if (rando == 3) {
			pickedLoot = GrandmasSweater;
		} else if (rando == 4) {
			pickedLoot = RunningAwayFromHome;
		} else if (rando == 5) {
			pickedLoot = SchoolPencil;
		}
	}
	
	// Update is called once per frame
	void Update () {
		spawnSpot = this.gameObject.transform.position;	
	}
}
