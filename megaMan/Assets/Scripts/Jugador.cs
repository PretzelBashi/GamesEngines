using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jugador : MonoBehaviour
{
    Vector3 velocidad;
    CharacterController characterController;
    PlayerInput playerInput;
    Vector2 input_movimiento;
    void Start()
    {
        velocidad = Vector3.zero;
        characterController = this.GetComponent<CharacterController>();
        playerInput = this.GetComponent<PlayerInput>();
    }

    
    void Update()
    {
        /*if (playerInput.actions["Jump"].ReadValue<bool>())
        {
            Debug.Log("Salto");
        }*/
        input_movimiento = playerInput.actions["Move"].ReadValue<Vector2>();
        velocidad.x = input_movimiento.x * 5;
        velocidad.z = input_movimiento.y * 5;

        characterController.Move(velocidad * Time.deltaTime);
    }

    public void Saltar(InputAction.CallbackContext callbackContext)
    {
        //Las acciones tienen 3 estados (Started, performed, canceled)
        if (callbackContext.performed)
        {
            velocidad.y = 15;
        }

    }
}
