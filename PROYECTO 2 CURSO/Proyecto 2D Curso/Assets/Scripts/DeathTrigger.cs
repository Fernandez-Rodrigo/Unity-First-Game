using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("El jugador ha muerto");
            Player_Controler.sharedInstance.Kill();
        }
    }
}
