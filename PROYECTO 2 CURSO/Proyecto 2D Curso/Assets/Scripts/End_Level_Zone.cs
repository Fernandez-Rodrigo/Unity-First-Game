using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Level_Zone : MonoBehaviour
{

    public GameObject Level3;

    private void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            Destroy(GameObject.Find("Level_3(Clone)"));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Instantiate(Level3);

    }

}

