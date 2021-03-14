using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;
    public float health = 1;

    private Collider bulletCollider;


    public Camera Cam { get; set; }
    private Rigidbody body;

    private void Start()
    {
        TryGetComponent(out bulletCollider);
        TryGetComponent(out body);
        body.velocity = transform.forward * speed;
    }

    private void Update()
    {
        var bounds =
            bulletCollider.bounds; //no se puede leer en el start, hay que actualizarlo siempre (pedirlo siempre)

        var minWorld = bounds.min; //el vector min en el world

        var minViewport = Cam.WorldToViewportPoint(minWorld); //la esquina inferior izquierda en el viewport

        if (minViewport.y > 1) // si lo de mas abajo ya se fue de la pantalla por arriba
        {
            health = -1;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}