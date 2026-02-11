using UnityEngine;

public class Asteroide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform componente_transform;
    Vector3 posicion;
    float velocidad;

    bool movimiento_derecha;
    bool movimiento_abajo;
    void Start()
    {
        componente_transform = transform;
        posicion = transform.position;
        velocidad = 10;

        movimiento_derecha = true;
        movimiento_abajo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(movimiento_abajo)
        {
            posicion.z -= velocidad * Time.deltaTime;
            if(posicion.z < -12)
            {
                posicion.z = -12;
                movimiento_abajo = false;
            }
        } else {
            posicion.z += velocidad * Time.deltaTime;
            if (posicion.z > 12)
            {
                posicion.z = 12;
                movimiento_abajo = true;
            }
        }

        if (movimiento_derecha)
        {
            posicion.x -= velocidad * Time.deltaTime;
            if (posicion.x < -22)
            {
                posicion.x = -22;
                movimiento_derecha = false;
            }
        }
        else
        {
            posicion.x += velocidad * Time.deltaTime;
            if (posicion.x > 22)
            {
                posicion.x = 22;
                movimiento_derecha = true;
            }
        }
        


        componente_transform.position = posicion;
        if(posicion.z < -13)
        {
            Destroy(this.gameObject);
        }
    }


}
