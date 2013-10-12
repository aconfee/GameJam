using UnityEngine;
using System.Collections;

public class TimeCountdown : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	  {
		timeText = this.GetComponent<GUIText>();
		
	    //originalFontSize = 80;
	    
	    //if(Screen.width <= 800)
	    //{
	      //timeText.fontSize = 60;      
	      //originalFontSize = 60;
	    //}
	    
	    
	    startTime = (int)Time.time;
	    currentTime = (int)Time.time;
	    
	    displayMinutes = initialMinutes;
	    displaySeconds = initialSeconds;
	
	    timeText.text = displayMinutes.ToString() + " : " + displaySeconds.ToString();
		

		}
	
	void ResetTime()
	{
		Start ();
	}
	// Update is called once per frame
	void Update () 
  {
    // Get the current time
    currentTime = (int)Time.time;
    
    // Every one second, update timer
    if(currentTime - startTime >= 1)
    {      
      --displaySeconds;
      
      if(displaySeconds < 0)
      {
          displaySeconds = 59;
          --displayMinutes;
          
          if(displayMinutes < 0)
          {
            displayMinutes = 0;
            displaySeconds = 0;
            // TIME OVER
          }
      }
      
      // Beep last ten seconds
      if(displayMinutes == 0 && displaySeconds <= 10 && displaySeconds > 0)
      {
        audio.PlayOneShot(sound);
        timeText.material.color = Color.red;
       
      }
      
      timeText.text = displayMinutes.ToString() + " : ";
      
      // Add '0' if single digit
      if(displaySeconds >= 10)
        timeText.text += displaySeconds.ToString();
      
      else
        timeText.text += "0" + displaySeconds.ToString();
    
    
      startTime = (int)Time.time;
    }

    
	}
	
  private int displayMinutes;
  private int displaySeconds;
  
  public int initialMinutes;
  public int initialSeconds;
  
  public AudioClip sound;
  
  private int startTime;
  private int currentTime;
  
  private GUIText timeText;
  
  private int originalFontSize;
  public float alpha;
}









