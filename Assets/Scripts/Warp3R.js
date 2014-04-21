// Warp to Room3 Right Door on Trigger
	function OnTriggerEnter (other : Collider) {
	    if(other.tag == "Player")
	    {
		    Application.LoadLevel ("Room3R");
		}
	}