using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private bool provocaInvencibilidad = false;

    public bool ObjetoProvocaInvisibilidad()
    {
        return provocaInvencibilidad;
    }
}
