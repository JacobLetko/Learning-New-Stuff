using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    public GameObject bulletpref;

    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * 0.1f;
        var z = Input.GetAxis("Vertical") * 0.1f;

        if (Input.GetKeyDown(KeyCode.Space))
            Fire();

        transform.Translate(x, 0, z);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Fire()
    {
        // creates bullet
        var bullet = (GameObject)Instantiate(bulletpref, transform.position - transform.forward, Quaternion.identity);

        //make bullet move
        bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4;

        //
        Destroy(bullet, 2f);
    }
}
