using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private LayerMask capaDeSalto;
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float alturaSalto = 4f;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    public void Moverse(float movimientoX)
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidadCaminata, rb.linearVelocity.y);
    }

    public void Saltar(bool debeSaltar)
    {
        if (!boxCollider.IsTouchingLayers(capaDeSalto)) return;

        if (debeSaltar)
        {
            float gravedad = Physics2D.gravity.y * rb.gravityScale;
            float velInicialSalto = Mathf.Sqrt(2 * Mathf.Abs(gravedad) * alturaSalto);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, velInicialSalto);
        }
    }
}