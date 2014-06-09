using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InputState : BaseMenuState
{
    //a list of controls
    public string[] controls = {"Roll: WASD or arrow keys",
								"Space: Jump"};
	
    //the controls we will display in the label
    private string m_controls;
    //GUI scaling Elements
    public GameObject AlertBoxPrefeb;
    private float orignalWidth;
    private float orignalHeight;
    private Vector3 scale;

    public void Start ()
    {
        //parse the controls
        m_controls = "";
        for (int i=0; i<controls.Length; i++) {
            m_controls += controls [i] + "\n";
        }
        orignalWidth = Screen.width;
        orignalHeight = Screen.height;
    }
    public override void onGUI ()
    {
        GUI.skin = guiSkin0;		
		
        float offsetX = transform.position.x + MenuConstants.OFFSET_X;
        float offsetY = transform.position.y + MenuConstants.OFFSET_Y;

        //Scaling GUI MATRIX FOR ALL RESOLUTION
        scale.x = Screen.width / orignalWidth;
        scale.y = Screen.height / orignalHeight;
        scale.z = 1f;
        var svMat = GUI.matrix;
		
        Debug.Log (scale.x.ToString ());
        Debug.Log (scale.y.ToString ());
        GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

        //draw the box
        GUI.Box (GUIHelper.screenRect (offsetX + 0.425f, offsetY + 0.4f, Screen.width, Screen.height), "Input Menu");
		
		
        //draw the label for controls
        GUI.Label (GUIHelper.screenRect (offsetX + 0.435f, offsetY + 0.5f, .45f, .8f), m_controls);

        GUI.matrix = svMat;
    }	
    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            Instantiate (AlertBoxPrefeb, transform.position, transform.rotation);
        }
    }
}
