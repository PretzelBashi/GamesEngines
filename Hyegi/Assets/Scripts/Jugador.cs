using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    CharacterController characterController;
    Vector3 velocidad;
    Vector3 rotacion;

    Animator animator;

    public GameObject contenedorCamara;
    GameObject auxiliarRotacionCamara;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        velocidad = Vector3.zero;
        rotacion = Vector3.zero;
        animator = this.transform.GetChild(0).GetComponent<Animator>();
        auxiliarRotacionCamara = new GameObject();
        auxiliarRotacionCamara.transform.rotation = auxiliarRotacionCamara.transform.rotation;
    }


    void Update()
    {
        velocidad.x = Input.GetAxisRaw("Horizontal") * 2;
        velocidad.z = Input.GetAxisRaw("Vertical") * 2;
        animator.SetInteger("Estado", 0);
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
            Vector3 direccionMovimiento = contenedorCamara.transform.TransformDirection(velocidad);
            rotacion.y = Herramientas.ObtenerAngulo2D(new Vector2(0, 0), new Vector2(direccionMovimiento.x, direccionMovimiento.z));            
        }
        
        if(velocidad.x == 0 && velocidad.z == 0 && characterController.isGrounded)
        {
            animator.SetInteger("Estado", 0);
        } 
        else if ((velocidad.x != 0 || velocidad.z != 0) && characterController.isGrounded)
        {
            animator.SetInteger("Estado", 1);
        } else if (!characterController.isGrounded)
        {
            animator.SetInteger("Estado", 2);
        }



        auxiliarRotacionCamara.transform.rotation = auxiliarRotacionCamara.transform.rotation;
        auxiliarRotacionCamara.transform.rotation = Quaternion.Euler(new Vector3(0, auxiliarRotacionCamara.transform.rotation.eulerAngles.y, 0));

        RaycastHit hit;

        Debug.DrawRay(this.transform.position + Vector3.up * 0.1f, Vector3.down, Color.red);
        if(Physics.Raycast(this.transform.position + Vector3.up * 0.1f, Vector3.down, out hit, 1))
        {
            //Debug.Log(hit.point);
            if(hit.collider.gameObject.tag == "Goomba"){
                Destroy(hit.collider.gameObject);
                velocidad.y = 7;
            }

        }

        characterController.Move(contenedorCamara.transform.TransformDirection(velocidad) * Time.deltaTime); 
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), 2);
    }
}
