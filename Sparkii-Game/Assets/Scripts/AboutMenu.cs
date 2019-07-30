using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AboutMenu : MonoBehaviour
{

	public int totalPageNumbers; 
	public Text bodyText; 
	public Text pageNoText; 
	public Button backPageButton; 
	public Button nextPageButton; 
	public Button applyNowButton; 
	
	private int currentPageNumber; 
	private string careerURL; 
	
	void Start(){
		currentPageNumber = 1; 
		careerURL = "https://careers.walmart.com/stores-clubs/walmart-store-jobs"; 
		updatePageNoText();
	} 
	
	
	public void NextPage(){
		currentPageNumber++; 
		updatePageNoText(); 
		if (currentPageNumber == totalPageNumbers){
			nextPageButton.gameObject.SetActive(false);
			backPageButton.gameObject.SetActive(true); 
		} else {
			backPageButton.gameObject.SetActive(true);
			nextPageButton.gameObject.SetActive(true); 
		}
	} 
	
	public void BackPage(){
		currentPageNumber--; 
		updatePageNoText();
		if (currentPageNumber == 1){
			backPageButton.gameObject.SetActive(false);
			nextPageButton.gameObject.SetActive(true); 
		} else {
			backPageButton.gameObject.SetActive(true);
			nextPageButton.gameObject.SetActive(true); 
		}
	} 
	
	public void ApplyNow(){
		Application.OpenURL(careerURL); 
	} 

	void updatePageNoText()
	{
		pageNoText.text = "Page " + currentPageNumber + "/" + totalPageNumbers; 
		
		/*
		if (currentPageNumber > 1){
			setGameText(1); 
		} else if (currentPageNumber == 1){
			setGameText(0); 
		} 
		*/ 
		
		bodyText.text = setGameText(currentPageNumber - 1); 
		
		
		
	} 
	
	
	string setGameText(int value){
		string gameText; 
		
		switch (value)
		{
			case 0: 
				gameText = 
				"This game was developed by a group of talented associates for Walmart's Go Game It competition. \n" + 
				"Special thanks to our team and managers for allowing us to work on this game. \n" + 
				" - Lee Moreno \n" + 
				" - Matthew Axelson \n" + 
				" - Nithya Ramachandran \n" + 
				" - Roel Orduño "; 
				
				applyNowButton.gameObject.SetActive(false); 
				
				break; 
			case 1: 
				gameText = 
				"This game is loosely based off the store associate experience.\n" + 
				"Although store associates do not hand pick items for the customer, Walmart does strive to create a culture when the customer can truly save money and live better.\n" + 
				"The Walmart culture is one of high performance, and it is how we live out our values. These four values are \n" + 
				" - Service to the Customer \n" + 
				" - Respect for the Individual \n" +   
				" - Strive for Excellence \n" + 
				" - Act with Integrity \n" + 
				"\n" + 
				"Our game allows you, the player, to follow these values to provide the highest level of customer satisfaction. \n" + 
				"Want to learn more about the store associate experience? \n" + 
				"Apply now! "; 
				
				applyNowButton.gameObject.SetActive(true); 
				
				break; 
			default: 
				gameText = "TEST"; 
				applyNowButton.gameObject.SetActive(false); 
				break; 
		} 
		
		return gameText; 
	} 
	
	
}
