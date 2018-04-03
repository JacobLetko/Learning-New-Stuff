using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hitcombat = hit.GetComponent<Combat>();
        if (hitcombat != null)
        {
            hitcombat.TakeDamage(10);

            Destroy(gameObject);
        }
    }
}
