

//DECLARATIONS
//Imports names and objects
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//MONSTERMOVEMENT
//Moves Monsters
public class MonsterMovement : MonoBehaviour
{

    //VARIABLES
    //What the monster moves toward
    Transform Player;
    //What the monster is
    NavMeshAgent Monster;


    //AWAKE
    //Awake is called regardless of assignment
    //Finds Player and Map
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Monster = GetComponent<NavMeshAgent>();
    }


    //UPDATE
    //Update is called once per frame
    //Tells the Monster where Player is
    void Update()
    {
        Monster.SetDestination(Player.position);
    }
}
