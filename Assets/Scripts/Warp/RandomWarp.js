var nmes : GameObject[];

var rando : int;

function OnTriggerEnter (entity : Collider) {
    nmes = GameObject.FindGameObjectsWithTag("Enemy");
    if((entity.tag == "Player") && (nmes.length == 0))
    {
	    Application.LoadLevel(rando);// ("ReturnToTutorialRoom2");
	}
}
function Awake() {
	rando = Random.Range(9, 11);
}