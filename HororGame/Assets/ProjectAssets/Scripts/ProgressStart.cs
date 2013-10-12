using UnityEngine;
using System.Collections;

public class ProgressStart 
{
	// Functions for the progress start state
	//
	public static void OnEnter()
	{
		Debug.Log("Start: On Enter");
	}
	
	public static void OnUpdate()
	{
		Debug.Log("Start: On Update");
	}
	
	public static void OnExit()
	{
		Debug.Log("Start: On Exit");
	}
}
