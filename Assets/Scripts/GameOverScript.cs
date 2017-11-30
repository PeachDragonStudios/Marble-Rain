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

}
