using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public TextMeshProUGUI textoContador;
    
    
    private static int contadorObjetos = 0; 

    void Awake()
    {
        instancia = this;
    }

    public void SumarObjeto()
    {
        contadorObjetos++;
        Debug.Log("Objetos recolectados: " + contadorObjetos);

        if (textoContador != null)
        {
            textoContador.text = "Objetos: " + contadorObjetos;
        }
    }
}