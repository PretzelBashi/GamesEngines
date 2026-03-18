using UnityEngine;

public class ObjetoRayos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Vector3.zero, Vector3.up, Color.red);

        RaycastHit hit;

        if(Physics.Raycast(this.transform.position, Vector3.up,out hit, 5))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
