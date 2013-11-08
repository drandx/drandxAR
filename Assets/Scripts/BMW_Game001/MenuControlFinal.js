#pragma strict

var Speed        : float = 0;//Don't touch this
var MaxSpeed     : float = 10;//This is the maximum speed that the object will achieve
var Acceleration : float = 10;//How fast will object reach a maximum speed
var Deceleration : float = 10;//How fast will object reach a speed of 0

var pista : Transform;
var accelerateSound : AudioClip;
var deccelerateSound : AudioClip;
var netroSound : AudioClip;
var motorcycle : Transform;

//@script RequireComponent(AudioSource)

function Update () {
	if (Input.GetKey ("left")){
		//audio.Stop();
		goBackward();
	}	
	else if (Input.GetKey ("right")){	
		//audio.Stop();
		goForward();
	}	
	
	else
		neutro();
			

}

function goForward(){
	Debug.Log("--goForward");
	//audio.PlayClipAtPoint(accelerateSound, motorcycle.position); 
	audio.PlayOneShot(accelerateSound);
	if (Speed > -MaxSpeed)
	    Speed = Speed + Acceleration * Time.deltaTime;
	    
	 pista.transform.position.z = pista.transform.position.z + Speed * Time.deltaTime;
}


function goBackward(){
	Debug.Log("--goBackward");
	//audio.PlayClipAtPoint(deccelerateSound, motorcycle.position); 
	audio.PlayOneShot(deccelerateSound);

	if (Speed < MaxSpeed)
    	Speed = Speed - Acceleration * Time.deltaTime; 
	pista.transform.position.z = pista.transform.position.z + Speed * Time.deltaTime;
}


function neutro(){
	Debug.Log("--Neutro");
	//audio.PlayClipAtPoint(netroSound, motorcycle.position);
	audio.PlayOneShot(netroSound);
 
	if(Speed > Deceleration * Time.deltaTime)
        Speed = Speed - Deceleration * Time.deltaTime;
    else if(Speed < -Deceleration * Time.deltaTime)
        Speed = Speed + Deceleration * Time.deltaTime;
    else
        Speed = 0;
        
        pista.transform.position.z = pista.transform.position.z + Speed * Time.deltaTime;
}