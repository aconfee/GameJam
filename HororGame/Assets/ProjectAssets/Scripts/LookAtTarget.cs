using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour
{
	// Name of the target to follow
	//
	public string targetName;
	
	// Need variable here
	//
	GameObject player;
	
	// Transform for lerping
	//
	private Vector3 lerpPos;
	
	public float lerpSpeed = 0.2f;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find(targetName);
		lerpPos = new Vector3(player.transform.position.x, 
							  player.transform.position.y, 
							  player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		lerpPos = Vector3.Lerp(lerpPos, player.transform.position, lerpSpeed);
		
		// Unity look at function
		//
		transform.LookAt(lerpPos , new Vector3(0.0f, 1.0f, 0.0f));
	}
}
