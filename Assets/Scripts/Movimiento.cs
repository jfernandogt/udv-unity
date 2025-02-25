using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float alturaSalto = 4f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Moverse(float movimientoX)
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidadCaminata, rb.linearVelocity.y);
    }
}