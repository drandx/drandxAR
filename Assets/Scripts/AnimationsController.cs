using UnityEngine;
using System.Collections;

public class AnimationsController : MonoBehaviour {
	
	public DefaultTrackableEventHandler tracker;
	public DefaultTrackableEventHandler tracker2;
	
	public GameObject targetOne;
	public GameObject targetTwo;
	
	public AudioClip audio1;
	public AudioClip audio2;
	
	
	private VideoTexture _videoTexture;
	private bool playingVid;
	private bool pausedVid;


	// Use this for initialization
	void Start () {
		playingVid = false;
		pausedVid = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(tracker.isFound()){
				//Debug.Log("*** Tracking Object----TrackerVideo");
				if(!playingVid){
					Debug.Log("///PlayingVid");
					playingVid = true;
					// create the video texture
					//_videoTexture = new VideoTexture( "vid2.m4v", 480, 264, false, 0, true );
					_videoTexture = new VideoTexture( "test4.mov", 900, 480, true, 0, false );
					targetOne.GetComponent<AudioSource>().Play();
					
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
			
				
				if(pausedVid){
					if( _videoTexture != null ){
						_videoTexture.unpause();
						targetOne.GetComponent<AudioSource>().Play();
						pausedVid = false;
					}
				}
			
			
		}
		else{
			//Debug.Log("--- Not Tracking Object");
			
			if(playingVid){
				pausedVid = true;
				if( _videoTexture != null )
				_videoTexture.pause();
				targetOne.GetComponent<AudioSource>().Pause();
			}
			
			/*
			playingVid = false;
			// null check in case Stop was pressed which will kill the VideoTexture
			if( _videoTexture != null )
			{
				_videoTexture.stop();
				_videoTexture = null;
			}*/
			
		}
		
		
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
