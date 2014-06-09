using UnityEngine;
using System.Collections;

public class FaceBookPicture : MonoBehaviour
{
    public Texture2D ProfilePic ;

    public void Start ()
    {
        Debug.Log ("Checking with facebook");
        StartCoroutine ("FBLoginCheck");
    }
    
    IEnumerator FBLoginCheck ()
    {
        yield return new WaitForSeconds (0f);
        Debug.Log ("Entered in spawn waves");
        // one way to get the current user's profile picture into Unity
        if (FB.IsLoggedIn) {
            string url = "https" + "://graph.facebook.com/" + FB.UserId + "/picture";
            url += "?access_token=" + FB.AccessToken;
            WWW www = new WWW (url);
            yield return www;
            ProfilePic = www.texture;
        }
    }   
    void OnGUI ()
    {
        GUI.DrawTexture (new Rect (0, 0, ProfilePic.width, ProfilePic.height), ProfilePic);
    }
}
