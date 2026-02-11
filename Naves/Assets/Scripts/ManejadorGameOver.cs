using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManejadorGameOver : MonoBehaviour
{
    Text textoPuntuacion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoPuntuacion = GameObject.Find("GameOverPuntuacion").GetComponent<Text>();
        textoPuntuacion.text = "Puntuacion: " + CompartirDatos.puntuacion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegresarInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
}
