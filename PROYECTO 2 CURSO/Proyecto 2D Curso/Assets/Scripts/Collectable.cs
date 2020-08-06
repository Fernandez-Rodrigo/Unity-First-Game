using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType  // Cuando tenemos varios coleccionables podemos hacer un enumerado para trabajar mas cómodos
{
    healthPotion,
    manaPotion,
    money
}

public class Collectable : MonoBehaviour
{
    public bool isCollected = false; // Para saber si la variable fue recogida o no
    public int value = 0;

    public CollectableType type;  // Al agregar esta línea a cada objeto le va a aparecer un desplegable que me permitirá elegir si son pociones o monedas


    public void Show()  //Metodo para recolectar
    {
        isCollected = false;


        this.GetComponent<SpriteRenderer>().enabled = true;

        if (gameObject.tag == "Coins")
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (gameObject.tag == "Diamond")
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;
        }
        if (gameObject.tag == "Potion")
        {
            this.GetComponent<PolygonCollider2D>().enabled = true;
        }

    }

    void Hide()  // Metodo para ocultar la moneda y el collider        Si destruyese el game object, cuando aparece el nuevo nivel no existe la moneda, esto sirve cuando generas niveles aleatorios
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        if (gameObject.tag == "Coins")
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
        }

        if (gameObject.tag == "Diamond")
        {
            this.GetComponent<PolygonCollider2D>().enabled = false;
        }

        if (gameObject.tag == "Potion")
        {
            this.GetComponent<CapsuleCollider2D>().enabled = false;
        }

    }

    void Collect()
    {
        isCollected = true;
        Hide();


        switch (this.type)              // switch sirve cuando tenemos enumeradores o varios typos, podemos indicar que pasa en cada caso, el switch es como el if else, if else, if else pero junto.
        {
            case CollectableType.money:      // Si es un typo moneda, aplicar el valor value de la forma que hicimos en un principio
                GameManager.sharedInstance.CollectObjects(value);
                break;
            case CollectableType.healthPotion:
                Player_Controler.sharedInstance.CollectHeal(value);
                break;
            case CollectableType.manaPotion:
                Player_Controler.sharedInstance.CollectMana(value);
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            Collect();
        }
    }

    private void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            isCollected = false;
            this.GetComponent<SpriteRenderer>().enabled = true;
            
            if (gameObject.tag == "Coins")
            {
                GetComponent<CircleCollider2D>().enabled = true;
            }

            if (gameObject.tag == "Diamond")
            {
                GetComponent<PolygonCollider2D>().enabled = true;
            }
            if(gameObject.tag == "Potion")
            {
                GetComponent<CapsuleCollider2D>().enabled = true;
            }

        }

    }
}
