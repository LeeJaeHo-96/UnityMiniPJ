using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);

        spawner = this.gameObject;
        Coroutine spawn = StartCoroutine(MonsterSpawn());

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(spawn);
        }
    }

    private void Update()
    {
        
    }

    IEnumerator MonsterSpawn()
    {

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSecondsRealtime(2f);
            Instantiate(monster, spawner.transform);
        }
        
    }
}
