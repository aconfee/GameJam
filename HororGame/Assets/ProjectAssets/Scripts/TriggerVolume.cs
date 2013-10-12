using UnityEngine;
using System.Collections;


// This is the script responsible for the default
// trigger volume. 


public class TriggerVolume : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	// Check if player has entered our trigger volume
	void OnTriggerEnter(Collider collision)
	{
		if(collision.name == "Player")
		{
			GameObject.Find(enterFunctionObject).SendMessage(enterFunction);
		}
	}
	
	
	void OnTriggerExit(Collider collision)
	{
		if(collision.name == "Player")
		{
			GameObject.Find(exitFunctionObject).SendMessage(exitFunction);
		}
	}
	
	void DoNothing()
	{
		// If user desires to do nothing on enter or exit.
	}
	
	
	// Public vars 
	public string enterFunction;	// This is the trigger event function
	public string enterFunctionObject; // this is the object that implements the function we want to call.
	
	public string exitFunction;
	public string exitFunctionObject;
	
}
