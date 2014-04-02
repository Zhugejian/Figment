var Health : int = 3;


//var mHurt : Material;
//var normal : Material;

function OnMouseDown()
{
    Health--;
    renderer.material.color = Color.red;
    yield WaitForSeconds(.1);
    renderer.material.color = Color.white;
    if (Health == 0)
    {
        renderer.transform.position = Vector3(5,-100,65);
    }
}