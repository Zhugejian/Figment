// Warp to Start Room Right Door on Trigger
	function OnTriggerEnter (other : Collider) {
	    if(other.tag == "Player")
	    {
		    Application.LoadLevel ("Start Room Right Door");
		}
	}