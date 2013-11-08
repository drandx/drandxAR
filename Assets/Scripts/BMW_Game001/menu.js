#pragma strict

public var llantaP:Transform;
public var pista:Transform;
public var moto:Transform;

var maxTorque = 160;
private var llego:boolean = false;
private var vel = 1;

public var camara_menu:Camera;
public var hitInfo:RaycastHit;

private var anda:int;

function Update () 
{

for (var i = 0; i < Input.touchCount; ++i) 
	{
	
		if (Input.GetTouch(i).phase == TouchPhase.Stationary) 
        {
        	var ray = camara_menu.ScreenPointToRay (Input.GetTouch(i).position);
            if (Physics.Raycast (ray, hitInfo)) 
            {
            Debug.Log("entro");
            	 Debug.Log("I hit: " + hitInfo.collider.gameObject.name + " //GameObject: "+hitInfo.collider.gameObject.tag);
                // Create a particle if hit
                if(hitInfo.collider.tag == "Player")
                {
                	Debug.Log("--Entro2:  "+hitInfo.collider.gameObject.name);
                	
                	switch(hitInfo.collider.gameObject.name)
					{
						case "left":
										Debug.Log("--left");
										moto.position.x += 1;
										Debug.Log("Left");
										break;
		
						case "andar":
										
										if(!llego)
										{
											//llanta.motorTorque = maxTorque * -Input.GetAxis("Vertical");
											pista.Translate(0,0,(1 * vel) * Time.deltaTime);
											llantaP.Rotate(0,(vel * -1) * Time.deltaTime,0);
											vel+=8;
											Debug.Log("andar");
											
										}
										
										break;
						
						case "right":
										Debug.Log("--Right");
										moto.position.x -= 1;
										Debug.Log("rigth");
										break;
					}
					
                }
             }
        }
        if(Input.GetTouch(i).phase == TouchPhase.Began)
        {
       		var ray1 = camara_menu.ScreenPointToRay (Input.GetTouch(i).position);
            if (Physics.Raycast (ray1, hitInfo)) 
            {
         
            	 
                if(hitInfo.collider.tag == "Player")
                {
                	switch(hitInfo.collider.gameObject.name)
					{
				
		
						case "andar":
										if(!llego)
										{
											
											anda = i;
										}
										
										break;
						
				
					
					
                	}
                }
        	}
        }
        
        if (Input.GetTouch(i).phase == TouchPhase.Ended) 
        {
        	if(anda == i)
        	{
        		vel = 1;
        		anda = 100;
        	}
        }
    }

}