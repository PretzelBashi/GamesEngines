using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejadorInicio : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComenzarJuego()
    {
        SceneManager.LoadScene("Juego");
    }
}
