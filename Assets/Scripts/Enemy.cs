using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 PointA;
    public Vector3 PointB;
    public float normalSpeed = 2f;
    public float detectSpeed = 5f;
    public float range = 5f;
    private float actualSpeed;
    private Vector3 destiny;
    public LayerMask playerLayer;

    void Start()
    {
        destiny = PointA;
        actualSpeed = normalSpeed;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destiny, actualSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destiny) < 0.1f)
        {
            destiny = destiny == PointA ? PointB : PointA;
        }

        DetectarJugador();
    }

    void DetectarJugador()
    {
        Vector3 direccion = (destiny - transform.position).normalized;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direccion, out hit, range, playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                actualSpeed = detectSpeed;
                Debug.DrawRay(transform.position, direccion * range, Color.red);
            }
        }
        else
        {
            actualSpeed = detectSpeed;
        }
    }
}