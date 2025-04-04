using UnityEngine;

public class ContactoItem : MonoBehaviour
{
    private Puntaje puntajeScript;

    private Salud salud;

    private void Start()
    {
        // Obtener el componente Puntaje del mismo GameObject
        puntajeScript = GetComponent<Puntaje>();
        salud = GetComponent<Salud>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Item item = other.GetComponent<Item>();
            if (item.ObjetoProvocaInvisibilidad())
            {
                salud.ActivarInvencibilidad();
            }
            Debug.Log("Objeto recogido: " + other.name);
            Debug.Log("Invencibilidad: " + item.ObjetoProvocaInvisibilidad());

            if (puntajeScript != null)
            {
                puntajeScript.SumarPuntaje(1);
            }

            Destroy(other.gameObject);
        }
    }
}
