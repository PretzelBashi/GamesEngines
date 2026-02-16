using UnityEngine;

public class CreadorTuberias : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created -4, 2
    public GameObject prefabTuberias;
    float contador;

    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        contador += 1 * Time.deltaTime;

        if (contador >= 3)
        {
            float posicion_x = Random.Range(-4, 2.1f);
            Instantiate(prefabTuberias, new Vector3(12,posicion_x,0), Quaternion.identity);
            Instantiate(prefabTuberias, new Vector3(12, posicion_x + 3f, 0), Quaternion.Euler(0,0,-180));
            contador = 0;
        }


    }
}
