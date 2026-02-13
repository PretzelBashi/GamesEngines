using UnityEngine;

public class CreadorEnemigos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float contador;
    Transform componenteTransform;
    public GameObject enemigo;
    void Start()
    {
        contador = 0;
        componenteTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;

        if( contador >= 1.5 )
        {
            contador = 0;
            Instantiate( enemigo, new Vector3(Random.Range(-22f,23f),0,14), Quaternion.identity);
        }

    }
}
