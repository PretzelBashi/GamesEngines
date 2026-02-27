using UnityEngine;
using UnityEngine.UI;

public class ManejadorGameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    GameObject objetoTextoPuntuacion;
    Text componenteTextoPuntuacion;
    public Text textoPuntuacionMaxima;
    void Start()
    {
        objetoTextoPuntuacion = GameObject.Find("TextoPuntuacion");
        componenteTextoPuntuacion = objetoTextoPuntuacion.GetComponent<Text>();
        componenteTextoPuntuacion.text = "Puntuacion " + DatosPasar.puntuacion;

        if (DatosPasar.puntuacion > PlayerPrefs.GetInt("PuntuacionMaxima", 0))
        {
            PlayerPrefs.SetInt("PuntuacionMaxima", DatosPasar.puntuacion);
        }

        textoPuntuacionMaxima.text = "Maxima alcanzada: " + PlayerPrefs.GetInt("PuntuacionMaxima",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
