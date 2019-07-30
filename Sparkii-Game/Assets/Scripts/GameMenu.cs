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
	public Text gameText; 
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (isGamePaused)
			{
				gameText.gameObject.SetActive(false); 
				Resume(); 
			} else 
			{
				gameText.gameObject.SetActive(true); 
				Pause(); 
			}
		} 
	} 
	
	public void Resume()
	{
		pauseButton.gameObject.SetActive(true); 
		playButton.gameObject.SetActive(false); 
		Time.timeScale = 1f; 
		isGamePaused = false; 
	} 
	
	public void Pause()
	{
		Time.timeScale = 0f; //freezes game 
		isGamePaused = true; 
		gameText.text = "Paused"; 
		pauseButton.gameObject.SetActive(false); 
		playButton.gameObject.SetActive(true); 
	} 
	
	public void ExitGame(){
		Time.timeScale = 0f; //freezes game 
		isGamePaused = true; 
		gameText.text = "Are you sure you want to leave?"; 
	} 
	
	/* 
	public void Yes(){
		SceneManager.LoadScene(0); 
		Time.timeScale = 1f;
		isGamePaused = false; 
	} 
	
	public void No(){
		Time.timeScale = 1f;
		isGamePaused = false; 
	} 
	*/ 
	
	void setAllButtonsFalse(){
		
	} 
}

