using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameMenu : MonoBehaviour
{
	public static bool isGamePaused; 
	public Button pauseButton; 
	public Button playButton; 
	public Button exitButton; 
	//public Canvas pausedCanvas; 
	public Button yesButton; 
	public Button noButton; 
	public Text gameText; 
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (isGamePaused)
			{
				Resume(); 
			} else 
			{
				Pause(); 
			}
		} 
	} 
	
	public void Resume()
	{
		if (gameText.text.Contains("Win"))
		{
			SceneManager.LoadScene(0); 
		} else if (gameText.text.Contains("Over"))
		{
			SceneManager.LoadScene(1); 
		} else
		{	
			gameText.gameObject.SetActive(false); 
			pauseButton.gameObject.SetActive(true); 
			playButton.gameObject.SetActive(false); 
			Time.timeScale = 1f; 
			isGamePaused = false; 
		}
	} 
	
	public void Pause()
	{
		Time.timeScale = 0f; //freezes game 
		isGamePaused = true; 
		gameText.gameObject.SetActive(true); 
		gameText.text = "Paused"; 
		pauseButton.gameObject.SetActive(false); 
		playButton.gameObject.SetActive(true); 
	} 
	
	public void ExitGame()
	{
		if (gameText.text.Contains("Win"))
		{
			SceneManager.LoadScene(0); 
		} else 
		{
			Time.timeScale = 0f; //freezes game 
			isGamePaused = true; 
			pauseButton.gameObject.SetActive(false); 
			playButton.gameObject.SetActive(true); 
			gameText.gameObject.SetActive(true); 
			gameText.fontSize = 50; 
			gameText.text = "Are you sure you want to leave?"; 
		} 
		
	} 
	
	
	public void Yes()
	{
		SceneManager.LoadScene(0); 
		Time.timeScale = 1f;
		isGamePaused = false; 
	} 
	
	public void No(){
		noButton.gameObject.SetActive(false); 
	} 
	
	
}

