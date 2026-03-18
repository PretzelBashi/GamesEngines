using UnityEngine;

public class Camara : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject Jugador;
    Vector3 rotacion;
    Vector3 posicion;
    void Start()
    {
        Jugador = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            rotacion.y += 100 * Time.deltaTime;
        }

        if (Input.GetKey("q"))
        {
            rotacion.y -= 100 * Time.deltaTime;
        }

        posicion = new Vector3(Jugador.transform.position.x, Jugador.transform.position.y+1.5f, Jugador.transform.position.z);
        transform.position = posicion;
        transform.rotation = Quaternion.Euler(rotacion);
    }
}
