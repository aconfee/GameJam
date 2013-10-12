using UnityEngine;
using System.Collections;

public class NumberPuzzleLogic : MonoBehaviour 
{
	private bool[] number;
	public int length = 0;
	
	public bool isComplete()
	{
		for(int i = 0; i < length; ++i)
		{
			if(number[i] == false)
				return false;
		}
		
		return true;
	}
	
	public bool GetElement(int index)
	{
		return number[index];
	}
	
	public void ToggleNumber(int index)
	{
		ToggleElement(index);
		
		if(index == 0)
		{
			ToggleElement(index + 1);
		}
		else if(index == (length - 1))
		{
			ToggleElement(index - 1);			
		}
		else
		{
			ToggleElement(index + 1);
			ToggleElement(index - 1);
		}
	}
	
	private void ToggleElement(int index)
	{
		number[index] = !number[index];
	}
	
	// Use this for initialization
	void Start ()
	{
		number = new bool[length];
		for(int i = 0; i < length; ++i)
		{
			number[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
