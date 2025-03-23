using UnityEngine;

public class Equipo : MonoBehaviour
{
    [SerializeField]EquipoEnum equipo = EquipoEnum.Trampas;

    public EquipoEnum EquipoActual
    {
        get { return equipo; }

        private set {equipo = value;}
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
