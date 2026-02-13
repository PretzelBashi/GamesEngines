using UnityEngine;

public class CreadorPowerUps : MonoBehaviour
{
    Transform componenteTransform;
    public GameObject powerUp;
    void Start()
    {
        Invoke("CrearPowerUp", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CrearPowerUp()
    {
        Instantiate(powerUp, new Vector3(Random.Range(-22f, 23f), 0, 14), Quaternion.identity);
        Invoke("CrearPowerUp", 3);
    }
}
