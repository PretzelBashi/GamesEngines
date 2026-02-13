using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Transform componente_transform;
    Vector3 posicion;
    int direccion;

    public GameObject prefabBala;
    float contador;
    void Start()
    {
        componente_transform = transform;
        posicion = componente_transform.position;
        direccion = 1;
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime; 
        if(contador >= 1)
        {
            contador = 0;
            Instantiate(prefabBala, new Vector3(posicion.x+0.5f, posicion.y, posicion.z - 2 ), Quaternion.identity);
            Instantiate(prefabBala, new Vector3(posicion.x-0.5f, posicion.y, posicion.z - 2 ), Quaternion.identity);
        }


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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "balaJugador")
        {
            Destroy(this.gameObject);
        }
    }
}
