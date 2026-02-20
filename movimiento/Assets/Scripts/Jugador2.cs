using UnityEngine;

public class Jugador2 : MonoBehaviour
{
    CharacterController componenteCC;
    Vector3 velocidad;
    int saltosActuales;
    int saltosMaximos;
    void Start()
    {
        componenteCC = this.GetComponent<CharacterController>();
        velocidad = Vector3.zero;
        saltosMaximos = 2;
    }

    // Update is called once per frame
    void Update()
    {
        velocidad.x = Input.GetAxis("Horizontal") * 3;
        velocidad.y -= 25 * Time.deltaTime;

        if (componenteCC.isGrounded)
        {
            velocidad.y = -1f;
            saltosActuales = saltosMaximos;
        }

        if ((Input.GetButtonDown("Jump") && saltosActuales > 0))
        {
            velocidad.y = 12;
            saltosActuales--;
        }



        componenteCC.Move(velocidad * Time.deltaTime);
    }
}
