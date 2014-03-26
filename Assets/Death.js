var Health : int = 3;

var x : int = 0;

var mHurt : Material;
var normal : Material;

function BackToNormal()
{
    renderer.material = normal;

}

function OnMouseDown()
{
    Health--;
    renderer.material = mHurt;
    setTimeout(BackToNormal(), 3000);
    if (Health == 0)
    {
        renderer.transform.position = Vector3(5,-100,65);
    }
}