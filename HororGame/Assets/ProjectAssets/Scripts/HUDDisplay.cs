using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;


// The point of this script is to read in text from a file,
// then upon trigger, display that text smoothly to the 
// HUD.


public class HUDDisplay : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{	
		display = this.GetComponent<GUIText>(); // This object is the attached GUITexture
		
		length = 0;
		totalLength = 0;
		textBuffer = "";
		textToDisplay = "";
		active = false;
		
		
		// Load the text from a file
		LoadText();
		
		if(calculateTime)
		{
			timePerChar = totalTime / (float)totalLength;
		}
		
		timeTillNext = timePerChar;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(active)
		{
			PrintText(); // only call print function when in trigger volume
		}
	}
	
	// Load the text from a file
	void LoadText()
	{
		// Create a string builder to concat all the lines of the file
		//
		//StringBuilder builder = new StringBuilder();
	
		// Use stream reader to load the file in line by line
		//
		/*
		using(StreamReader sr = new StreamReader(file.))
		{
			string line;
			
			// Load till the end of the file
			//
			while((line = sr.ReadLine()) != null)
			{
				builder.Append(line);
				builder.Append("\n");
			}
		}
		*/
		
		// Set the file buffer to all of the lines in the file
		//
		textBuffer = file.ToString();//builder.ToString();
		
		// Set the total file lenght
		//
		totalLength = textBuffer.Length;
	}
	
	
	// Print the text to the hud (smoothly)
	void PrintText()
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
				textToDisplay = textBuffer.Substring(0, length);
				display.text = textToDisplay;
			}
			else
			{
				textToDisplay = textBuffer;
				display.text = textToDisplay;
			}
		}
	}
	
	
	//Clear the text from the hud display
	void ClearText()
	{
		display.text = "";
		length = 0;
		active = false;
	}
	
	
	// Activate the print function
	void ActivatePrint()
	{
		active = true;
	}
	
	
	// Public vars
	//public string fileName = "error";	// This is the text file that will be read in.
	public float timePerChar;
	
	// Private vars
	public string textBuffer; // fileBuffer
	public string textToDisplay; // output text
	
	public bool calculateTime = false;
	
	public TextAsset file;
	
	// Used if script should calculate time, total time to display entire file
	//
	public float totalTime = 0;
	
	
	private GUIText display;
	
	private int length;
	private int totalLength;
	
	private float timeTillNext;
	
	private bool active;
	

}
