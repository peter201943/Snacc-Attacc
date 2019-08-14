

//DECLARATIONS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PLAYERATTACK
public class PlayerAttack : MonoBehaviour
{

    //VARIABLES
    //Gun Mechanics
    public float FireTime = 0.33f;
    public Transform GunBarrel;
    public float FireForce = 50f;
    private float FireTimer;
    //Projectile Mechanics
    public float ProjectileLifetime = 5f;
    public GameObject AntiCracker;
    public GameObject AntiChocolate;
    public GameObject AntiMarshmellow;


    //START
    // Start is called before the first frame update
    //Assigns masks and effects
    void Start()
    {
        //Reset Timer
        FireTimer = 0f;
    }


    //UPDATE
    // Update is called once per frame
    //Decides if player can fire
    void Update()
    {
        //Decrement Timer as time passes
        FireTimer -= Time.deltaTime;

        //Check if player can and wants to fire which mode
        if (Input.GetMouseButton(0) && (FireTimer <= 0f))
        {
            AntiMarshmellowFire();
        }
        else if (Input.GetMouseButton(1) && (FireTimer <= 0f))
        {
            AntiCrackerFire();
        }
        else if (Input.GetMouseButton(2) && (FireTimer <= 0f))
        {
            AntiChocolateFire();
        }
    }


    //ANTIMARSHMELLOWFIRE
    //Lobs a projectile at the enemy
    void AntiMarshmellowFire()
    {
        GameObject CurrentProjectile = (GameObject)Instantiate(AntiMarshmellow, GunBarrel.position, GunBarrel.rotation);
        CurrentProjectile.GetComponent<Rigidbody>().AddForce(GunBarrel.up * FireForce);
        Destroy(CurrentProjectile, ProjectileLifetime);
        FireTimer = FireTime;
    }


    //ANTICHOCOLATEFIRE
    //Lobs a projectile at the enemy
    void AntiChocolateFire()
    {
        GameObject CurrentProjectile = (GameObject)Instantiate(AntiChocolate, GunBarrel.position, GunBarrel.rotation);
        CurrentProjectile.GetComponent<Rigidbody>().AddForce(GunBarrel.up * FireForce);
        Destroy(CurrentProjectile, ProjectileLifetime);
        FireTimer = FireTime;
    }


    //ANTICRACKERFIRE
    //Lobs a projectile at the enemy
    void AntiCrackerFire()
    {
        GameObject CurrentProjectile = (GameObject)Instantiate(AntiCracker, GunBarrel.position, GunBarrel.rotation);
        CurrentProjectile.GetComponent<Rigidbody>().AddForce(GunBarrel.up * FireForce);
        Destroy(CurrentProjectile, ProjectileLifetime);
        FireTimer = FireTime;
    }
}

