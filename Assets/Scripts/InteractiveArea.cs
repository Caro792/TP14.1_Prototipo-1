using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveArea : MonoBehaviour
{
    public int score = 0; 
    public int puntajeMaximo = 10; // Condición de victoria configurable
    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable") || other.CompareTag("Collectible"))
        {
            score++; 
            
            if (gameManager != null)
            {
                gameManager.UpdateScore(score);

                // Verifica si alcanzó la victoria
                if (score >= puntajeMaximo)
                {
                    gameManager.FinalizarPorVictoria();
                }
            }
            
            Destroy(other.gameObject); 
        }
    }
}