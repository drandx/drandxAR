#pragma strict

public var velocidad:float;
public var dir_left:boolean;



function Start () 
{
	dir_left = true;
}

function Update () 
{
	if(dir_left)
	{
		transform.Translate(-velocidad * Time.deltaTime,0,0);
	}else transform.Translate(velocidad * Time.deltaTime,0,0);
}



function OnCollisionEnter(other : Collision) 
{
    if(other.gameObject.name == "limit_left")
    	dir_left = false;
    
    if(other.gameObject.name == "limit_right")
    	dir_left = true;
}

function OnTriggerEnter(other : Collider)
{
	Debug.Log("trigger");
	  if(other.gameObject.name == "limit_left")
    	dir_left = false;
    
    if(other.gameObject.name == "limit_right")
    	dir_left = true;
}
