#pragma strict

function Start () {

}

function Update () {

}

function OnTriggerEnter(col : Collider)
{
	Debug.Log("--llego Alguien--: "+col.gameObject.tag);	
}