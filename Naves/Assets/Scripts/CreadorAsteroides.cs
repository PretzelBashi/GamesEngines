using UnityEngine;

public class CreadorAsteroides : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject asteroides;
    Transform componente_transform;
    float contador;
    float respawn;
    Vector3 lugarCreacionAsteroide;
    void Start()
    {
        contador = 0;
        componente_transform = transform;
        respawn = 3;
    }

    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;

        if ( contador > respawn )
        {
            respawn -= 0.1f;
            if (respawn <= 0) respawn = 0.5f;   
            contador = 0;
            lugarCreacionAsteroide = new Vector3(-22 + Random.value * 44, 0, 13);
            Instantiate(asteroides, lugarCreacionAsteroide, new Quaternion(0,0,0,0));
        }
    }
}
