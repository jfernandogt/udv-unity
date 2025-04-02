using UnityEngine;
using System;

public class Puntaje : MonoBehaviour
{
    private int puntaje = 0;
    private int totalItems = 0;

    public event Action alActualizarPuntaje;

    void Start()
    {
        CalcularTotalItems();
        alActualizarPuntaje?.Invoke();
    }

    public int ObtenerPuntaje()
    {
        return puntaje;
    }

    public void SumarPuntaje(int cantidad)
    {
        puntaje += cantidad;
        Debug.Log($"Puntaje actualizado: {puntaje}");
        alActualizarPuntaje?.Invoke();
    }

    public void RestarPuntaje(int cantidad)
    {
        puntaje -= cantidad;
        alActualizarPuntaje?.Invoke();
    }

    public void ReiniciarPuntaje()
    {
        puntaje = 0;
        alActualizarPuntaje?.Invoke();
    }

    private void CalcularTotalItems()
    {
        totalItems = GameObject.FindGameObjectsWithTag("Item").Length;

        Debug.Log($"Total de ítems encontrados: {totalItems}");
    }


    public int getTotalItems()
    {
        return totalItems;
    }
}
