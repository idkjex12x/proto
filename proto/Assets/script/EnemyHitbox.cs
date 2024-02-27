using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox1 : MonoBehaviour
{


    public float fDamage = 20;
    private Vector3 v3Knockback = new Vector3(5, 0, 0);

    public LayerMask layerMask;

    public LayerMask LayerMask { get { return layerMask; } set => layerMask = value; }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Trigger");
        if (layerMask == (LayerMask | (1 << other.transform.gameObject.layer))) {
           
        
            PlayerHurtbox h = other.GetComponent<PlayerHurtbox>();
            if (h != null) {
            
                h.playerhealth.playerhealth -= fDamage;
                Debug.Log(h.playerhealth.playerhealth);
                h.cc.playerDirection = v3Knockback;
                Destroy(this.gameObject);
             }
        }
    }
}