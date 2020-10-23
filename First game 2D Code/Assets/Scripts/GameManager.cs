using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum GameState  // Posibles estados del videojuego
{
    menu,
    inGame,
    gameOver,
    pause,
    end
}



public class GameManager : MonoBehaviour   // El game manager se encargar de administrar las distintas partes del juego, por encima del personaje, nivel, plataformas, etc. Puede haber varios que manejen ciertos aspectos o rubros como inventario, tiendas, misiones, etc.
{

    public static GameManager sharedInstance;   // Esto permite que no se creen muchos game managers que manejen lo mismo, ahora cuando algún script llame al game manager para definir un momento de juego tendrá que pasar por este que programamos acá. Será GameManager.sharedInstance.menu o inGame o gameOver

    public GameState currentGameState = GameState.menu;   // Esto indica en qué estado nos encontramos ahora mismo, al inicio esperamos que esté en el menú principal

    public Canvas menuCanvas, ingameCanvas, gameoverCanvas, pauseCanvas, credits;   // se pueden declarar en una línea si salen de la  misma clase

    public int collectedObjects = 0;

    public float Timer = 0f;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        BackToMenu();
        
    }

    private void Update()
    {
        //  if (Input.GetKeyDown(KeyCode.S))  //Esto solo funciona para PC ya que en consola no existe la S...
        //Si lo quiero hacer multiplataformas, debo trabajar con botones que configuro en otro lado
        if (Input.GetButtonDown("Start") && currentGameState != GameState.inGame) //Luego definiremos qué es el boton start en "Edit/Project settings"
        {
            StartGame();
        }
        if (Input.GetButtonDown("Pause") && currentGameState == GameState.pause)
        {
            currentGameState = GameState.inGame;
            pauseCanvas.enabled = false;
        }
        else if (Input.GetButtonDown("Pause") && currentGameState == GameState.inGame)
        {
            currentGameState = GameState.pause;
            pauseCanvas.enabled = true;


        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }

        if (currentGameState == GameState.inGame)
        {
            Timer += Time.deltaTime;
        }
        else
        {
            Timer = 0;
        }

        if(currentGameState == GameState.end)
        {
            credits.enabled = true;
        }

   
    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
        Player_Controler.sharedInstance.StartGame();
        menuCanvas.enabled = false;
        gameoverCanvas.enabled = false;
        ingameCanvas.enabled = true;
        this.collectedObjects = 0;
        pauseCanvas.enabled = false;
        this.Timer = 0;
        credits.enabled = false;
        
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
        menuCanvas.enabled = false;
        ingameCanvas.enabled = false;
        gameoverCanvas.enabled = true;
        pauseCanvas.enabled = false;
        credits.enabled = false;
       
    }


    public void BackToMenu()
    {
        SetGameState(GameState.menu);
        menuCanvas.enabled = true;
        ingameCanvas.enabled = false;
        gameoverCanvas.enabled = false;
        credits.enabled = false;
    }

    public void PauseGame()
    {
        SetGameState(GameState.pause);
        if (currentGameState == GameState.pause)
        {
            menuCanvas.enabled = false;
            ingameCanvas.enabled = true;
            gameoverCanvas.enabled = false;
            credits.enabled = false;
        }
    }


    public void EndGame()
    {
        SetGameState(GameState.end);
        if (currentGameState == GameState.end)
        {
            menuCanvas.enabled = false;
            ingameCanvas.enabled = false;
            gameoverCanvas.enabled = false;
            credits.enabled = true;
        }

    }


    public void ExitGame()
    {
        Application.Quit();
    }


    //Método encargado en cambiar el estado del juego
    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //Se programa para que muestre el menu
        }
        else if (newGameState == GameState.inGame)
        {
            // Se programa para que muestre la escena del juego
        }
        else if (newGameState == GameState.gameOver)
        {
            // Se programa para que muestre el game over
        }
        








            this.currentGameState = newGameState;
    }

    public void CollectObjects(int objectValue)    // El object value dirá en cuánto incrementará el valor del contador
    {
        this.collectedObjects += objectValue;
        Debug.Log(objectValue);
    }

}
