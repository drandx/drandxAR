using UnityEngine;
using System.Collections;

public class GUIPedroGomez : MonoBehaviour {
	
	public GUISkin skin;
	public DefaultTrackableEventHandler tracker;
	public GameObject targetOne;
	
	private bool playVideo;
	private bool videoPaused;
	//Rects
	private Rect btn_rect_playvideo;
	private Rect btn_rect_pausevideo;
	private Rect btn_rect_restartvideo;
		
	private ScreenOrientation screenMode;
	private VideoTexture _videoTexture;
	
	private Rect lbl_rect_logo;

	
	// Use this for initialization
	void Start () {
		screenMode = Screen.orientation;
		initRect();
		startVideo();
		_videoTexture.pause();
		videoPaused = false;
	}
	
	
	void Update(){
		if(tracker.isFound()){
			playVideo = true;
		}
		else{
			playVideo = false;
			if( _videoTexture != null ){
				_videoTexture.pause();
				targetOne.GetComponent<AudioSource>().Pause();
				//videoPaused = true;
			}
		}
		
		if(screenMode != Screen.orientation){//Sets uo the rect objects according to the new screen position
			Debug.Log("--Cambio Orientacion");
			screenMode = Screen.orientation;
			initRect();
		}
		
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.skin = skin;
		GUI.Label (lbl_rect_logo, "", "logo_pedrogomez");
		if(playVideo){
			if(GUI.Button(btn_rect_playvideo, "","btn_play")){
				targetOne.GetComponent<AudioSource>().Play();
				if(videoPaused){
					_videoTexture.unpause();
					videoPaused = false;
				}
				else{
					if( _videoTexture != null )
						startVideo();
				}
				
			}
			
			if(GUI.Button(btn_rect_pausevideo, "","btn_pause")){
				Debug.Log("--Pause Video");
				if( _videoTexture != null ){
					_videoTexture.pause();
					targetOne.GetComponent<AudioSource>().Pause();
					videoPaused = true;
				}
			}
			
			if(GUI.Button(btn_rect_restartvideo, "","btn_return")){
				Debug.Log("--Return Video");
				if( _videoTexture != null ){
					_videoTexture.stop();
					targetOne.GetComponent<AudioSource>().Stop();
				}
				startVideo();
				targetOne.GetComponent<AudioSource>().Play();
			}
		
		
		}
	
	}
	
	void initRect(){
		//if(Screen.orientation == ScreenOrientation.Portrait){
		lbl_rect_logo = new Rect(Screen.width * 0.7f, Screen.height * 0.01f,195,195 );
		
		btn_rect_playvideo = new Rect(Screen.width * 0.50f, Screen.height * 0.85f, 89, 89);
		btn_rect_pausevideo = new Rect(Screen.width * 0.68f, Screen.height * 0.85f, 89, 89);
		btn_rect_restartvideo = new Rect(Screen.width * 0.86f, Screen.height * 0.85f, 89, 89);
				
			//}
			//else if (Screen.orientation == ScreenOrientation.LandscapeLeft){
				//btn_rect_playvideo = new Rect(Screen.width * 0.50f, Screen.height * 0.9f, Screen.width * 0.10f, Screen.height * 0.08f);
				//btn_rect_pausevideo = new Rect(Screen.width * 0.70f, Screen.height * 0.9f, Screen.width * 0.10f, Screen.height * 0.08f);
				//btn_rect_restartvideo = new Rect(Screen.width * 0.86f, Screen.height * 0.9f, Screen.width * 0.10f, Screen.height * 0.08f);
		//}
	
	}
	
	
	
	void startVideo(){
		Debug.Log("--Play Video");
		_videoTexture = new VideoTexture( "test4.mov", 900, 480, true, 0, false );
					
		// apply the texture to a material and set the UVs
		targetOne.renderer.sharedMaterial.mainTexture = _videoTexture.texture;
		LiveTextureBinding.updateMaterialUVScaleForTexture( targetOne.renderer.sharedMaterial, _videoTexture.texture );
						
		// add some event handlers
		_videoTexture.videoDidStartEvent = () =>
		{
		Debug.Log( "Video one started" );
		};
		_videoTexture.videoDidFinishEvent = () =>
		{
		// when the video finishes if we are not set to loop this instance is no longer valid
		Debug.Log( "Video one finished" );
		};
	
	
	}
	
	
	void OnApplicationQuit()
	{
        // if the video texture is still playing kill it
		if( _videoTexture != null )
		{
			_videoTexture.stop();
			_videoTexture = null;
		}
		
		
	}
	
	
	void OnApplicationPause( bool paused )
	{
		if( paused )
		{
	        // if the video texture is still playing kill it
			if( _videoTexture != null )
			{
				_videoTexture.stop();
				_videoTexture = null;
			}
			
			
		}
	}
	
	
}
