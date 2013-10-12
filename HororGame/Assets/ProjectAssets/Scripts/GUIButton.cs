using UnityEngine;
using System.Collections;


// This is the default script that will allow the designer to create a button
// and add basic functionality. 

// This script is also responsible for handling basic button functions like 
// changing sprites on hover and click, detecting clicks, and executing on
// click functionality. 

public class GUIButton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{		
		// Set the default sprite to the GUITexture
		GUITextureButton = this.GetComponent<GUITexture>(); // This object is the attached GUITexture
		GUITextureButton.texture = buttonTextures[0];
		
		// Calculate buttons pixel position from relative coordinates
		buttonPositionX = Screen.width * transform.position.x;
		buttonPositionY = Screen.height * transform.position.y;
		
		buttonWidth = Screen.width * transform.localScale.x;
		buttonHeight = Screen.height * transform.localScale.y;
		
		
		
		
	}
	
	// Update is called once per frame
	// This is going to check for button clicks and hover. 
	// If the button is clicked it will do something.
	void Update () 
	{
		OnHover();
		OnClick();
	}
	
	
	// Check if mouse is hovered and change the sprite
	bool OnHover()
	{
		if(!CheckBoundaries())	// If the mouse is not within the boundaries of our button,
		{
			GUITextureButton.texture = buttonTextures[0];	// Display default image if not hovered.
			return false;		// return not hovering.
		}
		
		// Otherwise we are hovering so let's change the sprite of our button.
		GUITextureButton.texture = buttonTextures[1];
		return true;
	}
	
	
	// Check if mouse is clicked.
	bool OnClick()
	{
		// If the mouse is hovering over our object and being clicked.
		if(OnHover() && Input.GetMouseButtonDown(0))
		{
			GUITextureButton.texture = buttonTextures[2];	// Change to click sprite
			
			if(changeLevel)	// All we want to do with this click is change the level
			{
				if(levelName == "MainMenu")
					Screen.showCursor = true;
				else
					Screen.showCursor = false;
				
				Application.LoadLevel(levelName);
			}
			else            // Call the function that we want to execute
			{
				this.SendMessage(functionName);
			}
		}
		
		return true;
	}
	
	
	// This function checks if the mouse is over
	// our GUITexture or not. 
	bool CheckBoundaries()
	{		
		// For readability and easy to type, get button texture boundaries.
		float left = buttonPositionX - (buttonWidth / 2.0f);
		float right = buttonPositionX + (buttonWidth / 2.0f);
		float bottom = buttonPositionY - (buttonHeight / 2.0f);
		float top = buttonPositionY + (buttonHeight / 2.0f);
		
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		
		// If mouse is hovering over texture
		if(mouseX > left &&
		   mouseX < right &&
		   mouseY > bottom &&
		   mouseY < top)
		{
			return true;
		}
			
			
		return false;
	}
	
	
	// These are the three images that the button can have
	public Texture2D [] buttonTextures;	// 0: Default
										// 1: Hover
										// 2: Click
	
	// This will let us know if the button is changing levels or doing something else.
	// I specify this because a level change can easily be defined as a general case, but
	// this can still support more custom features
	public bool changeLevel;
	
	// This will be the name of the level we go to when the button is clicked
	public string levelName;
	
	// This will be the name of the function that should be called if more specific
	// functionality is desired
	public string functionName;
			
			
	// Private data
	private GUITexture GUITextureButton;
	public float buttonPositionX;		// Because button position is [0, 1] relative to the screen
	public float buttonPositionY;		// I have to calculate and store the actual pixel position here	
	
	public float buttonWidth;
	public float buttonHeight;
}
