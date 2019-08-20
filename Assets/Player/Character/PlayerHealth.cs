

//DECLARATIONS
//UI added for HUD components
using System.Collections;           //C# Required
using System.Collections.Generic;   //C# Required
using UnityEngine;                  //Unity Required
using UnityEngine.UI;               //Added for UI Components


//PLAYERHEALTH
//Allows player to die
public class PlayerHealth : MonoBehaviour
{

    //VARIABLES

        //Logic
        public int StartHealth = 100;                                   //Before Play Health
        public int CurrentHealth;                                       //During Play Health
        bool IsDead;                                                    //Control interrupting movement and shooting
        bool Damaged;                                                   //Control showing effects

        //UI
        public Slider HealthBar;                                        //Shows health to player
        public Image DamageImage;                                       //Flashed if player takes damage

        //Effects
        AudioSource PlayerSound;
        public AudioClip DeathClip;                                     //Plays if player dies
        public float DamageFlashSpeed = 5f;
        public Color DamageFlashColor = new Color(1f, 0f, 0f, 0.1f);    //Faint Red
        Animator PlayerAnimator;                                        //Interrupt player on death
        PlayerMovement PlayerMover;                                     //Stutter movement on damage
        //PlayerShooting PlayerShooter;                                 //Interrupt shooting on damage


    //AWAKE
    //Assigns controllers and initial values
    void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerSound = GetComponent<AudioSource>();
        PlayerMover = GetComponent<PlayerMovement>();
        //PlayerShooter = GetComponent<PlayerShooting>();
        CurrentHealth = StartHealth;
    }


    //UPDATE
    //Check to flash damage
    void Update()
    {
        //Player takes damage
        if(Damaged)
        {
            //Flash Red
            DamageImage.color = DamageFlashColor;
        }
        //Player has not taken damage
        else
        {
            //Fade Out
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, DamageFlashSpeed * Time.deltaTime);
        }
        //Reset Flag
        Damaged = false;
    }


    //DAMAGE
    //Check if player dies and effects
    void Damage(int DamageSize)
    {
        Damaged = true;                         //Set Flag
        CurrentHealth -= DamageSize;            //Deduct Health
        HealthBar.value = CurrentHealth;        //Update UI
        PlayerSound.Play();                     //Cry in Pain
        
        //Player is Dead
        if (CurrentHealth <= 0 && !IsDead)
        {
            Die();
        }
    }


    //DIE
    //Effects, Controls, and UI turn off/play
    void Die()
    {
        IsDead = true;                          //Set Flags
        //PlayerShooter.DisableEffects();       //Stop Muzzle Flash
        //PlayerShooter.enabled = false;        //Stop Shooting
        PlayerMover.enabled = false;            //Stop Moving
        PlayerAnimator.SetTrigger("Die");       //Animate Death
        PlayerSound.clip = DeathClip;           //Change Sound to Scream
        PlayerSound.Play();                     //Scream to Death
    }


}

