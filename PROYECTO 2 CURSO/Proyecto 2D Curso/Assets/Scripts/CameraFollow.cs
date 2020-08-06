using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public Vector2 offset = new Vector2 (5.0f, 1.1f);    //que distancia va a dejar en x y en y para seguir al jugador

    public float dumpTime = 0.3f;  // El tiempo que queda estática una vez comienza el juego

    public Vector3 velocity = Vector3.zero;  //velocidad con la que sigue al personaje

    private void Awake()
    {
        Application.targetFrameRate = 60;  // La cantidad de frames que intento que unity renderice para la cámara
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);  // Esta es la ubicación visto desde la cámara, no desde el universo de unity donde está el personaje - Donde está ahora la cámara

        Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(offset.x, offset.y, point.z));  //Acá defino lo contrario, desde el mundo hacia la cámara. - La cantidad que tiene que moverse

        Vector3 destination = point + delta;  // donde estaba más el movimiento

        destination = new Vector3(target.position.x, target.position.y, -10f); // Con esto solo se mueve en x la cámara

        this.transform.position = Vector3.SmoothDamp(this.transform.position, destination, ref velocity, dumpTime);               // SmoothDamp mueve la cámara de forma suave
    }
}
