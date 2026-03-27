using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    Vector3 velocidad;
    Vector3 rotacion;

    CharacterController characterController;
    Transform modeloPersonaje;
    PlayerInput playerInput;
    Vector2 input_movimiento;
    int estado_animacion;

    float contador_disparando;
    float contador_dasheando;

    bool disparando;
    bool dasheando;

    Animator animator;
    void Start()
    {
        velocidad = Vector3.zero;
        rotacion = new Vector3(0,0,0);

        characterController = this.GetComponent<CharacterController>();
        modeloPersonaje = this.transform.GetChild(0);
        playerInput = this.GetComponent<PlayerInput>();
        animator = this.transform.GetChild(0).GetComponent<Animator>();
        animator.SetInteger("Estado", 0);
        animator.SetTrigger("CambioEstado");
        estado_animacion = 0;

        disparando = false;
        contador_disparando = 0;

        dasheando = false;
        contador_dasheando = 0;

    }

    
    void Update()
    {
        /*if (playerInput.actions["Jump"].ReadValue<bool>())
        {
            Debug.Log("Salto");
        }*/
        input_movimiento = playerInput.actions["Move"].ReadValue<Vector2>();


        if(disparando)
        {
            contador_disparando += Time.deltaTime;
        }

        if(contador_disparando > 2)
        {
            disparando = false;
        }

        if (dasheando)
        {
            velocidad.x = input_movimiento.x * 15;
            velocidad.z = input_movimiento.y * 15;
            contador_dasheando += Time.deltaTime;
        } else
        {
            velocidad.x = input_movimiento.x * 5;
            velocidad.z = input_movimiento.y * 5;
        }

        if (contador_dasheando > 0.5f)
        {
            dasheando = false;
        }


        if (characterController.isGrounded)
        {
            velocidad.y = -1;
        }

        if (disparando)
        {
            if (velocidad.x == 0 && velocidad.z == 0 && characterController.isGrounded)
            {
                estado_animacion = 4;
            }
            else if (velocidad.y > -1)
            {
                estado_animacion = 6;
            }
            else if (velocidad.y < -1)
            {
                estado_animacion = 7;
            }
            else if (velocidad.x != 0 || velocidad.z != 0 && characterController.isGrounded)
            {
                estado_animacion = 5;
            }
        } 
        else
        {
            if (velocidad.x == 0 && velocidad.z == 0 && characterController.isGrounded)
            {
                estado_animacion = 0;
            }
            else if (velocidad.y > -1)
            {
                estado_animacion = 2;
            }
            else if (velocidad.y < -1)
            {
                estado_animacion = 3;
            }
            else if (velocidad.x != 0 || velocidad.z != 0 && characterController.isGrounded)
            {
                estado_animacion = 1;
            }
        }

        if (dasheando)
        {
            estado_animacion = 8;
        }

        velocidad.y -= 20 * Time.deltaTime;

        characterController.Move(velocidad * Time.deltaTime);

        if((velocidad.x != 0.2 || velocidad.z != 0.2) || (velocidad.x != -0.2 || velocidad.z != -0.2))
        {
            Debug.Log("Calculando");
            rotacion.y = Herramientas.ObtenerAngulo2D(Vector2.zero, velocidad);
        }
        

        modeloPersonaje.rotation = Quaternion.Euler(rotacion);

        if (animator.GetInteger("Estado") != estado_animacion)
        {
            animator.SetInteger("Estado", estado_animacion);
            animator.SetTrigger("CambioEstado");

            
        }
    }

    public void Saltar(InputAction.CallbackContext callbackContext)
    {
        //Las acciones tienen 3 estados (Started, performed, canceled)
        if (callbackContext.performed)
        {
            characterController.Move(Vector3.up * 0.1f);
            velocidad.y = 7;
        }

    }

    public void Disparar(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            if (disparando == false)
            {
                disparando = true;
                contador_disparando = 0;
            }
        }
    }

    public void Dash(InputAction.CallbackContext callbackContext)
    {
        if (!callbackContext.performed) return;
        if (dasheando == false)
        {
            dasheando = true;
            contador_dasheando = 0;
        }
    }
}
