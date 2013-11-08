#pragma strict

public var balon:GameObject;
public var posIni:Vector3;
private var reset:int = 0;

function Start () 
{
	

}

function Update () 
{
	for (var touch in Input.touches)
	{   

        if (touch.phase==TouchPhase.Stationary)
        {
 

        }   

        if(touch.phase==TouchPhase.Moved)
		{
	

        }

        if (touch.phase==TouchPhase.Ended)
		{
			if(reset == 0)
			{
				reset++;
			}else if(reset == 1)
			{
				Destroy(GameObject.FindGameObjectWithTag("balon"));
	  			Instantiate(balon,posIni,transform.rotation);
	  			reset=0;
			}
			
		}
	}

}

function OnTriggerEnter(other : Collider)
{
		Debug.Log("borro");
	  if(other.gameObject.tag == "balon")
	  {
	  		Destroy(other.gameObject);
	  		Instantiate(balon,posIni,transform.rotation);
	  }
}