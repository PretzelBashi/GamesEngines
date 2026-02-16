using UnityEngine;
using UnityEngine.UI;

public class ManejadorUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Text componenteTextoPuntuacion;
    float puntos;
    void Start()
    {
        componenteTextoPuntuacion = GameObject.Find("TextoPuntuacion").GetComponent<Text>();
        puntos = 0;
    }

    // Update is called once per frame
    public void SumarPunto()
    {
        componenteTextoPuntuacion.text = "Puntos: " + ++puntos;
    }
}
