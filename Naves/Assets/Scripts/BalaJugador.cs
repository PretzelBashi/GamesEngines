using UnityEngine;

public class BalaJugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform componente_transform;
    Vector3 posicion;
    NewMonoBehaviourScript componenteManejadorUI;

    void Start()
    {
        componente_transform = transform;
        posicion = componente_transform.position;
        componenteManejadorUI = GameObject.Find("ManejadorUI").GetComponent<NewMonoBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        posicion.z += 15 * Time.deltaTime;
        componente_transform.position = posicion;

        if ( posicion.z > 13 )
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "asteroide")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            componenteManejadorUI.ActualizarPuntuacion(10);
        }

        if (collision.gameObject.tag == "enemigo")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            componenteManejadorUI.ActualizarPuntuacion(10);
        }
    }
}
