using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    public static Player_Controler sharedInstance;  // Para que sea un jugador único como el game manager

    public float jumpForce = 5f;

    public Rigidbody2D rigidbody;

    public LayerMask groundLayer;

    public Animator animator;  // Llamo a animator para poder modificar las animaciones

    public float runningSpeed = 1.5f;

    private Vector3 startPosition;

    public int healthPoint, manaPoint;



    private void Awake()
    {
        sharedInstance = this;
        rigidbody = GetComponent<Rigidbody2D>(); //Esto es para que busque el componente rigidbody del personaje dentro de mis gameobjects
        startPosition = this.transform.position;  //Defino el valor de donde empieza el personaje, y mas abajo en el start uso ese valor para indicar donde debe estar
    }


    // Start is called before the first frame update
    public void StartGame()
    {
        animator.SetBool("isAlive", true);   //Inidico que al empezar el juego el personaje está vivo y en el suelo 
        animator.SetBool("isGrounded", true);
        this.transform.position = startPosition; //Cada vez que reiniciamos ponemos al pj en este lugar
        healthPoint = 100;
        manaPoint = 30;
     

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)  // Solo se puede saltar si estamos en ingame
        {
            if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))  // Los botoens del mouse son 0 el de la izq y 1 el de la derecha, ahora puede saltar con ambos
            {
                //Acá se pulsó la tecla espacio, no vamos a programar el salto en esta parte para dejar lo mas limpio posible la parte del update, vamos a generar otro método que ejecutará el salto.
                Jump();
            }

            animator.SetBool("isGrounded", IsTouchingTheGround());
        }

        if (GameManager.sharedInstance.currentGameState == GameState.pause || GameManager.sharedInstance.currentGameState == GameState.end)
        {
            rigidbody.bodyType = RigidbodyType2D.Static;
        }
        else { rigidbody.bodyType = RigidbodyType2D.Dynamic; }



    }

    private void FixedUpdate()   // Correr siempre va en el fix update, ya que en el update si hay bajadas de frames puede generar problemas con los movimientos, se llama por intervalos fijos sin importar nada, el update va por frames
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)  // Solo se puede mover si estamos en ingame
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (rigidbody.velocity.x < runningSpeed)  // Si el rigidbody tiene una velocidad menor que el tope de runningspeed, la veolocidad del rigidbody será un vector de 2 coordenadas (x e y), donde la velocidad del eje x será la que configuramos en runningspeed y la del eje y la que tuviera
                {                                           //  al momento de ejecutar el movimiento de salto, sino al saltar se quedaría en el lugar.
                    rigidbody.velocity = new Vector2(runningSpeed, rigidbody.velocity.y);
                    transform.localScale = new Vector2(1.2f, 1.2f);
                }
            }



            if (Input.GetKey(KeyCode.A))
            {
                if (rigidbody.velocity.x > -runningSpeed)  // Esto sirve para que el personaje vaya para atrás, aplicamos una velocidad negativa.
                {
                    rigidbody.velocity = new Vector2(-runningSpeed, rigidbody.velocity.y);
                    transform.localScale = new Vector2(-1.2f, 1.2f);
                }
            }

        }
    }

    void Jump()
    {
        if (IsTouchingTheGround())
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else if (manaPoint >= 10)
        {      
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            manaPoint -= 10;
        }
    }
        // acá llamamos al rigidbody, le aplicamos una fuerza, la misma será en sentido vertical y se multiplica por la fuerza de salto que al principio es un valor genérico. Después agrego el tipo de fuerza que se va a 
        // aplicar, el forcemode2d puede ser un impulso o una fuerza constante, al ser un salto, claramente es un impulso
        // Para completar bien esto tenemos que entender que se aplica la función Fuerza = masa x aceleración, mi fuerza la definí al principio, y mi masa está en el apartado rigidbody del personaje, en "mass", tiene 1 por defecto y quiere decir que pesa 1 kg
        // si ponemos auto mass va a aplicar un peso que el programa considera adecuado para un objeto de esas características. Mientras mayor sea la masa, más fuerza voy a necesitar para que genere altura. Al ser una variable pública puedo modificarlo en tiempo real.



        bool IsTouchingTheGround()
        {
            if (Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer))   // Acá estamos usando la técnica del raycast, todo objeto puede tirar rayos invisibles para medir distancias, entonces para evitar el doble salto vamos a tirar un rayo para abajo a ver que tan cerca
            {                                                                                  // estamos del suelo, en este caso indicamos la posición, indicamos que tire para abajo, a 0,2 metros del suelo y llamamos a groundLayer definida al principio que sirve para detectar la capa del suelo
                return true;
            }
            else
            {
                return false;
            }
        }

    public void Kill()
    {
        GameManager.sharedInstance.GameOver();
        this.animator.SetBool("isAlive", false);

        float currentMaxScore = PlayerPrefs.GetFloat("MaxScore", 999);  // PlayerPrefs se encarga de guardar datos de la partida para que cuando se cierra el juego, aparezcan así en la próxima vez. En este caso guardo un valor con la clave "MaxScore"
         if(currentMaxScore >= GameManager.sharedInstance.Timer)       // En caso de que no haya valor guardado será 0
        {
            PlayerPrefs.SetFloat("MaxScore", GameManager.sharedInstance.Timer);   // en caso de que el tiempo logrado sea menor que el tiempo del max score, va a guardar el tiempo logrado
        }
           
    }

    public void CollectHeal(int points)   // En este caso estos métodos los hace el player controler por que afectan directamente al jugador, no así las monedas que son del juego, no del jugador
    {
        this.healthPoint += points;

        if(healthPoint >= 150)
        {
            healthPoint = 150;
        }

        
    }

    public void CollectMana(int points)
    {
        this.manaPoint += points;

        if(manaPoint >= 100)
        {
            manaPoint = 100;
        }
    }

    public int GetHealth()
    {
        return this.healthPoint;
    }

    public int GetMana()
    {
        return this.manaPoint;
    }

}   

