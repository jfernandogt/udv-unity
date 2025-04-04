using UnityEngine;
using UnityEngine.Tilemaps;

public class Proyectil : MonoBehaviour
{
    [SerializeField] private float ataque = 1f;
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float tiempoDeVida = 2f;

    private Rigidbody2D rb;
    private EquipoEnum equipoEnum;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    public void AjustarEquipoEnum(EquipoEnum equipoEnum)
    {
        this.equipoEnum = equipoEnum;
    }

    public void AjustarDireccion(Vector2 direccion)
    {
        rb.linearVelocity = direccion.normalized * velocidad;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Tilemap tilemap = other.GetComponent<Tilemap>();
        if (tilemap != null && other.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Destroy(gameObject); // Destruir el proyectil
            return; // Salir de la función para evitar que se ejecute el resto del código
        }

        if (!other.gameObject.TryGetComponent<Salud>(out Salud saludDelOtro))
        {
            return;
        }

        if (!other.gameObject.TryGetComponent<Equipo>(out Equipo equipoDelOtro))
        {
            return;
        }

        if (equipoDelOtro.EquipoActual == equipoEnum)
        {
            return;
        }

        saludDelOtro.PerderSalud(ataque);
        Destroy(gameObject);
    }
}
