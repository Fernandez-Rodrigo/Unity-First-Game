using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator animator, animator2, animator3;

    public Vector3 startpoint;


    // Start is called before the first frame update

    private void Awake()
    {
        startpoint = this.transform.position;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            this.transform.position = startpoint;
            animator.enabled = false;
            animator.Rebind();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && gameObject.tag == "Elevator")
        {
            animator.enabled = true;
        }
    }

}
