using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private LayerMask capaDeSalto;
    [SerializeField] private LayerMask capaDeEscalera;

    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float velocidadEscalar = 4f;
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private int saltosMaximos = 2;

    [Range(0f, 1f)]
    [SerializeField] private float modificarVelSalto = 0.5f;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Animator animator;
    private int contadorSaltos = 0;

    private float escalaGravedad = 1f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        escalaGravedad = rb.gravityScale;

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

    public void Saltar(bool debeSaltar)
    {

        if (estaTocandoCapaDeSalto())
        {
            contadorSaltos = 0;
        }

        if (debeSaltar && contadorSaltos < saltosMaximos)
        {
            float velocidadInicialSalto = Mathf.Sqrt(-2 * escalaGravedad * Physics2D.gravity.y * alturaSalto);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, velocidadInicialSalto);
            contadorSaltos++;
        }
        else
        {
            if (rb.linearVelocity.y > Mathf.Epsilon)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * modificarVelSalto);
            }
        }
    }

    public void VoltearTransform(float movimientoX)
    {
        transform.localScale = new Vector2(
            Mathf.Sign(movimientoX) * Mathf.Abs(transform.localScale.x),
            transform.localScale.y
        );
    }

    public void Escalar(float movimientoY)
    {
        if (!boxCollider.IsTouchingLayers(capaDeEscalera))
        {
            rb.gravityScale = escalaGravedad;
            return;
        }
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, movimientoY * velocidadEscalar);
        rb.gravityScale = 0f;
    }
}