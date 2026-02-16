using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform componente_transform;
    Vector3 posicion;
    float velocidadY;
    void Start()
    {
        componente_transform = transform;
        posicion = Vector3.zero;
        velocidadY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        velocidadY += 40f * Time.deltaTime;
        posicion.y -= velocidadY * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            velocidadY = -10;
        }

        if (posicion.y < -6.5)
        {
            posicion.y = 6.5f;
        }

        componente_transform.position = posicion;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "tuberia")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
