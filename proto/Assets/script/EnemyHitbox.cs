using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox1 : MonoBehaviour
{


    public float fDamage = 20;
    private Vector3 v3Knockback = new Vector3(0, 5, 15);

    private LayerMask layerMask;

    public LayerMask LayerMask { get { return layerMask; } set => layerMask = value; }

    private void OnTriggerEnter(Collider other) 
    {
    
        if (LayerMask == (LayerMask | (1 << other.transform.gameObject.layer))) {
        
            PlayerHurtbox h = other.GetComponent<PlayerHurtbox>();
            if (h != null) {
            
                h.playerhealth.playerhealth -= fDamage;
                h.cc.playerDirection = v3Knockback;
                Destroy(this.gameObject);
             }
        }
    }
}