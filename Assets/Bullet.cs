using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var hitplayer = hit.GetComponent<PlayerMove>();
        if (hitplayer != null)
        {
            Destroy(gameObject);
        }
    }
}
