using UnityEngine;
using System.Collections;
using iGUI;

public class iGUICode_GUI_Passar_V4 : MonoBehaviour{
	[HideInInspector]
	public iGUIImage image2;
	[HideInInspector]
	public iGUIImage image1;
	[HideInInspector]
	public iGUISlidePanel slidePanel1;
	[HideInInspector]
	public iGUIPanel panel1;
	[HideInInspector]
	public iGUIRoot root1;

	static iGUICode_GUI_Passar_V4 instance;
	
	public GUISkin skin;
    private bool loading = false;
	
	void Awake(){
		instance=this;
	}
	
	void Update(){
		
		//Debug.Log("panel active: "+slidePanel1.activePanel);
		if (slidePanel1.activePanel==10){
			Debug.Log("panel active final: "+slidePanel1.activePanel);
			slidePanel1.setActivePanel(1);
			//slidePanel1.onPanelChange = new iGUIAction[9];
		}
		
		if (slidePanel1.activePanel==0){
			Debug.Log("panel active final: "+slidePanel1.activePanel);
			slidePanel1.setActivePanel(9);
			//slidePanel1.onPanelChange = new iGUIAction[9];
		}
		
	}
	public static iGUICode_GUI_Passar_V4 getInstance(){
		return instance;
	}
	
	
	public void buttonPG_Click(iGUIButton caller){
		Debug.Log("Click PG");
		 loading = true;
       Application.LoadLevel("PG_Main");
       
       if(!Application.isLoadingLevel)
           loading = false;
	}


	public void buttonFL_Click(iGUIButton caller){
		Debug.Log("Click FL");
		 loading = true;
       Application.LoadLevel("FL_Game001");
       
       if(!Application.isLoadingLevel)
           loading = false;
	}

	public void buttonBMW_Click(iGUIButton caller){
		Debug.Log("Click BMW");
		   loading = true;
       Application.LoadLevel("BMW_Game001");
       
       if(!Application.isLoadingLevel)
           loading = false;
	}

	public void buttonBJ_Click(iGUIButton caller){
		Debug.Log("Click BJ");
	}

	public void buttonBC_Click(iGUIButton caller){
		Debug.Log("Click BC");
		  loading = true;
       Application.LoadLevel("BC_Chair001");
       
       if(!Application.isLoadingLevel)
           loading = false;
	}

	public void buttonDC_Click(iGUIButton caller){
		Debug.Log("Click DC");
	}

	public void buttonHW_Click(iGUIButton caller){
		Debug.Log("Click HW");
	}

	public void buttonZC_Click(iGUIButton caller){
		Debug.Log("Click ZC");
		loading = true;
       Application.LoadLevel("ZUC_Game001");
       
       if(!Application.isLoadingLevel)
           loading = false;
	}

	public void buttonZUE_Click(iGUIButton caller){
		Debug.Log("Click ZUE");
	}
	
	  void OnGUI(){
       GUI.skin = skin;
       if(loading)
         GUI.Label (new Rect (Screen.width*0.30f, Screen.height*0.45f, Screen.width*0.4f, Screen.height*0.1f), "Loading...","label_loading");
   }


}
