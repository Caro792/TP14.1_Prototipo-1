using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Librería de escenas obligatoria

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("Referencias de UI (TextMeshPro)")]
    public TextMeshProUGUI textoContador;     
    public TextMeshProUGUI textoTemporizador; 
    
    [Header("Referencias de Paneles de Fin de Juego")]
    public UIManager uiManager; // Referencia al script que maneja la UI

    [Header("Variables del Juego")]
    public float timer = 60f; 
    private int contadorObjetos = 0; 
    private bool juegoTerminado = false; // Control interno de estado

    void Awake()
    {
        instancia = this;
        // Crucial: El juego no debe iniciar congelado tras reiniciar
        Time.timeScale = 1; 
    }

    void Update()
    {
        // Sistema de Reinicio
        if (juegoTerminado && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Si el juego ya terminó, no seguimos descontando tiempo
        if (juegoTerminado) return;

        // Control de la cuenta regresiva
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

    private void FinalizarPorDerrota()
    {
        juegoTerminado = true;
        if (uiManager != null)
        {
            uiManager.MostrarPantallaGameOver();
        }
        Time.timeScale = 0; // Congela el juego por completo
    }

    // Método público para que InteractiveArea declare la victoria
    public void FinalizarPorVictoria()
    {
        juegoTerminado = true;
        if (uiManager != null)
        {
            uiManager.MostrarPantallaWin();
        }
        Time.timeScale = 0; // Congela el juego por completo
    }
}