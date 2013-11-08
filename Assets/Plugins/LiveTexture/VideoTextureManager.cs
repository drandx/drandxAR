using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class VideoTextureManager : MonoBehaviour
{
#if UNITY_IPHONE
	private static Dictionary<string, VideoTexture> videoTextureInstances = new Dictionary<string, VideoTexture>();


	void Awake()
	{
		// Set the GameObject name to the class name for easy access from Obj-C
		gameObject.name = this.GetType().ToString();
		DontDestroyOnLoad( this );
	}
	
	
	public static void registerInstance( string instanceId, VideoTexture instance )
	{
		videoTextureInstances[instanceId] = instance;
	}
	
	
	public static void deRegisterInstance( string instanceId )
	{
		if( videoTextureInstances.ContainsKey( instanceId ) )
			videoTextureInstances.Remove( instanceId );
	}
	
	
	public void videoDidStart( string instanceId )
	{
		if( videoTextureInstances.ContainsKey( instanceId ) )
			videoTextureInstances[instanceId].onStarted();
	}


	public void videoDidFinish( string instanceId )
	{
		if( videoTextureInstances.ContainsKey( instanceId ) )
			videoTextureInstances[instanceId].onComplete();
	}

#endif
}

