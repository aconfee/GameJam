using UnityEngine;
using System.Collections;

public class LevelProgress : MonoBehaviour 
{
	// Delegate for what the functions should look like
	//
	private delegate void levelFunct();
	
	// Enum for all of the different progress levels we can have
	//
	enum LEVEL_PROGRESS
	{
		START = 0,   // 0
		PUZZLEONE,   // 1
		PUZZLETWO,   // 2
		PUZZLETHREE, // 3
		END			 // 4
	};
	
	// Default progress state, used in restart
	//
	public int defaultProgress = 0;
	
	// Delegates to run the level progress
	//
	private levelFunct currentOnUpdate;
	private levelFunct currentOnEnter;
	private levelFunct currentOnExit;
	
	// Change progress function, only location of the god switch statement
	//
	public void ChangeProgress(int progress)
	{
		// Clean up what will be our previous state
		//
		currentOnExit();
		
		// Change to the new state
		//
		switch(progress)
		{
		case (int)LEVEL_PROGRESS.START:
			// Set the necessary functions for this state
			//
			currentOnUpdate = ProgressStart.OnUpdate;
			currentOnExit = ProgressStart.OnExit;
			currentOnEnter = ProgressStart.OnEnter;
			break;
			
		case (int)LEVEL_PROGRESS.PUZZLEONE:
			break;
			
		case (int)LEVEL_PROGRESS.PUZZLETWO:
			break;
			
		case (int)LEVEL_PROGRESS.PUZZLETHREE:
			break;
			
		case (int)LEVEL_PROGRESS.END:
			break;
		}
		
		// Call on start of the new state
		//
		currentOnEnter();
	}
	
	// Function to do nothing
	//
	private void Empty()
	{
	}
	
	// Switch back to the default state
	//
	public void Restart()
	{
		ChangeProgress(defaultProgress);
	}
	
	// Use this for initialization
	//
	void Start ()
	{
		currentOnExit = Empty;
		Restart();
	}
	
	// Update is called once per frame
	//
	void Update ()
	{
		// I love delegates...
		//
		currentOnUpdate();
	}
}
