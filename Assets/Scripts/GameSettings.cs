using UnityEngine;
using System.Collections;
//using UnityEditor;

public class GameSettings : MonoBehaviour {
	
	public bool portrait;
	public bool landscape;
	public bool landportrait;
	
	
	void Awake(){
		//if(landscape)
			//Screen.orientation = ScreenOrientation.Landscape;
	}
	
	
	
	// Use this for initialization
	void Start () {
		//Screen.orientation = ScreenOrientation.AutoRotation;
		/*
		if(portrait){
			Screen.orientation = ScreenOrientation.Portrait;
			Screen.orientation = ScreenOrientation.AutoRotation;
   			Screen.autorotateToPortrait = true;
    		Screen.autorotateToPortraitUpsideDown = true;
			Screen.autorotateToLandscapeLeft = false;
    		Screen.autorotateToLandscapeRight = false;
		}
		
		else if(landscape){
			PlayerSettings.useOSAutorotation = false;
			Screen.orientation = ScreenOrientation.AutoRotation;
			Screen.autorotateToLandscapeLeft = true;
    		Screen.autorotateToLandscapeRight = true;
			Screen.autorotateToPortrait = false;
    		Screen.autorotateToPortraitUpsideDown = false;
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else if(landportrait){
			Screen.orientation = ScreenOrientation.AutoRotation;
			Screen.autorotateToPortrait = true;
    		Screen.autorotateToPortraitUpsideDown = true;
			Screen.autorotateToLandscapeLeft = true;
    		Screen.autorotateToLandscapeRight = true;
		
		}
		 */
	}
	
	// Update is called once per frame
	void Update () {
		//Screen.orientation = ScreenOrientation.AutoRotation;
		/*if(portrait){
			Screen.orientation = ScreenOrientation.Portrait;
			Screen.orientation = ScreenOrientation.AutoRotation;
   			Screen.autorotateToPortrait = true;
    		Screen.autorotateToPortraitUpsideDown = true;
			Screen.autorotateToLandscapeLeft = false;
    		Screen.autorotateToLandscapeRight = false;
		}
		
		else if(landscape){
			Debug.Log("--Entra a LandScape");
			//PlayerSettings.useOSAutorotation = false;
			Screen.orientation = ScreenOrientation.AutoRotation;
			Screen.autorotateToLandscapeLeft = true;
    		Screen.autorotateToLandscapeRight = true;
			Screen.autorotateToPortrait = false;
    		Screen.autorotateToPortraitUpsideDown = false;
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else if(landportrait){
			Screen.orientation = ScreenOrientation.AutoRotation;
			Screen.autorotateToPortrait = true;
    		Screen.autorotateToPortraitUpsideDown = true;
			Screen.autorotateToLandscapeLeft = true;
    		Screen.autorotateToLandscapeRight = true;
		
		}*/
	}
}
