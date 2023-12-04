using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
    {
    // Scene Changer Function
    public void changeScene( string sceneName )
        {
        // Load given scene
        SceneManager.LoadScene( sceneName );
        }

    // Close Game Function
    public void closeGame()
        {
        // Close game
        Application.Quit();
        }

    }
