using UnityEngine;

public class ControlCuadrado : MonoBehaviour
{
    [SerializeField] private string mensaje;
    private HolaMundo holaMundo;

    void Start()
    {
        holaMundo = GetComponent<HolaMundo>();
        
        if (holaMundo != null)
        {
            holaMundo.Saludar(mensaje);
        }
        else
        {
            Debug.LogError("No se encontró el componente HolaMundo en el GameObject.");
        }
    }
}