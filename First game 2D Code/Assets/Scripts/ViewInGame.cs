using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Necesito agregar este paquete para modificar los elementos de la interface gráfica que ve el usuario
public class ViewInGame : MonoBehaviour
{
    public Text collectableLabel;
    public Text scoreLabel;
  



    // Update is called once per frame
    void Update()
    {
        if(GameManager.sharedInstance.currentGameState == GameState.inGame || GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            int currentObjects = GameManager.sharedInstance.collectedObjects;
            this.collectableLabel.text = currentObjects.ToString();
        
        }
        if(GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            float timeScore = GameManager.sharedInstance.Timer; ;
            this.scoreLabel.text = "Time\n" + timeScore.ToString("f2");
        }
    }
}
