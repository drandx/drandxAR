using UnityEngine;
using System.Collections;

public class GUIInternalController : MonoBehaviour {
	
	public GUISkin skin;
	public string appName;
	public bool hasLogo;
	public bool bottomGUI;
	public bool hasWindow;
	
	private ScreenOrientation screenMode;
	
	
	//Rects
	private Rect btn_rect_volver;
	private Rect btn_rect_camera;
	private Rect lbl_rect_logo;
	private Rect hud_rect_window;
	
	
	// Use this for initialization
	void Start () {
		initRect();
		screenMode = Screen.orientation;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(screenMode != Screen.orientation){//Sets uo the rect objects according to the new screen position
			screenMode = Screen.orientation;
			initRect();
		}	
	}
	
	
	void OnGUI (){
		GUI.skin = skin;
		
		if(!hasWindow){
		
			if(GUI.Button(btn_rect_volver, "","btn_volver")){
				Application.LoadLevel("GUI_Passar_V4");
			}
			
			if(GUI.Button(btn_rect_camera, "","btn_camera")){
				Debug.Log("--Takes Photo ScreenShot");
			}
			if(hasLogo)
				GUI.Label (lbl_rect_logo, "", "logo_"+appName);
		}	
	}
	
	/// <summary>
	/// Is called as a Message from other scripts.
	/// </summary>
	void setShowWindow(){
	}
	
	
	/// <summary>
	/// Is called as a Message from other scripts.
	/// </summary>
	void setHideWindow(){
	}
	
	
	/// <summary>
	/// Inits the rect.
	/// </summary>
	void initRect(){
		
		lbl_rect_logo = new Rect(Screen.width * 0.77f, Screen.height * 0.04f,150,150 );
		
		if(bottomGUI){
			btn_rect_volver = new Rect(Screen.width * 0.05f, Screen.height * 0.85f,135,135);
			btn_rect_camera = new Rect(Screen.width * 0.32f, Screen.height * 0.85f,89,89);
		}
		else{
			btn_rect_volver = new Rect(Screen.width * 0.05f, Screen.height * 0.09f,135,135);
			btn_rect_camera = new Rect(Screen.width * 0.32f, Screen.height * 0.09f,84,84 );
			
		}
		
		
		
		/*
		if(bottomGUI){ //Validates the position the GUI to the application ex: BMW the gui is showd on the top
			if(Screen.orientation == ScreenOrientation.Portrait){
				btn_rect_volver = new Rect(Screen.width * 0.05f, Screen.height * 0.9f, Screen.width * 0.2109f, Screen.height * 0.046f);
				btn_rect_camera = new Rect(Screen.width * 0.32f, Screen.height * 0.9f, Screen.width * 0.135f, Screen.height * 0.046f);
				lbl_rect_logo = new Rect(Screen.width * 0.7f, Screen.height * 0.08f, Screen.width * 0.23f, Screen.height * 0.154f);
			}
			else if (Screen.orientation == ScreenOrientation.LandscapeLeft){
				btn_rect_volver = new Rect(Screen.width * 0.05f, Screen.height * 0.9f, Screen.width * 0.15f, Screen.height * 0.08f);
				btn_rect_camera = new Rect(Screen.width * 0.28f, Screen.height * 0.9f, Screen.width * 0.10f, Screen.height * 0.08f);
				lbl_rect_logo = new Rect(Screen.width * 0.8f, Screen.height * 0.08f, Screen.width * 0.23f, Screen.height * 0.154f);
			}
		}
		else{
			if(Screen.orientation == ScreenOrientation.Portrait){
				btn_rect_volver = new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.2109f, Screen.height * 0.046f);
				btn_rect_camera = new Rect(Screen.width * 0.32f, Screen.height * 0.05f, Screen.width * 0.135f, Screen.height * 0.046f);
				lbl_rect_logo = new Rect(Screen.width * 0.7f, Screen.height * 0.05f, Screen.width * 0.23f, Screen.height * 0.154f);
			}
			else if (Screen.orientation == ScreenOrientation.LandscapeLeft){
				btn_rect_volver = new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.15f, Screen.height * 0.08f);
				btn_rect_camera = new Rect(Screen.width * 0.28f, Screen.height * 0.05f, Screen.width * 0.10f, Screen.height * 0.08f);
				lbl_rect_logo = new Rect(Screen.width * 0.8f, Screen.height * 0.05f, Screen.width * 0.23f, Screen.height * 0.154f);
		
			}
	
		}
		*/
		
		
		
	}
}