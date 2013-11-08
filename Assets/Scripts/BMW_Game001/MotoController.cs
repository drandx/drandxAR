using UnityEngine;
using System.Collections;

public class MotoController : MonoBehaviour {
	
	public MenuController menu;
	public Transform pista;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		Debug.Log("--Trigger: "+col.gameObject.tag);
		
		if(col.gameObject.tag == "Trigger1"){
			menu.locked = true;
		}
		else if(col.gameObject.tag == "Trigger2"){
			StartCoroutine(InitPosition());
			
		}
	}
	
	
	
	IEnumerator InitPosition(){
		yield return new WaitForSeconds(3.5f);
		pista.position = gameObject.transform.position;
		menu.locked = false;
	}
	
}
