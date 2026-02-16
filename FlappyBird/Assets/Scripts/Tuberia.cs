using UnityEngine;

public class Tuberia : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 posicion;
    ManejadorUI manejadorUI;
    bool activa;
    void Start()
    {
        posicion = transform.position;
        manejadorUI = GameObject.Find("ManejadorUI").GetComponent<ManejadorUI>();
        activa = true;
    }

    // Update is called once per frame
    void Update()
    {
        posicion.x -= 4 * Time.deltaTime;
        transform.position = posicion;

        if (transform.position.x <= -12)
        {
            Destroy(this.gameObject);
        }

        if (posicion.x <= 0 && activa == true)
        {
            if (this.transform.rotation.eulerAngles.z == 0)
            {
                manejadorUI.SumarPunto();
            }
            activa = false;
        }
    }
}
