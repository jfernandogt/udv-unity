using UnityEngine;

public class ContactoItem : MonoBehaviour
{
    private Puntaje puntajeScript;

    private Salud salud;

    [SerializeField] private AudioClip sonidoRecogerItem;

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
            ReproducirSonido();
            Item item = other.GetComponent<Item>();
            other.enabled = false;
            if (item.ObjetoProvocaInvisibilidad())
            {
                salud.ActivarInvencibilidad();
            }

            if (puntajeScript != null)
            {
                puntajeScript.SumarPuntaje(1);
            }
            Destroy(other.gameObject, sonidoRecogerItem.length);
        }
    }

    private void ReproducirSonido()
    {
        if (sonidoRecogerItem != null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(sonidoRecogerItem);
        }
    }
}
