using UnityEngine;
using System.Collections;

public class NumberPuzzleInteract : MonoBehaviour
{
	public int index = 0;
	GameObject numberPuzzle;
	NumberPuzzleLogic logic;
	public string logicObjectName = "NumberPuzzle";
	
	// Use this for initialization
	void Start ()
	{
		numberPuzzle = GameObject.Find(logicObjectName);
		logic = (NumberPuzzleLogic)numberPuzzle.GetComponent("NumberPuzzleLogic");
	}
	
	public void Toggle()
	{
		logic.ToggleNumber(index);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
