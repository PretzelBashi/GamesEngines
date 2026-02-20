using UnityEngine;

public class Jugador : MonoBehaviour
{
    Transform componenteTransform;
    Vector3 posicion;
    float salto;
    float gravedad;
    float velocidadY;
    float velocidad;
    void Start()
    {
        componenteTransform = transform;
        posicion = transform.position;
        velocidadY = 0;
        velocidad = 5;
        salto = 5;
    }

    // Update is called once per frame
    void Update()
    {
        posicion.x += Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        posicion.y -= velocidadY * Time.deltaTime;
        velocidadY += 35 * Time.deltaTime;

        if (posicion.y < 0)
        {
            posicion.y = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            velocidadY = -15;
        }


        componenteTransform.position = posicion;
    }
}
