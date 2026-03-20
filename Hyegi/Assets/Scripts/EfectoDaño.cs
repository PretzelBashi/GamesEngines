using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EfectoDaño : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Volume volume;
    Vignette vignette;
    bool vignette_obtenido;
    int estado;
    void Start()
    {
        volume = GameObject.FindGameObjectWithTag("GlobalVolume").GetComponent<Volume>();
        if(volume.profile.TryGet<Vignette>(out vignette))
        
        vignette_obtenido = volume.profile.TryGet<Vignette>(out vignette);
        estado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RecibirDaño();
        }

        switch (estado)
        {
            case 0: break;
            case 1:
                if (vignette_obtenido)
                {
                    vignette.intensity.value += Time.deltaTime * 0.8f;
                    if(vignette.intensity.value > 0.5f)
                    {
                        vignette.intensity.value = 0.5f;
                            estado = 2;
                    }
                }
                break;
            case 2:
                if (vignette_obtenido)
                {
                    vignette.intensity.value -= Time.deltaTime * 0.8f;
                    if (vignette.intensity.value < 0)
                    {
                        vignette.intensity.value = 0;
                        estado = 1;
                    }
                }
                break;
        }
    }
    void RecibirDaño()
    {
        if (vignette_obtenido)
        {
            //vignette.intensity.value = 0;
            estado = 1;
        }
    }
}
