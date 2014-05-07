function OnMouseEnter()
{
	this.renderer.material.color = Color.green;
}

function OnMouseExit()
{
	this.renderer.material.color = Color.white;
}

// Warp to Start Room Left Door on Trigger
function OnMouseDown() 
{
	Application.LoadLevel ("TutorialRoom3");
}