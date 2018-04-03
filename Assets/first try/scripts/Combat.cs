using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Combat : NetworkBehaviour
{
    public const int maxHealth = 100;
    public bool destroyOnDeath;

    [SyncVar]
    public int health = maxHealth;

    private NetworkStartPosition[] spawnpoints;
    private int index;

    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnpoints = FindObjectsOfType<NetworkStartPosition>();
            index = 0;
        }
    }

    public void TakeDamage(int ammount)
    {
        if (!isServer)
            return;

        health -= ammount;
        if (health <= 0)
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                health = maxHealth;
                RpcRespawn();
                Debug.Log("dead");
            }
        }
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if(isLocalPlayer)
        {
            //move to zero
            Vector3 spawn = Vector3.zero;

            if(spawnpoints != null && spawnpoints.Length > 0)
            {
                spawn = spawnpoints[index].transform.position;
                index++;
            }

            if (index >= spawnpoints.Length)
                index = 0;
            transform.position = spawn;
        }
    }
}
