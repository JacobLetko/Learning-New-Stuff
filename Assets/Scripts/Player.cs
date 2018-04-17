using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SyncVar]
    private int currentHealth;

    private void Awake()
    {
        setDefualts();
    }

    public void setDefualts()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float _amount)
    {
        currentHealth = currentHealth - (int)_amount;

        Debug.Log(transform.name + " has " + currentHealth + " health");
    }

}
