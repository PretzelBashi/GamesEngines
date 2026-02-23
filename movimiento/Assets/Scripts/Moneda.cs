using UnityEngine;

public class Moneda : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0,350 * Time.deltaTime,0));
    }
}
