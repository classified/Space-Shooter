using UnityEngine;
using System.Collections;

public class TouchButtonTalk : TouchLogic
{
	public GameObject player;
	public float playerSpeed=5f;
	public GameObject laser;
	public float fireFreq;
	private float lastShot;
	public GUIText text1;
	public GUIText text2;


	void OnTouchBegan()
	{
		if(guiTexture.tag == "Right")
		{
			player.transform.Translate (Vector3.right * Time.smoothDeltaTime * playerSpeed);

		}
		if(guiTexture.tag == "Left")
		{
			player.transform.Translate (-Vector3.right * Time.smoothDeltaTime * playerSpeed);

		}
		if(guiTexture.tag == "Up")
		{
			player.transform.Translate (Vector3.forward * Time.smoothDeltaTime * playerSpeed);

		}
		if(guiTexture.tag == "Down")
		{
			player.transform.Translate (Vector3.back * Time.smoothDeltaTime * playerSpeed);

		}
		if (guiTexture.tag == "Fire")
		{

			if (Time.time > fireFreq + lastShot)
			{
				Instantiate (laser, player.transform.position, player.transform.rotation);
				lastShot = Time.time;
				text1.guiText.text= "Missile Fired!!";
			}

		}

	


	}
	void OnTouchEnded()
	{

	}
	void OnTouchMoved()
	{

	}
	void OnTouchStayed()
	{
		if(guiTexture.tag == "Right")
		{
			player.transform.Translate (Vector3.right * Time.smoothDeltaTime * playerSpeed);

		}
		if(guiTexture.tag == "Left")
		{
			player.transform.Translate (-Vector3.right * Time.smoothDeltaTime * playerSpeed);

		}
		if(guiTexture.tag == "Up")
		{
			player.transform.Translate (Vector3.forward * Time.smoothDeltaTime * playerSpeed);

		}
		if(guiTexture.tag == "Down")
		{
			player.transform.Translate (-Vector3.forward * Time.smoothDeltaTime * playerSpeed);

		}
		if (guiTexture.tag == "Fire")
		{

			if (Time.time > fireFreq + lastShot)
			{
				Instantiate (laser, player.transform.position, player.transform.rotation);
				lastShot = Time.time;
				text1.guiText.text= "Missile Fired!!";
			}
			
		}
	}
	void OnTouchBeganAnyWhere()
	{
		//text1.guiText.text = "You have Touched Anywhere on screen ";

	}
	void OnTouchEndedAnywhere()
	{

	}
	void OnTouchMovedAnywhere()
	{

	}
	void OnTouchStayedAnywhere()
	{

	}



}
