using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform componente_transform;
    Vector3 posicion;
    Vector3 rotacion;
    float velocidad_lineal;
    float contador;

    int vidas;

    GameObject objetoManejadorUI;
    NewMonoBehaviourScript componenteManejadorUI;
        
    public GameObject prefabBala;
    void Start()
    {
        velocidad_lineal = 20;
        vidas = 3;

        componente_transform = GetComponent<Transform>();

        objetoManejadorUI = GameObject.Find("ManejadorUI");
        componenteManejadorUI = objetoManejadorUI.GetComponent<NewMonoBehaviourScript>();
        

        posicion = transform.position;
        rotacion = new Vector3 (0,0,0);
        Invoke("ActualizarUI", 0.01f);
    }

    void ActualizarUI()
    {
        componenteManejadorUI.ActualizarVidas(vidas);
    }
    // Update is called once per frame
    void Update()
    {


        rotacion.z = 0;
        if (Input.GetKey(KeyCode.D))
        {
            posicion.x += velocidad_lineal * Time.deltaTime;
            rotacion.z = -30;
        }
        if (Input.GetKey(KeyCode.A))
        {
            posicion.x -= velocidad_lineal * Time.deltaTime;
            rotacion.z = 30;
        }
        if (Input.GetKey(KeyCode.W))
        {
            posicion.z += velocidad_lineal * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            posicion.z -= velocidad_lineal * Time.deltaTime;
        }

        if (posicion.x > 22)
        {
            posicion.x = 22;
        }
        
        if(posicion.x < -22)
        {
            posicion.x = -22;
        }

        if (posicion.z > 12)
        {
            posicion.z = 12;
        }
        
        if (posicion.z < -12)
        {
            posicion.z = -12;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabBala, componente_transform.position, new Quaternion(0,0,0,0));
        }

        componente_transform.position = posicion;
        componente_transform.rotation = Quaternion.RotateTowards(componente_transform.rotation,Quaternion.Euler(rotacion),400 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "asteroide")
        {
            vidas -= 1;
            if (vidas == 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(1);
            }
            componenteManejadorUI.ActualizarVidas(vidas);
            Debug.Log(vidas);
        }
    }
}
