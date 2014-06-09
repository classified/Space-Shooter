using UnityEngine;
using System.Collections;

public class AlertBox : BaseMenuState
{

    public Texture BackgroundHolder;
    public Texture Confirmation;
    public Texture ButtonConfirm;
    public Texture ButtonDenied;
    public GUIStyle NoStyle;
    Vector3 scale;

    void Start ()
    {
        Time.timeScale = 0;
    }

    void OnGUI ()
    {
        //Scaling GUI MATRIX FOR ALL RESOLUTION
        scale.x = Screen.width / Screen.width;
        scale.y = Screen.height / Screen.height;
        scale.z = 1f;
        var svMat = GUI.matrix;
        
        Debug.Log (scale.x.ToString ());
        Debug.Log (scale.y.ToString ());
        GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, scale);

        GUI.DrawTexture (new Rect (10, Screen.height / 2 - 50, Screen.width - 20, BackgroundHolder.height), BackgroundHolder);
        GUI.DrawTexture (new Rect (15, Screen.height / 2 - 25, Confirmation.width, Confirmation.height), Confirmation);
        if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 80, 100, ButtonConfirm.height), ButtonConfirm, NoStyle)) {
            Application.Quit ();
        }
        if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2 + 80, 100, ButtonDenied.height), ButtonDenied, NoStyle)) {
            Time.timeScale = 1;
            Destroy (this.gameObject);
        }


        GUI.matrix = svMat;
    }
}
