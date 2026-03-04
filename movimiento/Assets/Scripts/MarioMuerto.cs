using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarioMuerto : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector3 posicion;
    float velocidad_y;
    void Start()
    {
        posicion = transform.position;
        velocidad_y = 20;
    }

    // Update is called once per frame
    void Update()
    {      
        posicion.y -= velocidad_y * Time.deltaTime;
        velocidad_y += Time.deltaTime;
        this.transform.position = posicion;

        if(posicion.y < -25)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
