using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {


	#region var

	[HideInInspector]
	public static float playerHealth = 100f;
	[HideInInspector]
	public static float enemyHit;
	private static float maxHealth=100f;


	//texture list
	public Texture2D[] textures;
	public GUISkin skins;
	private Vector3 scale;

	#endregion
	// Use this for initialization
	void Start () {

		playerHealth = 100f;

	}
	
	// Update is called once per frame
	void Update () {
		if(DificultySelect.easyLevel == true)
		{
			enemyHit =-10f;
		}
		if(DificultySelect.medLevel == true)
		{
			enemyHit = -15f;	
		}
		if(DificultySelect.HardLevel == true)
		{
			enemyHit = -20f;
		}
	
	}

	int getReturn(float curr,float max)
	{
		float percentage = curr / max * (textures.Length-1);
		int myInt = Mathf.RoundToInt(percentage);
		return myInt;
	}

	void OnGUI()
	{
		GUI.skin =skins;
		scale.x = Screen.width /320.0f;
		scale.z = Screen.height / 480.0f;
		scale.y = 1f;
		var svMat = GUI.matrix;
		Debug.Log(Screen.width.ToString());
		Debug.Log(Screen.height.ToString());
		Debug.Log(scale.x.ToString());
		Debug.Log(scale.z.ToString());
		GUI.matrix =Matrix4x4.TRS(Vector3.zero,Quaternion.identity,scale);

		int number = getReturn(playerHealth,maxHealth);
		if(number >= textures.Length - 1)
		{
			number = textures.Length - 1;
		}
		if(number < 0)
		{
			number = 0;
		}
		GUI.Label(new Rect(180,Screen.height - 30,100,100)," HP ");
		GUI.DrawTexture(new Rect(220,Screen.height - 70,100,100),textures[number]);
		GUI.matrix = svMat;
	}
}
