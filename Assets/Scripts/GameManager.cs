using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager instancia;

    [Header("Referencias de UI (TextMeshPro)")]
    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoTemporizador;

    [Header("Referencias de Paneles de Fin de Juego")]
    public UIManager uiManager; 

    [Header("Variables del Juego")]
    public float timer = 60f;
    
    // Forzamos a que el valor sea 7 directamente en el código para evitar fallos del Inspector
    public int puntajeMaximo = 7; 
    
    private int contadorObjetos = 0;
    private bool juegoTerminado = false; 

    void Awake() 
    {
        instancia = this; 
        Time.timeScale = 1;
        
        // REINICIO FORZADO: Esto garantiza que el contador empiece en 0 siempre
        contadorObjetos = 0;
        Coleccionable.contadorObjetos = 0; 
    }

    void Update() 
    {
        if (juegoTerminado && Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (juegoTerminado) return;

        if (timer > 0) 
        {
            timer -= Time.deltaTime;
            if (timer <= 0) 
            {
                timer = 0;
                FinalizarPorDerrota();
            }
            UpdateTimerText();
        }
    }

    public void UpdateScore(int scoreActualizado) 
    {
        contadorObjetos = scoreActualizado;
        Debug.Log("Coleccionado: " + contadorObjetos + " de " + puntajeMaximo);

        if (textoContador != null) 
        {
            textoContador.text = "Score: " + contadorObjetos;
        }

        // Comprobación estricta de victoria
        if (contadorObjetos >= puntajeMaximo) 
        {
            FinalizarPorVictoria();
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

    private void FinalizarPorDerrota() 
    {
        juegoTerminado = true;
        if (uiManager != null) 
        {
            uiManager.MostrarPantallaGameOver();
        }
        Time.timeScale = 0; 
    }

    public void FinalizarPorVictoria() 
    {
        juegoTerminado = true;
        if (uiManager != null) 
        {
            uiManager.MostrarPantallaWin();
        }
        Time.timeScale = 0; 
    }
}