#pragma strict

public var hitInfo:RaycastHit;
public var cojin:GameObject;

public var MaterialR:Material;
public var MaterialB:Material;
public var MaterialN:Material;

public var CMaterialR:Material;
public var CMaterialB:Material;
public var CMaterialN:Material;

public var camara_menu:Camera;


function Start () 
{

}

function Update () 
{

	for (var i = 0; i < Input.touchCount; ++i) 
	{
        if (Input.GetTouch(i).phase == TouchPhase.Began) 
        {
        	Debug.Log("tocooooooooooo");
            // Construct a ray from the current touch coordinates
            var ray = camara_menu.ScreenPointToRay (Input.GetTouch(i).position);
            if (Physics.Raycast (ray, hitInfo)) 
            {
            
            	 Debug.Log("I hit: " + hitInfo.collider.gameObject.name);
                // Create a particle if hit
                if(hitInfo.collider.tag == "botones")
                {
                	switch(hitInfo.collider.gameObject.name)
					{
						case "boton_rojo":
										gameObject.renderer.material = MaterialR;
										cojin.renderer.material = CMaterialR;
										Debug.Log("Cambio a Rojo");
										break;
		
						case "boton_blanco":
										gameObject.renderer.material = MaterialB;
										cojin.renderer.material = CMaterialB;
										break;
						
						case "boton_negro":
										gameObject.renderer.material = MaterialN;
										cojin.renderer.material = CMaterialN;
										break;
					}
					
                }
         	}
        }
    }

}