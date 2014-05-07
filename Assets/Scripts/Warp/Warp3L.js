// Warp to Room3 on Trigger
	function OnTriggerEnter (other : Collider) {
	    if(other.tag == "Player")
	    {
		    Application.LoadLevel ("Room3L");
		}
	}