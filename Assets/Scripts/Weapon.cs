using System;
using UnityEngine;


/*
 * Tiene que estar ubicado en el gameobject que tiene le spawn point de la bala (usa el vector up para dirigirla)
 * 
 */
public class Weapon : MonoBehaviour
{

    /*identificador para cada arma*/
    public string weaponId;
    
    //weapon settings
    public Bullet bullet;
    public float frequency;

    private bool isShooting;
    private float nextShootMoment;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }


    public void SetShooting(bool shooting)
    {
        isShooting = shooting;
        nextShootMoment = 0; // will shoot immediately next frame;
    }

    private void Update()
    {
        if (Time.time >= nextShootMoment)
        {
            Shoot();
            nextShootMoment = Time.time + frequency;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation).Cam = cam;
        
        
    }
}