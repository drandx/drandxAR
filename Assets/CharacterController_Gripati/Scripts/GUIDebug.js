#pragma strict

public var joystickSingleToWriteOutput : JoystickSingle;
public var guiTextureTransformButtonA : Transform;
public var guiTextureTransformButtonB : Transform;
public var guiTextureTransformButtonC : Transform;
public var guiTextureTransformButtonD : Transform;

function OnGUI () {
	GUI.Label (Rect (Screen.width * 0.4, Screen.height * 0.90, Screen.width * 0.5, Screen.height * 0.1), "Angel (in Degree) = " + joystickSingleToWriteOutput.outputAngleRad * Mathf.Rad2Deg);
	GUI.Label (Rect (Screen.width * 0.4, Screen.height * 0.95, Screen.width * 0.5, Screen.height * 0.1), "Force = " + joystickSingleToWriteOutput.outputForce);
	
	if(guiTextureTransformButtonA){
		GUI.Label (Rect (Screen.width * 0.75, Screen.height * 0.55, Screen.width * 0.25, Screen.height * 0.1), "Button A = " + getStatusOfButton(guiTextureTransformButtonA));
	}
	if(guiTextureTransformButtonB){
		GUI.Label (Rect (Screen.width * 0.75, Screen.height * 0.50, Screen.width * 0.25, Screen.height * 0.1), "Button B = " + getStatusOfButton(guiTextureTransformButtonB));
	}
	if(guiTextureTransformButtonC){
		GUI.Label (Rect (Screen.width * 0.75, Screen.height * 0.45, Screen.width * 0.25, Screen.height * 0.1), "Button C = " + getStatusOfButton(guiTextureTransformButtonC));
	}
	if(guiTextureTransformButtonD){
		GUI.Label (Rect (Screen.width * 0.75, Screen.height * 0.40, Screen.width * 0.25, Screen.height * 0.1), "Button D = " + getStatusOfButton(guiTextureTransformButtonD));
	}
	
	
	if(GUI.Button(Rect(Screen.width * 0.90, Screen.height * 0.01, Screen.width * 0.09, Screen.height * 0.1), "EXIT")){
		Application.LoadLevel("0 DemoIntro");
	}
}

function getStatusOfButton(guiTextureTransform : Transform) : String{
	var returnValue : String= "None";
	
	if(guiTextureTransform){
		var scriptControllerGui : ControllerGUIButton = guiTextureTransform.GetComponent (ControllerGUIButton);
		if(scriptControllerGui.isOverImage){
			returnValue = "Pressed";
		}
		else{
			returnValue = " - ";
		}
		
	}
	else{
		returnValue = "None";
	}
	
	return returnValue;
}
