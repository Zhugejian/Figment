#pragma strict

var intsong;
var chst;
var hcube;

//Script to go back to the instructions screen on trigger;
function OnMouseDown()
{
    Destroy(intsong);
    Destroy(chst);
    Destroy(hcube);
    Application.LoadLevel("Instructions");
}

function Start () {

    intsong = GameObject.Find("intro song");
    chst = GameObject.Find("Chest");
    hcube = GameObject.Find("Health Cube");

}

function Update () {

}