using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Change : MonoBehaviour
{
    AudioSource audioSource;
    Animator animator;



    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Controler.sharedInstance.GetComponent<Transform>().position.y >= 8.5 && Player_Controler.sharedInstance.GetComponent<Transform>().position.x >= 200)
        {
            audioSource.enabled = true;
            animator.enabled = true;

        }
        else
        {
            audioSource.enabled = false;
            animator.enabled = false;
            
        }
    }
}
