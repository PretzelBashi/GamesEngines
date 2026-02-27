using UnityEngine;

public class Musica : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource ComponenteAudioSource;
    void Start()
    {
        ComponenteAudioSource = GetComponent<AudioSource>();
        ComponenteAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
