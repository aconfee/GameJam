using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour 
{
	public float minOnTime = 1.0f;
	public float maxOnTime = 2.0f;
	public float minFlickerTime = 1.0f;
	public float maxFlickerTime = 2.0f;
	public float minFlickerSpeed = 0.1f;
	public float maxFlickerSpeed = 0.3f;
	private float timeTillSwitch = 1.0f;
	private float flickerTime = 1.0f;
	private bool isFlickering = false;
	
	void Flicker()
	{
		flickerTime -= Time.deltaTime;
		
		if(flickerTime < 0)
		{
			light.enabled = !light.enabled;
			flickerTime = Random.Range(minFlickerSpeed, maxFlickerSpeed);
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeTillSwitch -= Time.deltaTime;
		
		if(timeTillSwitch < 0.0f)
		{
			if(isFlickering)
			{
				timeTillSwitch = Random.Range(minOnTime, maxOnTime);
			}
			else
			{
				timeTillSwitch = Random.Range(minFlickerTime, maxFlickerTime); 
			}
			
			isFlickering = !isFlickering;
		}
		
		if(isFlickering)
		{
			Flicker();
		}
	}
}
