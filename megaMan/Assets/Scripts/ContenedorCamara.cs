using UnityEngine;

public class ContenedorCamara : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform jugador;
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float distancia = Vector3.Distance(this.transform.position, jugador.transform.position);

        this.transform.position = Vector3.MoveTowards(this.transform.position, jugador.position, distancia * 3 * Time.deltaTime);
    }
}
