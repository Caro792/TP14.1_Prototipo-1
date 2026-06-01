using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("Referencias de UI (TextMeshPro)")]
    public TextMeshProUGUI textoContador;     
    public TextMeshProUGUI textoTemporizador; 
    
    [Header("Variables del Juego")]
    public float timer = 60f; 
    private int contadorObjetos = 0; 

    void Awake()
    {
        instancia = this;
    }

    void Update()
    {
       
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            if (timer < 0) 
            {
                timer = 0; 
            }

            UpdateTimerText();
        }
    }

    
    public void UpdateScore(int scoreActualizado)
    {
        contadorObjetos = scoreActualizado; 
        Debug.Log("Objetos recolectados: " + contadorObjetos);

        if (textoContador != null)
        {
           
            textoContador.text = "Score: " + contadorObjetos;
        }
    }

   
    private void UpdateTimerText()
    {
        if (textoTemporizador != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            textoTemporizador.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}