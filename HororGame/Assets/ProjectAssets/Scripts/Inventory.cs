using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	enum ITEMS
	{
		KEYCARD = 0
	};
	
	public int maxItems = 1;
	private bool[] inventory;
	
	bool HasItem(int item)
	{
		return inventory[item];
	}
	
	void SetItem(int item, bool status)
	{
		inventory[item] = status;
	}
	
	// Use this for initialization
	void Start ()
	{
		inventory = new bool[maxItems];
		for(int i = 0; i < maxItems; ++i)
		{
			inventory[i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
