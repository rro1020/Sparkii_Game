using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClickInput : MonoBehaviour
{
	
	[SerializeField] Transform target; 
	float speed = 6f; 
	Vector2 targetPosition; 
	
	private void Start()
	{
		targetPosition = transform.position; 
	}
	
	
    void Update()
    {
		/*
			Once player clicks mouse, the target will be shown momentarily. 
			The cartPlayerObject will move towards target. 
		*/ 
		if (Input.GetMouseButtonDown(0))
		{
			//Debug.Log("Mouse button clicked!"); 
			targetPosition = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition); 
			target.position = targetPosition; 
		}
		
		if ((Vector2)transform.position != targetPosition){
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
		}
    }
}

//Based off tutorial from following website 
//https://unity.grogansoft.com/move-player-to-clicktouch-position/ 