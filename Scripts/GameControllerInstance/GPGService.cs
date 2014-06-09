using UnityEngine;
using System.Collections;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.SocialPlatforms;

public class GPGService : MonoBehaviour
{
    private enum GPLoginState
    {
        loggedout,
        loggedin}
    ;
    private GPLoginState m_loginState = GPLoginState.loggedout;
    bool needFullSignin = false;
    private string dataToSave = "Hello World";
    
    private string testLeaderBoard = "< GPG Leaderboard ID >";
    private string testAchievement = "< Unlock Achievement ID >";
    private string testIncAchievement = "< Incremental Achievement ID >";
    private int testIncACTotalSteps = 20;
    
    double currACPercent = -1;
    double onReportACPercent = 0;
    // Use this for initialization
    void Start ()
    {
        Social.Active = new UnityEngine.SocialPlatforms.GPGSocial ();
        Social.localUser.Authenticate (OnAuthCB);

    }
	
    public void LeaderBoardShow ()
    {
        Debug.Log ("In Leaderboards");
        if (Social.localUser.authenticated) {
            Debug.Log ("In Leaderboards");
            NerdGPG.Instance ().showLeaderBoards (testLeaderBoard);
        }

    }
    public void SubmitScoreToLeaderBoards ()
    {
        Debug.Log ("Submitting score to Lead");
        Social.ReportScore (GameController.score, testLeaderBoard, OnSubmitScore);
    }
    public void AchivementShow ()
    {
        Social.ShowAchievementsUI ();
        // See if we have loaded the achievement list
        if (NerdGPG.Instance ().acList == null)
            GUI.enabled = false;
        else {
            // Check if the achievement we are trying to increment is in the ac list
            foreach (IAchievement ac in NerdGPG.Instance().acList) {
                if (ac.id == testIncAchievement) {
                    currACPercent = ac.percentCompleted;
                }
            }
        }
        // If we didnt find the achievement or if its already unlocked disable the increment button
        if (currACPercent < 0 || currACPercent >= 100) {
            Debug.Log (" Can't find or it's already Unlocked.");
        }

    }
    public void UnlockAchivement ()
    {
        Social.ReportProgress (testAchievement, 100.0, OnUnlockAC);
    }
    public void UnlockedAchivementDiscription ()
    {
        Social.LoadAchievementDescriptions (OnLoadACDesc);
    }
    public void LoadedAchivements ()
    {
        Social.LoadAchievements (OnLoadAC);
    }

    // Generating Health of the Result
    void OnAuthCB (bool result)
    {
        Debug.Log ("GPGUI: Got Login Response: " + result);
    }
    public void OnSubmitScore (bool result)
    {
        Debug.Log ("GPGUI: OnSubmitScore: " + result);
    }
    public void OnUnlockAC (bool result)
    {
        Debug.Log ("GPGUI: OnUnlockAC " + result);
    }
    public void OnLoadAC (IAchievement[] achievements)
    {
        Debug.Log ("GPGUI: Loaded Achievements: " + achievements.Length);
    }
    
    public void OnLoadACDesc (IAchievementDescription[] acDesc)
    {
        Debug.Log ("GPGUI: Loaded Achievement Description: " + acDesc.Length);
    }
}
