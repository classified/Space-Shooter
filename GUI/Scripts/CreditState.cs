using UnityEngine;
using System.Collections;

/*
	Simple credit state
*/
public class CreditState : BaseMenuState
{	
	#region variables
    //our main gameobject
    public GameObject mainMenuGO;
	
    //the background texture
    public Texture backgroundTexture;
	
	
    //the time before switching the credits
    public float fadeTime = 1f;
	
    private float m_fadeTime;
    //our current title
    private int m_index = 0;
	
    //both jobs and authors should be the same number of strings!
    public string[] jobs = {"Programmer","Artist"};
	
    //a list of authors
    public string[] workers = {"VRS","VRS"};
    private Vector3 scale;
    public GameObject AlertBoxPrefeb;
	#endregion

    public void Start ()
    {
        m_index = 0;
	
        //call roll credits
//		StartCoroutine(rollCredits());
    }
    void Update ()
    {
        m_fadeTime -= Time.deltaTime;
        if (m_fadeTime < 0) {
            m_fadeTime = fadeTime;
            int n = jobs.Length;
            m_index++;
            Debug.Log ("Index" + m_index);
            if (m_index >= n) {
                m_index = 0;
            }
        }
        if (Input.GetKeyDown (KeyCode.Escape)) {
            Instantiate (AlertBoxPrefeb, transform.position, transform.rotation);
        }
    }
	
	
    public override void onGUI ()
    {
        GUI.skin = guiSkin0;
		
        float offsetX = transform.position.x + MenuConstants.OFFSET_X;
        float offsetY = transform.position.y + MenuConstants.OFFSET_Y;

        //Scaling GUI MATRIX FOR ALL RESOLUTION
        scale.x = Screen.width / Screen.width;
        scale.y = Screen.height / Screen.height;
        scale.z = 1f;
        var svMat = GUI.matrix;
		
        Debug.Log (scale.x.ToString ());
        Debug.Log (scale.y.ToString ());
        GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

        if (backgroundTexture) {
            GUI.DrawTexture (GUIHelper.screenRect (0, 0, 1, 1), backgroundTexture, ScaleMode.StretchToFill);
        }
        if (m_done) {
            string done;
            GUI.Label (GUIHelper.screenRect (0.25f, 0.4f, .6f, .1f), jobs [m_index]);
            GUI.Label (GUIHelper.screenRect (0.25f, 0.5f, .6f, .1f), workers [m_index]);
						

			
        }
        GUI.Box (GUIHelper.screenRect (offsetX, offsetY, Screen.width, Screen.height), "Credits");
		
        if (addButton (GUIHelper.screenRect (offsetX + .3f, offsetY + .775f, .35f, .1f), " Main Menu")) {
			
            //deactivate this object and activate teh main menu object
            swapObjects (mainMenuGO);
			
        }
        GUI.matrix = svMat;
    }
	

	
}
