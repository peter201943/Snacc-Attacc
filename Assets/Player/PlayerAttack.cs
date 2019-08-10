
//DECLARATIONS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PLAYERATTACK
public class PlayerAttack : MonoBehaviour
{

    //VARIABLES
    public int Damage = 1;
    public float FireTime = 0.5f;
    //Decides if object takes damage
    public float Range = 50f;
    //Decides if Player can fire
    float Timer;
    Ray ShootRay;
    RaycastHit ShootHit;
    //Each Mask decides whether the target can be damaged
    int ChocolateMask;
    int CrackerMask;
    int MarshmellowMask;

    //TEMPVARS
    public float ExplosionRadius = 50f;
    public float ExplosionPower = 1000f;
    Rigidbody PlayerRigidbody;


    //AWAKE
    // Start is called before the first frame update
    //Assigns masks and effects
    void Awake()
    {
        //Chocolate
        ChocolateMask = LayerMask.GetMask("Chocolate");
        //Marshmellow
        MarshmellowMask = LayerMask.GetMask("Marshmellow");
        //Cracker
        CrackerMask = LayerMask.GetMask("Cracker");




        //DELETEME
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    //UPDATE
    // Update is called once per frame
    //Decides if player can fire
    void Update()
    {
        //Cool off gun
        Timer += Time.deltaTime;

        //Check if gun can fire
        if (Input.GetButton("Fire1") /*&& Timer >= FireTime*/) Fire();
    }


    //FIRE
    //Lobs a projectile at the enemy
    void Fire()
    {
        //Reset gun cooldown
        Timer = 0f;






        //EXPLODE!
        Vector3 ExplosionPosition = transform.position;
        Collider[] Targets = Physics.OverlapSphere(ExplosionPosition, ExplosionRadius);
        foreach (Collider hit in Targets)
        {
            Rigidbody HitRigidbody = hit.GetComponent<Rigidbody>();
            if (HitRigidbody != null)
            {
                HitRigidbody.AddExplosionForce(ExplosionPower, ExplosionPosition, ExplosionRadius, 30f);
            }
        }

        //EXPLODE DARNIT!
        PlayerRigidbody.AddExplosionForce(ExplosionPower, transform.position, ExplosionRadius);

        //F******!!!!!!

    }
}
