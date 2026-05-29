using UnityEngine;
using TMPro;

public class Coleccionable : MonoBehaviour
{
    
    public static int contadorObjetos = 0;

    private TextMeshProUGUI textoContador;

    void Start()
    {
        
        textoContador = GameObject.FindObjectOfType<TextMeshProUGUI>();
        
        if (textoContador != null && contadorObjetos == 0)
        {
            textoContador.text = "Objetos: 0";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.transform.root.CompareTag("Player"))
        {
            contadorObjetos++;
            
            
            Debug.Log("Objetos recolectados: " + contadorObjetos);

            
            if (textoContador != null)
            {
                textoContador.text = "Objetos: " + contadorObjetos;
            }

            
            Destroy(gameObject);
        }
    }
}