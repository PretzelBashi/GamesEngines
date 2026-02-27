using UnityEngine;

public class Jugador2 : MonoBehaviour
{
    CharacterController componenteCC;
    Vector3 velocidad;
    int saltosActuales;
    int saltosMaximos;
    
    Animator componenteAnimator;
    Vector3 rotacion;
    public ManejadorUI manejadorUI;

    public GameObject prefabMarioMuerto;
    public GameObject AudioMarioMuerte;

    public GameObject sonidoMoneda;
    public GameObject sonidoSalto;
    public GameObject sonidoGoomba;

    AudioSource componenteAudioSource;
    void Start()
    {
        componenteCC = this.GetComponent<CharacterController>();
        velocidad = Vector3.zero;
        saltosMaximos = 2;
        componenteAnimator = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
        rotacion = Vector3.zero;
        componenteAudioSource = this.GetComponent <AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && velocidad.y == -1)
        {
            componenteAnimator.SetInteger("Estado", 1);
        }
        else if (velocidad.y != -1)
        {
            componenteAnimator.SetInteger("Estado", 2);
        }
        else 
        {
            componenteAnimator.SetInteger("Estado", 0);
        }

        if(Input.GetAxis("Horizontal") > 0)
        {
            rotacion.y = 0;
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            rotacion.y = 180;
        }

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
            sonidoSalto.GetComponent<AudioSource>().Play();

        }



        componenteCC.Move(velocidad * Time.deltaTime);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(rotacion), 500 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "moneda")
        {
            Destroy(hit.gameObject);
            manejadorUI.TomarMoneda();
            sonidoMoneda.GetComponent<AudioSource>().Play();
        }

        if (hit.gameObject.tag == "goomba")
        {
            if(transform.position.y > hit.gameObject.transform.position.y)
            {
                Destroy(hit.gameObject);
                componenteCC.Move(new Vector3(0,0.1f,0));
                velocidad.y = 12;
            } else
            {
                Instantiate(prefabMarioMuerto, transform.position, Quaternion.Euler(0,0,0));
                Destroy(this.gameObject);
                sonidoGoomba.GetComponent<AudioSource>().Play();
                AudioMarioMuerte.GetComponentInParent<AudioSource>().Stop();
            }
        }
    }
}
