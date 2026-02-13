
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Transform componenteTransform;
    Vector3 posicion;
    Vector3 rotacion;
    void Start()
    {
        componenteTransform = transform;
        posicion = componenteTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posicion.z -= 17 * Time.deltaTime;
        rotacion.x += Time.deltaTime * 400;

        componenteTransform.position = posicion;
        componenteTransform.rotation = Quaternion.Euler(rotacion);

        if (posicion.z < -13)
        {
            Destroy(this.gameObject);
        }
    }
}
