function OnMouseEnter()
{
	renderer.material.color = Color.green;
}

function OnMouseExit()
{
	renderer.material.color = Color.white;
}

// Warp to Start Room Left Door on Trigger
function OnMouseDown() 
{
	Application.LoadLevel ("MainMenu");
}