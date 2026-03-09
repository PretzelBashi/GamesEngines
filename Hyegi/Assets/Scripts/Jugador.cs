using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    CharacterController characterController;
    Vector3 velocidad;
    Vector3 rotacion;

    Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocidad = Vector3.zero;
        rotacion = Vector3.zero;
        animator = this.transform.GetChild(0).GetComponent<Animator>();
    }


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

        if(velocidad.x != 0 || velocidad.z != 0)
        {
            rotacion.y = Herramientas.ObtenerAngulo2D(new Vector2(0, 0), new Vector2(velocidad.x, velocidad.z));            
        }

 


        characterController.Move(velocidad * Time.deltaTime);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), 2);
    }
}
