using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [ SerializeField ] GameObject welcomeText;
    [ SerializeField ] GameObject objectiveText;
    [ SerializeField ] GameObject enemyText;
    [ SerializeField ] GameObject continueText;


    // Update is called once per frame
    void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space)) 
            {
            if( welcomeText.activeSelf )
                {
                welcomeText.SetActive(false);
                objectiveText.SetActive(true);
                }

            else if( objectiveText.activeSelf )
                {
                objectiveText.SetActive(false);
                enemyText.SetActive(true);
                }

            else if( enemyText.activeSelf )
                {
                enemyText.SetActive(false);
                continueText.SetActive(false);
                }

            }    

        }
}
