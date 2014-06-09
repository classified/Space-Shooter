using UnityEngine;
using System.Collections;

public class LoadingScript : MonoBehaviour
{

    public Texture backgroundTexture;
    public string LevelToLoad;
    public Texture[] loadingTexture;
    public Texture loadingTexSize;
    private int LevelDone = 0;
    public GUIStyle noGUIStyle;
    private int textuerMover = 0;
    //GUI scaling Elements
    public GameObject myCamera;
    private float orignalWidth;
    private float orignalHeight;
    private Vector3 scale;


    void Start ()
    {
        LevelDone = 0;
        textuerMover = 0;
        StartCoroutine (ProgressBar (0));
        orignalWidth = Screen.width;
        orignalHeight = Screen.height;
        AdvertisementHandler.EnableAds ();
        AdvertisementHandler.ShowAds ();

    }
    void Update ()
    {
        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
    }
    IEnumerator ProgressBar (float wait)
    {
        while (true) {
            if (textuerMover == 11) {
                textuerMover = 0;
            }
            if (LevelDone == 60) {
                // Application.LoadLevel (LevelToLoad);
                AutoFade.LoadLevel (LevelToLoad, 2, 1, Color.black);
            }
            Debug.Log (LevelDone .ToString ());
            Debug.Log (textuerMover.ToString ());
            LevelDone += 1;
            textuerMover += 1;
            yield return new WaitForSeconds (0.1f);
        }

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

        GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture, ScaleMode.StretchToFill);
        GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 20, 250, 100), "Loading.....", noGUIStyle);

        GUI.matrix = svMat;
    }
}

