using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Variables públicas para arrastrar los paneles desde el Inspector
    public GameObject panelWin;
    public GameObject panelGameOver;

    public void MostrarPantallaWin()
    {
        panelWin.SetActive(true);
    }

    public void MostrarPantallaGameOver()
    {
        panelGameOver.SetActive(true);
    }
}