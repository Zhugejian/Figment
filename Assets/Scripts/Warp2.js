// Warp to Room2 on Trigger
	function OnTriggerEnter (other : Collider) {
	    if(other.tag == "Player")
	    {
		    Application.LoadLevel ("Room2");
		}
	}