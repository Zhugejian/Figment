// Warp to Room4 on Trigger

	function OnTriggerEnter (other : Collider) {
	    if(other.tag == "Player")
	    {
		    Application.LoadLevel ("Room4");
		}
	}