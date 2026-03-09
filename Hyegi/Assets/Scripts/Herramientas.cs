using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Herramientas : MonoBehaviour
{
    // Update is called once per frame
    /*  Sacamos hipotenusa
     *  
     *  Cateto adyacente con X, cateto opuesto con Y
     * 
     *  sen = cateto opuesto / hipotenusa
     *  cos = cateto adyacente / hipotenusa
     *  tan = seno / coseno
     *  
     *  Se saca la opuesta
     *  
     *  sen^-1
     *  cos^-1
     *  tan^-1
     *  
     */
    static public float ObtenerAngulo2D(Vector2 punto1, Vector2 punto2)
    {
        float hipotenusa = Mathf.Sqrt(Mathf.Pow(punto2.x - punto1.x, 2) + Mathf.Pow(punto2.y - punto1.y, 2));
        float catetoAdyacente = punto2.x - punto1.x;
        float cos = catetoAdyacente / hipotenusa;
        float arcocoseno = Mathf.Acos(cos) * Mathf.Rad2Deg;

        Debug.Log("hipotenusa " + hipotenusa);
        Debug.Log("cateto adyacente " + catetoAdyacente);
        Debug.Log("coseno" + cos);
        Debug.Log("arcocoseno" + arcocoseno);

        if (punto2.y < punto1.y)
        {
            arcocoseno = -arcocoseno;
        }

        return -arcocoseno;
    }
}
