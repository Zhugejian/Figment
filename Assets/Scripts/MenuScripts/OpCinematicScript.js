function OnMouseEnter()
{
	this.renderer.material.color = Color.green;
}

function OnMouseExit()
{
	this.renderer.material.color = Color.white;
}

// Transition to the Opening Cinematic on Trigger
function OnMouseDown() 
{
	Application.LoadLevel ("OpeningCinematic2");
}