using UnityEngine;
using System.Collections;

public class GUIFLGame001: MonoBehaviour {
	
	public GUISkin skin;
	
	private Rect windowRect;
	private Rect buttonRect;
	
	private ScreenOrientation screenMode;


	// Use this for initialization
	void Start () {
		initRect();
	}
	
	// Update is called once per frame
	void Update () {
		if(screenMode != Screen.orientation){//Sets uo the rect objects according to the new screen position
			screenMode = Screen.orientation;
			initRect();
		}
	
	}
	
	
	void OnGUI() {
		GUI.skin = skin;
		windowRect = GUI.Window(0, windowRect, DoMyWindow, "","hud_game1");
    }
	
	
    void DoMyWindow(int windowID) {
        if (GUI.Button(buttonRect, "","button_close")){
			Application.LoadLevel("GUI_Passar_V4");

		}
    }
	
	
	void initRect(){
		windowRect = new Rect(0, 0,Screen.width,Screen.height);
		buttonRect = new Rect(Screen.width*0.40f,Screen.height*0.90f,Screen.width*0.25f,Screen.height*0.1f);
	}
}
