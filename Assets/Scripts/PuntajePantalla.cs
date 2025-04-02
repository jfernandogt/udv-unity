using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuntajePantalla : MonoBehaviour
{
    [SerializeField] private Puntaje puntaje;

    [SerializeField] private TextMeshProUGUI textoPuntaje;


    private void OnEnable()
    {
        // Subscribe to the event
        puntaje.alActualizarPuntaje += ActualizarBarra;
    }

    private void OnDisable()
    {
        puntaje.alActualizarPuntaje -= ActualizarBarra;
    }

    private void ActualizarBarra()
    {
        textoPuntaje.text = "Puntaje: " + puntaje.ObtenerPuntaje() + "/" + puntaje.getTotalItems();
    }
}
