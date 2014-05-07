var nmes : GameObject[];
var curr : int = 0;
var rando : int;

function OnTriggerEnter (entity : Collider) {
    nmes = GameObject.FindGameObjectsWithTag("Enemy");
    if((entity.tag == "Player") && (nmes.length == 0))
    {
	    Application.LoadLevel(rando);// ("ReturnToTutorialRoom2");
	}
}
function Awake() {
	curr = Application.loadedLevel;
	rando = Random.Range(7, 10);
	while(rando == curr) {
		rando = Random.Range(7, 10);
	}
}