// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class MenuController: MonoBehaviour {
	
public float Speed = 0;	
public float MaxSpeed = 10;//This is the maximum speed that the object will achieve
public float Acceleration = 10;//How fast will object reach a maximum speed
public float Deceleration = 10;//How fast will object reach a speed of 0

public Transform pista;
public AudioClip accelerateSound;
public AudioClip deccelerateSound;
public AudioClip netroSound;
public Transform motorcycle;
public Animation motorcycleAnimation;	
	
public bool locked = false;	
	
	
public Transform llantaP;
public Transform llantaF;	
public int maxTorque = 160;
public Camera camara_menu;
public RaycastHit hitInfo;	

void Start(){
		
	Debug.Log("--Star Animations");	
	/*	
	motorcycleAnimation[ "IZQ" ].wrapMode = WrapMode.Once;
	motorcycleAnimation[ "DCHA" ].wrapMode = WrapMode.Once;
	motorcycleAnimation[ "FRENO" ].wrapMode = WrapMode.Once;
	
	motorcycleAnimation[ "IZQ" ].layer = 2;
	motorcycleAnimation[ "DCHA" ].layer = 2;
	motorcycleAnimation[ "FRENO" ].layer = 2;
    */
		
}
	
void  Update (){
		
	//Para controllar desde el teclado	
	
	if (Input.GetKey ("left") && !locked){
		goBackward();
	}	
	else if (Input.GetKey ("right") && !locked){	
		goForward();
	}	
	
	else if((Input.touchCount == 0) || locked)
		neutro();
	
			
	//Manejo de Touch
	for (int i = 0; (i < Input.touchCount) && !locked ; ++i) 
	{
	
		if (Input.GetTouch(i).phase == TouchPhase.Stationary) 
        {
        	Ray ray = camara_menu.ScreenPointToRay (Input.GetTouch(i).position);
            if (Physics.Raycast (ray, out hitInfo)) 
            {
                // Create a particle if hit
                if(hitInfo.collider.tag == "Player")
                {
                	Debug.Log("--Entro2:  "+hitInfo.collider.gameObject.name);
                	
                	switch(hitInfo.collider.gameObject.name)
					{
						case "left":
										motorcycleAnimation.CrossFade( "DCHA" );
										motorcycle.position = motorcycle.position + new Vector3(1,0,0);
										break;
		
						case "andar":
										goForward();
										break;
						
						case "right":	
										motorcycleAnimation.CrossFade( "IZQ" );
										motorcycle.position = motorcycle.position - new Vector3(1,0,0);
										break;
					}
					
                }
             }
        }
        
    }
		
		
}
	
/// <summary>
/// Gos the forward.
/// </summary>
void  goForward (){
	Debug.Log("--goForward");
	//motorcycleAnimation[ "ACELERACION" ].wrapMode = WrapMode.Once;
	motorcycleAnimation.CrossFade( "ACELERACION" );
	llantaP.Rotate(0,(Speed * -1) * Time.deltaTime,0);
	//llantaF.Rotate(0,(Speed * -1) * Time.deltaTime,0);

	audio.PlayOneShot(accelerateSound);
	if (Speed < MaxSpeed)
	    Speed = Speed + Acceleration * Time.deltaTime;
	    
	pista.transform.position = pista.transform.position + new Vector3(0,0,Speed * Time.deltaTime);
}

/// <summary>
/// Gos the backward.
/// </summary>
void  goBackward (){
	Debug.Log("--goBackward");
	motorcycleAnimation.CrossFade( "FRENO" );
	llantaP.Rotate(0,(Speed * -1) * Time.deltaTime,0);
	//llantaF.Rotate(0,(Speed * -1) * Time.deltaTime,0);
	audio.PlayOneShot(deccelerateSound);
	if (Speed < MaxSpeed)
    	Speed = Speed - Acceleration * Time.deltaTime; 

	pista.transform.position = pista.transform.position + new Vector3(0,0,Speed * Time.deltaTime);	
		
}

/// <summary>
/// Neutro this instance.
/// </summary>
/// 
void  neutro (){
	Debug.Log("--Neutro");
	motorcycleAnimation.CrossFade( "FRENO" );
	llantaP.Rotate(0,(Speed * -1) * Time.deltaTime,0);
	//llantaF.Rotate(0,(Speed * -1) * Time.deltaTime,0);

	audio.PlayOneShot(netroSound);
	if(Speed > Deceleration * Time.deltaTime)
        Speed = Speed - Deceleration * Time.deltaTime;
    else if(Speed < -Deceleration * Time.deltaTime)
        Speed = Speed + Deceleration * Time.deltaTime;
    else
        Speed = 0;
        
		pista.transform.position = pista.transform.position + new Vector3(0,0,Speed * Time.deltaTime);
}
}