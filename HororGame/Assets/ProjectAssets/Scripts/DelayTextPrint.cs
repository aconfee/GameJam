using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class DelayTextPrint : MonoBehaviour
{
	// Text buffer to be printed
	//
	public string outputText = "";
	
	// Text buffer to store the whole file
	//
	private string fileBuffer;
	
	// Time per char
	//
	public float timePerChar = 1.0f;
	
	// Pos in buffer
	//
	private int length; 
		
	// Length of buffer
	//
	private int totalLength;
	
	// Filename
	//
	public string fileName = "Error";
	
	// Time till next char
	//
	private float timeTillNext;
	
	private void LoadText()
	{
		// Create a string builder to concat all the lines of the file
		//
		StringBuilder builder = new StringBuilder();
	
		// Use stream reader to load the file in line by line
		//
		using(StreamReader sr = new StreamReader(fileName))
		{
			string line;
			
			// Load till the end of the file
			//
			while((line = sr.ReadLine()) != null)
			{
				builder.Append(line);
			}
		}
		
		// Set the file buffer to all of the lines in the file
		//
		fileBuffer = builder.ToString();
		
		// Set the total file lenght
		//
		totalLength = fileBuffer.Length;
	}
	
	// Use this for initialization
	void Start () 
	{
		length = 0;
		totalLength = 0;
		fileBuffer = "";
		outputText = "";
		timeTillNext = timePerChar;
		
		// Load the specified text file in
		//
		LoadText();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Count down to add next character to the text buffer
		//
		timeTillNext -= Time.deltaTime;
		
		// If time has expired and the next character should be added
		//
		if(timeTillNext < 0.0f)
		{
			timeTillNext = timePerChar;
			++length;
			if(length < totalLength)
			{
				outputText = fileBuffer.Substring(0, length);
			}
			else
			{
				outputText = fileBuffer;
			}
		}
		
	}
}
