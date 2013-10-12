using UnityEngine;
using System.Collections;

public class Headbob : MonoBehaviour 
{
	//public float bobSpeed = 0.18f;
	//public float midpoint = 2.0f;
	//public float bobbingAmount = 0.2f;
	//private float timer = 0.0f;
	//public float angle = 10.0f;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//float waveSlice = 0.0f;
		float horiz = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");
		
		// If the player is not moving
		//
		if(horiz == 0.0f && vert == 0.0f)
		{
			//timer = 0.0f;
			
			// Rewind back to beginning
			//
			animation.Rewind();
			// Stop playing the animation
			//
			animation.Stop();
		}
		else
		{
			// When the player is moving play the animation
			//
			animation.Play();
			
			//waveSlice = Mathf.Sin(timer);
			//timer += bobSpeed;
			//if(timer > Mathf.PI * 2)
			//{
			//	timer -= Mathf.PI * 2;
			//}
		}
		
		/*if(waveSlice != 0.0f)
		{
			float translateAmount = waveSlice * bobbingAmount;
			float totalAxes = Mathf.Abs(horiz) + Mathf.Abs(vert);
			totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
			translateAmount = totalAxes * translateAmount;
			transform.position = new Vector3(transform.position.x, midpoint + translateAmount, transform.position.z);
			//transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f), waveSlice * angle);
			Vector3 angles = transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler(angles.x,angles.y,waveSlice * angle);
		}
		else
		{
			transform.position = new Vector3(transform.position.x, midpoint, transform.position.z);
			Vector3 angles = transform.rotation.eulerAngles;
			transform.rotation = Quaternion.Euler(angles.x,angles.y,0.0f);			
		}*/
	}
}
