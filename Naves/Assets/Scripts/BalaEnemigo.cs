using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform componenteTransform;
    Vector3 posicion;
    void Start()
    {
        componenteTransform = transform;
        posicion = componenteTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posicion.z -= 17 * Time.deltaTime;
        componenteTransform.position = posicion;

        if (posicion.z < -13)
        {
            Destroy(this.gameObject);
        }
    }
}
