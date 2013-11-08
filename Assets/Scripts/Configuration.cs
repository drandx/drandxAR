using UnityEngine;
using System.Collections;
/// <summary>
/// Storage constants and basi functions for the application
/// </summary>
public static class Configuration {
	
	/// <summary>
	/// Analizes the scree width
	/// </summary>
	/// <returns>
	/// The ipad.
	/// </returns>
	public static bool isIpad(){
		if((Screen.width == 768) || (Screen.width == 1024 ))
			return true;
		else
			return false;
	}
	
	/// <summary>
	/// Analizes the scree width
	/// </summary>
	/// <returns>
	/// The ipad.
	/// </returns>
	public static bool isIpadHD(){
		if((Screen.width == 2048) || (Screen.width == 1536 ))
			return true;
		else
			return false;
	}
	
}
