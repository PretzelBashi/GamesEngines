using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject objetoCanvasVidas;
    Text componenteTextVida;
    Text componenteTextPuntuacion;
    int puntuacion;
    void Start()
    {
        objetoCanvasVidas = GameObject.Find("Canvas_Vidas");
        componenteTextVida = objetoCanvasVidas.GetComponent<Text>();
        componenteTextPuntuacion = GameObject.Find("Canvas_Puntuacion").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualizarVidas(int vidasActuales)
    {
        componenteTextVida.text = "Vidas: " + vidasActuales;
        if (vidasActuales <= 0)
        {
            CompartirDatos.puntuacion = puntuacion;
        }
    }

    public void ActualizarPuntuacion(int puntuacionRecibida)
    {
        puntuacion += puntuacionRecibida;
        componenteTextPuntuacion.text = "Puntuacion: " + puntuacion;
    }
}
