using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 puntoA;
    public Vector3 puntoB;
    public float velocidadNormal = 2f;
    public float velocidadRapida = 5f;
    public float rangoDeteccion = 5f;
    private float velocidadActual;
    private Vector3 destino;
    public LayerMask jugadorLayer;

    void Start()
    {
        destino = puntoA;
        velocidadActual = velocidadNormal;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidadActual * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            destino = destino == puntoA ? puntoB : puntoA;
        }

        DetectarJugador();
    }

    void DetectarJugador()
    {
        Vector3 direccion = (destino - transform.position).normalized;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direccion, out hit, rangoDeteccion, jugadorLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                velocidadActual = velocidadRapida;
                Debug.DrawRay(transform.position, direccion * rangoDeteccion, Color.red);
            }
        }
        else
        {
            velocidadActual = velocidadNormal;
        }
    }
}