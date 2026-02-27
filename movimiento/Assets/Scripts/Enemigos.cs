using UnityEngine;

public class Enemigos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float posicion_x;
    int direccion;
    CharacterController componenteCC;
    Vector3 velocidad;
    void Start()
    {
        componenteCC = this.GetComponent<CharacterController>();
        direccion = 5;
        velocidad = new Vector3(2,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        componenteCC.Move(velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "goomba_pared")
        {
            direccion = direccion * -1;
        }
    }
}
