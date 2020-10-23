using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour

//  VAMOS A DEJAR CREADO ESTE SCRIPT POR SI LO NECESITO EN UN FUTURO, ES EL FORMATO PARA GENERAR NIVELES ALEATORIOS

{


    //   public static Level_Generator sharedInstance;  // Esto hacemos por que es una variable única, no puede haber 2 controladores de niveles

    // public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();  // De aquí toma todos los bloques que vamos creando, el LevelBlock sale de otro script, se agregan los prefabs en unity al level_generator

    //  public Transform levelStartPoint;  // Se genera como un empty object, y se lo asigna al Level Generator para indicar donde empieza a generar los niveles

    //public List<LevelBlock> currentBlocks = new List<LevelBlock>();  // Esta lista se irá rellenando automáticamente con los bloques


    public void Awake()
    {
        //      sharedInstance = this;
    }

    public void AddLevelBlock()  // Metodo para generar un nuevo nivel de bloques
    {
        //    int randomIndex = Random.Range(0, allTheLevelBlocks.Count);  // Random.Range(a, b) genera un número aleatorio entre a<= x <b

        //   LevelBlock currentBlock = (LevelBlock)Instantiate(allTheLevelBlocks[randomIndex]); // instanciar es llevar un objeto de la carpeta assets al juego en si, en este caso instanciamos el objeto que generó el random index en el paso anterior, esta función devuelve un game object pero yo 
        // necesito un LevelBlock, por eso se agrega en tre () al principio
        //   currentBlock.transform.SetParent(this.transform, false);  // esta línea pone como hijo del level_generator a cada bloque que se crea

        Vector3 spawnPosition = Vector3.zero;  //Acá defino donde va a generarse el nuevo bloque

        //     if(currentBlock.Count == 0)  // Si no existen bloques..
        {
            //      spawnPosition = levelStartPoint.position; // Se genera en el start point, definido en la escena
        }
        //     else
        //   {
        //      spawnPosition = currentBlocks[currentBlock.Count - 1].exitPoint.position;  // sino, se genera en el exit point.
        //     }
        //
        //  spawnPosition correction = new Vector3(spawnPosition.x - currentBlock.startPoint.position.x,  //Esta lìnea me permite poner el start point donde desee para que salga ahì, sino unity toma el centro de la escena como start point, y si lo movemos mueve el nivel entero
        //                                         spawnPosition.y - currentBlock.startPoint.position.y,
        //                                             0);
        //
        //   currentBlock.transform.position = correction;
        //   currentBlock.Add(currentBlock); 

        //  }

        // public void RemoveOldestBlock()  // Elimina el grupo de bloques que se deja atras
        //  {
        //      LevelBlock oldestBlock = CurrentBlock[0];
        //      currentBlock.Remove(oldestBlock);   Acá lo elimino de la lista
        //      Destroy(oldestBlock);              Acá lo elimino de la pantalla
        //  }
        //
        //   public void RemoveAllTheBlocks()  // Cuando se pierde tengo que borrar todos los bloques generados
        //  {
        //      while (currentBlocks.Count > 0)   Mientras haya bloques
        //        {
        //           RemoveOldestBlock();     ejecuto el removedor de bloques viejos
        //        }

        //  }
        //
        // public void GenerateStartBlocks()  // Debe generar los primeros 2 niveles al principio
        //   {
        //      for(int i = 0; i < 2; i++){           Esto sirve para generar los bloques, apareceran 2 al principio y se irán sumando
        //            AddLevelBlock();}
        //   }


    }
}
