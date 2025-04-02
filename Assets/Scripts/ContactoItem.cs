using UnityEngine;

public class ContactoItem : MonoBehaviour
{
    private Puntaje puntajeScript;

    private void Start()
    {
        // Obtener el componente Puntaje del mismo GameObject
        puntajeScript = GetComponent<Puntaje>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("Objeto recogido: " + other.name);

            if (puntajeScript != null)
            {
                puntajeScript.SumarPuntaje(1);
            }

            Destroy(other.gameObject);
        }
    }
}
