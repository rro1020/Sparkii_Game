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
	public Text menuText; 
	public int itemNumber; 
	public GameObject finishBody; 
	public Canvas pausedCanvas; 
	public Button pauseButton; 
	public Button playButton; 
	
	private Rigidbody2D rb2d; 
	private int count; 
	private bool gameCompleted; 
    
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
		
		//Make sures no more items are picked up afterwards 
		if (itemNumber > 0) 
		{
			if (other.gameObject.CompareTag("Item"))
			{
				count += 5; 
				itemNumber--; 
				other.gameObject.SetActive(false);
				SetCountText(); 
			} else if (other.gameObject.CompareTag("ShinyItem"))
			{
				count += 15; 
				itemNumber--; 
				other.gameObject.SetActive(false);
				SetCountText(); 
			} else if (other.gameObject.CompareTag("SpoiledItem"))
			{
				count++; 
				itemNumber--; 
				other.gameObject.SetActive(false);
				SetCountText(); 
			} 
		} else {
			if (other.gameObject.CompareTag("FinishBlock")){
				Debug.Log("Touched Sparkii!"); 
				EndGame(); 
			} 
		}
		
	}
	
	void SetCountText(){
		pointText.text = "Points: " + count.ToString(); 
		
		if (itemNumber > 0)
		{
			menuText.text = "Apples Needed: " + itemNumber.ToString(); 
		} else 
		{
			menuText.text = "Got all the apples!!!"; 
			finishBody.SetActive(true); 
		} 
		
		
	}
	
	void EndGame(){
		Time.timeScale = 0f; 
		gameText.gameObject.SetActive(true); 
		pausedCanvas.gameObject.SetActive(true); 
		pauseButton.gameObject.SetActive(false); 
		playButton.gameObject.SetActive(true); 
		gameText.fontSize = 70; 
		gameText.text = "You Win!"; 
	} 
}
