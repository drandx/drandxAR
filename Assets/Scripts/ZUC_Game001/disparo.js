#pragma strict

public var kickSpeed = 40;

public var target : Transform;
private var targetGoal : Transform;



private var posIni:Vector3;

function Start () 
{
	posIni = transform.position;
}

function Update () 
{
	var hit : RaycastHit;
	var ray ;

    for (var touch in Input.touches)
	{   

        if (touch.phase==TouchPhase.Stationary)
        {
        	Debug.Log("Quieto");
			ray = Camera.main.ScreenPointToRay (Vector3(touch.position.x, touch.position.y, 0));
			
			/*
			if (Physics.Raycast (ray, hit) && hit.collider.gameObject.tag=="Player")
			{ 
				moveDirection = Vector3(0, 0, 0);
				if(chargeAmount<3)
				{
					isHolding=true;
				}else if (chargeAmount==3 && touch.phase==TouchPhase.Ended)
				{
					isHolding=false;
				}

            }*/

        }   

        if(touch.phase==TouchPhase.Moved)
		{
			Debug.Log("Moviendo");
			ray = Camera.main.ScreenPointToRay (Vector3(touch.position.x,touch.position.y, 0));
			var pos1:Vector3 = Camera.main.ScreenToViewportPoint  (Vector3(touch.position.x,touch.position.y, 0));
			Debug.Log("pos moviendo : "+pos1);
			/*
			if (Physics.Raycast (ray,hit)&&hit.collider.gameObject.tag=="UL")
			{   
				if(isHolding==true)
				{   
					chargeTime=0;
					moveDirection = Vector3(1, 1.5, 0);
					moveDirection = transform.TransformDirection(moveDirection);
					moveDirection *= flightSpeed;

                    curVelocity = moveDirection;

                    if (touchingWall)
					{
                        curVelocity = Vector3.Reflect (-curVelocity, Vector3.right);
                    }

                }else if (isHolding==false)
				{
				    moveDirection = Vector3(0, 0, 0);
				    moveDirection = transform.TransformDirection(moveDirection);
				}   

            }*/

        }

        if (touch.phase==TouchPhase.Ended)
		{
			Debug.Log("Termino");
			ray = Camera.main.ScreenPointToRay (Vector3(touch.position.x,touch.position.y, 0));
			var pos:Vector3 = Camera.main.ScreenToViewportPoint  (Vector3(touch.position.x,touch.position.y, 0));
			pos.z = pos.x;
			pos.x = -1;
			
		
			if(pos.z >= 0.0 && pos.z < 0.1)
				pos.z = -1;
							
			if(pos.z >= 0.1 && pos.z < 0.2)
				pos.z = -0.8;
			
			if(pos.z >= 0.2 && pos.z < 0.3)
				pos.z = -0.6;
				
			if(pos.z >= 0.3 && pos.z < 0.4)
				pos.z = -0.4;
				
			if(pos.z >= 0.4 && pos.z < 0.5)
				pos.z = -0.2;
				
			if(pos.z >= 0.5 && pos.z < 0.6)
				pos.z = 0;
				
			if(pos.z >= 0.6 && pos.z < 0.7)
				pos.z = 0.2;
				
			if(pos.z >= 0.7 && pos.z < 0.8)
				pos.z = 0.4;
				
			if(pos.z >= 0.8 && pos.z < 0.9)
				pos.z = 0.6;
				
			if(pos.z >= 0.9 && pos.z < 1.0)
				pos.z = 0.8;
			
			if(pos.z >= 1.0)
				pos.z = 1;
				
			Debug.Log("valor z : "+pos.z);
			Debug.Log("pos solto : "+pos);
			Destroy(GameObject.FindGameObjectWithTag("targetGoal"));
			targetGoal = Instantiate (target, pos, Quaternion.identity);
			kick();
			/*
			if (Physics.Raycast (ray,hit)&&hit.collider.gameObject.tag=="Player")
			{
				chargeTime=0;
				isHolding=false;
			}*/
			
		}
	}
	
	if(Input.GetKeyDown("space"))
	{
		//Debug.Log("patada");
		targetGoal = Instantiate (target, Vector3(-1,0.5,-0.5), Quaternion.identity);
		
		kick();
	}
 
                   
}

function kick()
{
	
	var posFinal:Vector3 = targetGoal.position;
	posFinal.y += 0.35;
	var targetDir = posFinal - transform.position;
	//if (soccerBall.rigidbody.GetComponent("BallBehavior").myOwner == transform )
	//{
		if( Vector3.Angle (transform.forward, targetDir) < 150 )
			rigidbody.velocity = (posFinal - transform.position).normalized * kickSpeed;
			//soccerBall.rigidbody.GetComponent("BallBehavior").rigidbody.velocit y = (targetGoal.position - transform.position).normalized*kickSpeed;
		else
			rigidbody.velocity = transform.TransformDirection(Vector3(0,0,kickSpeed));
			//soccerBall.rigidbody.GetComponent("BallBehavior").rigidbody.velocity = transform.TransformDirection(Vector3(0,0,kickSpeed));
			//soccerBall.rigidbody.GetComponent("BallBehavior").myOwner = null;
	//} 
}


function OnTriggerEnter(other : Collider)
{
	  if(other.gameObject.name == "fuera")
	  {
	  		//Destroy(targetGoal.gameObject);
	  }
}
