#pragma strict

private var marginFromLeftRatio : float = 0.10;
private var marginFromTopRatio : float = 0.1;
private var marginBetweenButtonRatio : float = 0.12;
private var widthOfButtonRatio : float = 0.8;
private var heightOfButtonRatio : float = 0.1;

private var isClickedOneOfThem : boolean = false;
function Start () {
	isClickedOneOfThem = false;
}

function OnGUI(){

	if(isClickedOneOfThem){
		GUI.Label (Rect (Screen.width * 0.40, Screen.height * 0.45, Screen.width * 0.20, Screen.height * 0.1), "Loading...");
	}
	else{
		if (GUI.Button (new Rect (Screen.width * marginFromLeftRatio, Screen.height * marginFromTopRatio, Screen.width * widthOfButtonRatio, Screen.height * heightOfButtonRatio), "Static Joystick - Alwasy Visible - Linear - No Button")){
			isClickedOneOfThem = true;
			Application.LoadLevel("1 DemoSceneStaticJoystikNoExtraButton");
		}
		
		if( GUI.Button (new Rect (Screen.width * marginFromLeftRatio, Screen.height * (marginFromTopRatio + marginBetweenButtonRatio), Screen.width * widthOfButtonRatio, Screen.height * heightOfButtonRatio), "Dynamic Joystick - Alwasy Visible - Linear - No Button")){
			isClickedOneOfThem = true;
			Application.LoadLevel("2 DemoSceneDynamicJoystikNoExtraButton");
		}
		
		if(GUI.Button (new Rect (Screen.width * marginFromLeftRatio, Screen.height  * (marginFromTopRatio + 2 * marginBetweenButtonRatio), Screen.width * widthOfButtonRatio, Screen.height * heightOfButtonRatio), "Dynamic Joystick - Touch Visible - Linear - No Button")){
			isClickedOneOfThem = true;
			Application.LoadLevel("3 DemoSceneDynamicJoystikTouchVisibleNoExtraButton");
		}
		
		if(GUI.Button (new Rect (Screen.width * marginFromLeftRatio, Screen.height  * (marginFromTopRatio + 3 * marginBetweenButtonRatio), Screen.width * widthOfButtonRatio, Screen.height * heightOfButtonRatio), "Dynamic Joystick - Touch Visible - Cubic - No Button")){
			isClickedOneOfThem = true;
			Application.LoadLevel("4 DemoSceneDynamicJoystikTouchVisibleCubicNoExtraButtons");
		}
		
		if(GUI.Button (new Rect (Screen.width * marginFromLeftRatio, Screen.height  * (marginFromTopRatio + 4 * marginBetweenButtonRatio), Screen.width * widthOfButtonRatio, Screen.height * heightOfButtonRatio), "Dynamic Joystick - Touch Visible - Cubic - Two Button")){
			isClickedOneOfThem = true;
			Application.LoadLevel("5 DemoSceneDynamicJoystikTouchVisibleCubicTwoButtons");
		}
	
		if(GUI.Button (new Rect (Screen.width * marginFromLeftRatio, Screen.height  * (marginFromTopRatio + 5 * marginBetweenButtonRatio), Screen.width * widthOfButtonRatio, Screen.height * heightOfButtonRatio), "Dynamic Joystick - Touch Visible - Cubic - Four Button")){
			isClickedOneOfThem = true;
			Application.LoadLevel("6 DemoSceneDynamicJoystikTouchVisibleCubicFourButtons");
		}
			
		if(GUI.Button (new Rect (Screen.width * marginFromLeftRatio, Screen.height  * (marginFromTopRatio + 6 * marginBetweenButtonRatio), Screen.width * widthOfButtonRatio, Screen.height * heightOfButtonRatio), "Dynamic Joystick - Touch Visible - Exponential - Four Button")){
			isClickedOneOfThem = true;
			Application.LoadLevel("7 DemoSceneDynamicJoystikTouchVisibleExpFourButtons");
		}
	}

}