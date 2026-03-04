using TMPro;
using UnityEngine;

public class CambiarTexto : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textoPro;
    public TMP_Text textoPro1;

    void Start()
    {
        textoPro.text = "Hola pero en pro";
        textoPro.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
