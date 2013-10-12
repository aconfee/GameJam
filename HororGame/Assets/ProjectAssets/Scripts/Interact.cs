using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		active = false;
		debugBool = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(active)
			DoInteraction();			
	}
	
	
	// Check for player input
	bool CheckInput()
	{
		return Input.GetMouseButtonDown(1);
	}
	
	void DoInteraction()
	{
		if(CheckInput())	// If player has clicked
		{
			GameObject.Find(interactFunctionObject).SendMessage(interactFunction);
		}
	}
	
	
	// Turn the logic update on and off
	void ActivateInteraction()
	{
		active = true;
	}
	
	
	void DeactivateInteraction()
	{
		active = false;
	}
	
	// For debuging only!!!!!
	void ToggleBool()
	{
		transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
	}
	
	public string interactFunction;
	public string interactFunctionObject;
	public bool debugBool;
	
	private bool active;

}
