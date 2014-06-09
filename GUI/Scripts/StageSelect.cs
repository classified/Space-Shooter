using UnityEngine;
using System.Collections;

public class StageSelect : BaseMenuState {

	#region variables
	// for starting buttons positions
	public Vector2 offset;

	//our main gameobject
	public GameObject mainMenuGO;
	
	//the background texture
	public Texture backgroundTexture;
	
	
	//our gui skin!

	public int levelsPerRow = 3;
	public int levelsPerCol = 4;

	private int m_maxPages = 0;
	
	private int m_page = 0;
	
	public int maxLevels = 30;
	
	public string stageSelectSTR = "Stage Select";
	public string levelPrefix = "Level ";
	public string mainMenuButtonSTR = "Main Menu";
	
	public string nextPageButtonSTR = ">>";
	public string prevPageButtonSTR = "<<";
	
	public Vector2 levelButtonSize = new Vector2(0.2f,0.1f);
	public Vector2 buttonSpaceOffset;
	public bool useLevelNames=false;
	public string[] levelNames;
	
	public bool dontLockLevels = false;

	[HideInInspector]
	public int n = 0;
	private int showHighScore;
	public GUIStyle introTextGS;
	private Vector3 scale;
	#endregion

	#region functions

#if UNITY_ANDROID
	public void Start()
	{

		while(n < maxLevels)
		{
			m_maxPages++;
			n+= (levelsPerCol * levelsPerRow);
		}

		showHighScore = PreviewLabs.PlayerPrefs.GetInt("Highscore");
	}
	
	
	public override void onGUI()
	{
		GUI.skin = guiSkin0;
		
		float offsetX = transform.position.x + offset.x;
		float offsetY = transform.position.y + offset.y;
	
		//Scaling GUI MATRIX FOR ALL RESOLUTION
		scale.x = Screen.width /Screen.width;
		scale.y = Screen.height / Screen.height;
		scale.z = 1f;
		var svMat = GUI.matrix;
		
		Debug.Log(scale.x.ToString());
		Debug.Log(scale.y.ToString());
		GUI.matrix =Matrix4x4.TRS(Vector3.zero,Quaternion.identity,scale);

		GUI.Label(GUIHelper.screenRect (offsetX+.25f,offsetY+.65f,.4f,.1f),"HighScore : " + showHighScore.ToString(),introTextGS);

		if(backgroundTexture)
		{
			GUI.DrawTexture( GUIHelper.screenRect(0,0,1,1),backgroundTexture,ScaleMode.StretchToFill);
		}
				GUI.Box (GUIHelper.screenRect (offsetX,offsetY-.1f,.9f,.725f) ,"");
		
		GUI.Box (GUIHelper.screenRect (offsetX,offsetY-.1f,.9f,.725f) ,stageSelectSTR);
		
		n = 1 + m_page * levelsPerCol * levelsPerRow;
		for(int i=0; i<levelsPerRow; i++)
		{
			for(int j=0; j<levelsPerCol; j++)
			{
				int levelX = n;
				string str = levelPrefix + levelX.ToString();
				if(useLevelNames && n-1 < levelNames.Length)
				{
					str = levelNames[n-1];

				}
				if(n<=maxLevels)
				{
					if(n < Misc.getMaxLevel() || dontLockLevels)
					{


						GUI.enabled = true;
						if( addButton (GUIHelper.screenRect (offsetX-.05f+j*(levelButtonSize.x+buttonSpaceOffset.x),
						                                    offsetY+i*(levelButtonSize.y+buttonSpaceOffset.y),
						                                    levelButtonSize.x,levelButtonSize.y) ,
						              str))
						{
							
							
							Application.LoadLevel(levelNames[n-1]);
						}

					}else{
						GUI.enabled=false;
						addButton(GUIHelper.screenRect (offsetX-.05f+j*(levelButtonSize.x+buttonSpaceOffset.x),
													offsetY+i*(levelButtonSize.y+buttonSpaceOffset.y),
													levelButtonSize.x,levelButtonSize.y) ,
							str);

					}


					n++;
				}
			}
		}
		GUI.enabled=true;



		//only show if we have more than 1 page. (if and only used when levels cannot be draw in same page)
		if(m_maxPages>1)
		{
			if( addButton (GUIHelper.screenRect (offsetX-0.05f,offsetY+.45f,.15f,.1f) ,prevPageButtonSTR))
			{
				m_page--;
				if(m_page<0)
				{
					m_page = m_maxPages-1;
				}	

			}
			if( addButton (GUIHelper.screenRect (offsetX+.8f,offsetY+.45f,.15f,.1f) ,nextPageButtonSTR))
			{
				m_page++;
				if(m_page>m_maxPages-1)
				{
					m_page = 0;
				}
			}	
		}
		
		
		if( addButton (GUIHelper.screenRect (offsetX+.25f,offsetY+.45f,.4f,.1f) ,mainMenuButtonSTR))
		{
			
			swapObjects(mainMenuGO);
		}
		GUI.matrix = svMat;
	}
	#endif
#endregion

}
