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
    float contador_parpadeo;

    bool vulnerabilidad;
    int vidas;
    float contador_duracion;

    GameObject objetoManejadorUI;
    GameObject modeloNave;
    NewMonoBehaviourScript componenteManejadorUI;

    int cantidad_balas;
        
    public GameObject prefabBala;
    void Start()
    {
        velocidad_lineal = 20;
        vidas = 3;
        cantidad_balas = 1;
        contador_parpadeo = 0;
        vulnerabilidad = true;

        modeloNave = GameObject.Find("modeloNave");
        componente_transform = GetComponent<Transform>();

        objetoManejadorUI = GameObject.Find("ManejadorUI");
        componenteManejadorUI = objetoManejadorUI.GetComponent<NewMonoBehaviourScript>();

        contador_duracion = 0;
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
        if (!vulnerabilidad)
        {
            contador_parpadeo += Time.deltaTime;
            if (contador_parpadeo > 0.2f)
            {
                if (modeloNave.activeSelf) { modeloNave.SetActive(false); }
                else
                {
                    modeloNave.SetActive(true);
                }
                contador_duracion++;
                contador_parpadeo = 0;
            }

            if(contador_duracion >= 12) { vulnerabilidad = true; modeloNave.SetActive(true); }
        }



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

            if (posicion.x < -22)
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
                switch (cantidad_balas)
                {
                    case 1:
                        Instantiate(prefabBala, new Vector3(posicion.x, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(prefabBala, new Vector3(posicion.x + 0.5f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        Instantiate(prefabBala, new Vector3(posicion.x - 0.5f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(prefabBala, new Vector3(posicion.x + 0f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        Instantiate(prefabBala, new Vector3(posicion.x + 0.7f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        Instantiate(prefabBala, new Vector3(posicion.x - 0.7f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        break;
                    default:
                        Instantiate(prefabBala, new Vector3(posicion.x + 0.4f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        Instantiate(prefabBala, new Vector3(posicion.x - 0.4f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        Instantiate(prefabBala, new Vector3(posicion.x + 0.95f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        Instantiate(prefabBala, new Vector3(posicion.x - 0.95f, posicion.y, posicion.z + 1.6f), Quaternion.identity);
                        cantidad_balas = 4;
                        break;
                }

            }

            componente_transform.position = posicion;
            componente_transform.rotation = Quaternion.RotateTowards(componente_transform.rotation, Quaternion.Euler(rotacion), 400 * Time.deltaTime);
        }
    
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
            case "asteroide":
                PerderUnaVida(1);
                break;
            case "enemigo":
                PerderUnaVida(1);
                break;
            case "balaEnemigo":
                PerderUnaVida(1);
                break;
            case "powerUp":
                Destroy(collision.gameObject);
                cantidad_balas++;
                break;
        }
    }

    void PerderUnaVida(int daño)
    {
        if (!vulnerabilidad)
        {
            vidas -= daño;
            cantidad_balas--;
            vulnerabilidad = false;

            if (cantidad_balas > 0) { cantidad_balas = 1; };
            if (vidas == 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("GameOver");
            }
            componenteManejadorUI.ActualizarVidas(vidas);
            Debug.Log(vidas);
        }
    }
}
