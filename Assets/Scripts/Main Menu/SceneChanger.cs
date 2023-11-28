using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
    {
    // Scene Changer Function
    public void changeScene()
        {
        // Load given scene
        SceneManager.LoadScene( "level" );
        }

    }
