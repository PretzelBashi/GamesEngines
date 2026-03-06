using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    CharacterController characterController;
    Vector3 velocidad;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocidad = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        velocidad.x = Input.GetAxis("Horizontal") * 2;
        velocidad.z = Input.GetAxis("Vertical") * 2;

        velocidad.y -= 10 * Time.deltaTime;



        if(characterController.isGrounded)
        {
            velocidad.y = -5;
            if (Input.GetButtonDown("Jump"))
            {
                velocidad.y = 7;
            }
        }

        characterController.Move(velocidad * Time.deltaTime);
    }
}
