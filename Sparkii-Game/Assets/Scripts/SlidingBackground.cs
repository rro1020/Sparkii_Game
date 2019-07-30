using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI; 
using System.Threading; 

public class SlidingBackground : MonoBehaviour
{
	public Image image1; 
	//public Image image2; 
	//public Image image3; 
	//public Image image4; 
	
	private Vector3 image1Pos; 
	//private Vector3 image2Pos; 
	//private Vector3 image3Pos; 
	//private Vector3 image4Pos; 

	void Start()
	{
		Time.timeScale = 1;
		StartCoroutine("MoveImages");
	} 
	
	IEnumerator MoveImages()
	{
		while (true)
		{
			yield return new WaitForSeconds (1);
			updatePositions(); 
			image1.gameObject.transform.position = image1Pos; 
		} 
	}
	
	void updatePositions()
	{
		image1Pos = new Vector3(image1Pos.x - 10, image1Pos.y, 0); 
	} 
}
