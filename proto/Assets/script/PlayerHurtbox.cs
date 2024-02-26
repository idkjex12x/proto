using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtbox : MonoBehaviour
{
    
    public PlayerHealth playerhealth;
    public playermovement cc;


    private void Start()
    { 
        playerhealth = transform.GetComponentInParent<PlayerHealth>();
        cc = transform.GetComponentInParent<playermovement>();
    }
}