using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private LayerMask capaDeSalto;
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float alturaSalto = 4f;

    [SerializeField] private int saltosMaximos = 2;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Animator animator;
    private int contadorSaltos = 0;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }

    public void Moverse(float movimientoX)
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidadCaminata, rb.linearVelocity.y);
        animator.SetBool("estaCorriendo", movimientoX != 0);
    }

    private bool estaTocandoCapaDeSalto()
    {
        // Retorna true si el BoxCollider2D detecta las capas definidas en capaDeSalto
        return boxCollider.IsTouchingLayers(capaDeSalto);
    }

    private void RealizarSalto()
    {
        float gravedad = Physics2D.gravity.y * rb.gravityScale;
        float velInicialSalto = Mathf.Sqrt(2 * Mathf.Abs(gravedad) * alturaSalto);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, velInicialSalto);
    }

    public void Saltar(bool debeSaltar)
    {
        if (estaTocandoCapaDeSalto())
        {
            contadorSaltos = 0;
        }

        if (debeSaltar)
        {
            if (contadorSaltos < saltosMaximos)
            {
                RealizarSalto();
                contadorSaltos++;
            }
        }
    }
}