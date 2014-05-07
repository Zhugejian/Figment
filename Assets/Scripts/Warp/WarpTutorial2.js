// Warp to TutorialRoom2

var nmes : GameObject[];

function OnTriggerEnter (entity : Collider) {
    nmes = GameObject.FindGameObjectsWithTag("Enemy");
    if((entity.tag == "Player") && (nmes.length == 0))
    {
	    Application.LoadLevel ("TutorialRoom2");
	}
}