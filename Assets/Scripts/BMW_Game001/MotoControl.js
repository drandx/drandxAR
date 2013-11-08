#pragma strict
/*
public var llanta:WheelCollider;
public var llantaP:Transform;
public var pista:Transform;

var maxTorque = 160;
private var llego:boolean = false;
private var vel = 1;

public var camara_menu:Camera;
public var hitInfo:RaycastHit;
public var posIni:Transform;
*/
function Start () 
{
	//rigidbody.centerOfMass.y = 0;
	//posIni = pista.transform;
	//Debug.Log("**Posicion Inicial Pista: "+posIni.position);
	//pista.position.z = 100;
}

function Update()
{
	
}


function FixedUpdate () 
{
	/*
	if(!llego)
	{
		//llanta.motorTorque = maxTorque * -Input.GetAxis("Vertical");
		pista.Translate(0,0,(Input.GetAxis("Vertical") * vel) * Time.deltaTime);
		llantaP.Rotate(0,maxTorque * -Input.GetAxis("Vertical"),0);
		llanta.steerAngle = -5 * Input.GetAxis("Horizontal");
		vel+=20;
	}
	else
	{
		//llanta.brakeTorque = 290;
		
		
	}
	
	if(Input.GetKeyUp("up"))
	{
		Debug.Log("solto");
		vel = 1;
	}*/
}

function OnTriggerEnter(col : Collider)
{
	Debug.Log("--llego: "+col.gameObject.tag);	
}