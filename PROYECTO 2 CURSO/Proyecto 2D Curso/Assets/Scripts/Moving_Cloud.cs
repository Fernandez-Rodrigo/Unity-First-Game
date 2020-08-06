using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Cloud : MonoBehaviour
{

    public Vector3 startPoint;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player_Controler.sharedInstance.GetComponent<Transform>().position.x >= 820)
        {
            animator.enabled = false;
            Player_Controler.sharedInstance.GetComponent<Rigidbody2D>().mass = 6.67f;
            Player_Controler.sharedInstance.jumpForce = 100;
            Player_Controler.sharedInstance.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }

        if(GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            Player_Controler.sharedInstance.GetComponent<Rigidbody2D>().mass = 6.67f;
            Player_Controler.sharedInstance.jumpForce = 100;
            Player_Controler.sharedInstance.GetComponent<Rigidbody2D>().gravityScale = 2f;
        }
        if (GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            animator.Rebind();
            transform.position = startPoint;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && gameObject.tag == "Cloud")
        {
            animator.enabled = true;
        } 
        if (animator.enabled = true)
        {
            Player_Controler.sharedInstance.GetComponent<Rigidbody2D>().mass = 10f;
            Player_Controler.sharedInstance.jumpForce = 500;
            Player_Controler.sharedInstance.GetComponent<Rigidbody2D>().gravityScale = 50f;
        }
    }
}
