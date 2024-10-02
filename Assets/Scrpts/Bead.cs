using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bead : MonoBehaviour
{
    GameObject player;
    float dis;

    [SerializeField] float exp;

    private void Start()
    {
        player = GameObject.Find("Player");
        exp = 1; // GameObject.FindWithTag("Monster").GetComponent<Monster>().exp;
    }
    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();

    }

    void MoveToPlayer()
    {
        dis = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (dis< 5)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 0.005f);
            
        }
    }

    void PlayerGetEXP(float exp)
    {
        player.GetComponent<PlayerController>().curExp += exp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerGetEXP(exp);
        }
    }
}
