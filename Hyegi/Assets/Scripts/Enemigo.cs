using System;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject jugador;
    Vector3 rotacion;
    void Start()
    {
        rotacion = Vector3.zero;
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        rotacion.y = Herramientas.ObtenerAngulo2D(new Vector2(this.transform.position.x,this.transform.position.z), new Vector2(jugador.transform.position.x, jugador.transform.position.z));
        this.transform.rotation = Quaternion.Euler(rotacion);
    }
}


