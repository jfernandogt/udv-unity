using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlEnemigo: MonoBehaviour
{
    [Header("Ground Detection")]
    [SerializeField] private Transform Detector;
    [SerializeField] private float distanciaAlSuelo = 0.3f;
    [SerializeField] private LayerMask layerSuelo;
    private Movimiento movimiento;
    Vector2 direccionMovimiento;
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        direccionMovimiento = new Vector2(1f, 0f);
    }

    void Update()
    {
        movimiento.VoltearTransform(direccionMovimiento.x);
        DetectarSuelo();
        movimiento.Moverse(direccionMovimiento.x);
    }

    void DetectarSuelo()
    {
        RaycastHit2D hit = Physics2D.Raycast(Detector.position, Vector2.down, distanciaAlSuelo, layerSuelo);

        if (hit.collider == null)
        {
            direccionMovimiento.x *= -1f;
        }
    }

}