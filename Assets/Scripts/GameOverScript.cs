using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    /*
     * When "Play Again?" button is pressed, it loads the game scene
     */
    public void OnPlayAgain()
    {
        SceneManager.LoadScene(0);
    }


    //Should only works on phone versions of game
    //Needs tested
    public void OnShareScore()
    {

        //Majority of code for OnShareScore() is from user OJ3D on Unity fourm

        string URL = "msg";
        string mobileNum = "your number";
        string msg1 = "I got ";
        string msg2 = "in Marble Rain, how will you do?";

    #if UNITY_ANDROID
        URL = string.Format("sms:{0}?body={1}", mobile_num, System.Uri.EscapeDataString(msg1 + ScoreManager.instance.totalPoints + msg2));

    #endif

    #if UNITY_IOS
        URL = "sms: " + mobileNum + "?&body=" + System.Uri.EscapeDataString(msg1 + ScoreManager.instance.totalPoints + msg2);
   
    #endif

        Application.OpenURL(URL);
    }

}
