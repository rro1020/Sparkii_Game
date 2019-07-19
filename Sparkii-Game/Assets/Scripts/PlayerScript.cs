using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerScript : MonoBehaviour
{
	
	public float speed; 
	public Text pointText; 
	public Text gameText; 
	public Text timeText; 
	
	private Rigidbody2D rb2d; 
	private int count; 
    
	// Start is called before the first frame update
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>(); 
		count = 0; 
		gameText.text = ""; 
		SetCountText(); 
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal"); 
		float moveVertical = Input.GetAxis("Vertical"); 
		Vector2 movement = new Vector2(moveHorizontal, moveVertical); 
		rb2d.AddForce(movement * speed); 
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.CompareTag("Item"))
		{
			count++; 
			other.gameObject.SetActive(false);
			SetCountText(); 
		} 
		
	}
	
	void SetCountText(){
		pointText.text = "Points: " + count.ToString(); 
		
		if (count >= 12){
			//Based on tutorial code 
			//If player returns to spot, message will be displayed 
			gameText.text = "YOU WIN!!!";
		}
		
		/*
		if (time runs out) 
			gameText.text = "Game Over!" 
		*/ 
		
	}
}
