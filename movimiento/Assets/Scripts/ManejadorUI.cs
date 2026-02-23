using UnityEngine;
using UnityEngine.UI;

public class ManejadorUI : MonoBehaviour
{
    public Text componenteTextoMonedas;
    int monedas;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TomarMoneda()
    {
        monedas++;
        componenteTextoMonedas.text = "x " + monedas;
    }
}
