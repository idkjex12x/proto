using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public EnemyHealth eHealth1;
    public EnemyHealth eHealth2;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            /*eHealth.health -= damage;*/
            other.gameObject.GetComponent<EnemyHealth>().health -= damage;
        }
    }


}
