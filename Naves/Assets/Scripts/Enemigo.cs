using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Transform componente_transform;
    Vector3 posicion;
    int direccion;
    void Start()
    {
        componente_transform = transform;
        posicion = componente_transform.position;
        direccion = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (direccion == 1)
        {
            if (posicion.x > 22)
            {
                posicion.x = 22;
                direccion = -1;
            }
        }
        else
        {
            if (posicion.x < -22)
            {
                posicion.x = -22;
                direccion = 1;
            }
        }

        if(posicion.z < -13)
        {
            Destroy(this.gameObject);
        }

        posicion.z -= 5 * Time.deltaTime;
        posicion.x += direccion * 5 * Time.deltaTime;
        componente_transform.position = posicion;
    }
}
