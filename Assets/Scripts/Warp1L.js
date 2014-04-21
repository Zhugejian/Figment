// Warp to Start Room Left Door on Trigger
	function OnTriggerEnter (other : Collider) {
	    if(other.tag == "Player")
	    {
		    Application.LoadLevel ("Start Room Left Door");
		}
	}