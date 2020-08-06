using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cahnge_Background : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_Controler.sharedInstance.GetComponent<Transform>().position.y >= 8.5 && Player_Controler.sharedInstance.GetComponent<Transform>().position.x >= 200)
        {
            animator.enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            animator.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }

        if(GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
          animator.Rebind();
        }
    }
}
