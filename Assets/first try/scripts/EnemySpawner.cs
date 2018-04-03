using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyprefab;
    public int numEnemies;

    public override void OnStartServer()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            var pos = new Vector3(Random.Range(-8f, 8f), .2f, Random.Range(-8f, 8f));
            var rotation = Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
            var enemy = (GameObject)Instantiate(enemyprefab, pos, rotation);

            NetworkServer.Spawn(enemy);
        }
    }
}
