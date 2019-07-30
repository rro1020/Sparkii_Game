using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

 

public class CountDown : MonoBehaviour {


  public int timeLeft; //Seconds Overall 
  public Text countdown; //UI Text Object
  public Text gameText; 
  public Canvas pausedCanvas; 
  public Button playButton; 
  public Button exitButton; 

 

  void Start () {

    StartCoroutine("LoseTime");

    Time.timeScale = 1; //Just making sure that the timeScale is right

  }

 

  void Update () {

    countdown.text = ("Time Left: " + timeLeft); //Showing the Score on the Canvas
	if (timeLeft < 6)
	{
		countdown.color = Color.red; 
	} 
	
	if (timeLeft < 1)
	{
		Time.timeScale = 0;
		gameText.gameObject.SetActive(true); 
		gameText.text = "Game Over"; 
		pausedCanvas.gameObject.SetActive(true); 
		playButton.gameObject.SetActive(true); 
		exitButton.gameObject.SetActive(true); 
		
	}

  }

 

  //Simple Coroutine

  IEnumerator LoseTime()

  {

    while(timeLeft>0) {

      yield return new WaitForSeconds (1);

      timeLeft--;

       
	   

    } 

 

  }}