using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    private float curHp;

    Animator animator;
    GameObject player;

    int Hp;
    int atk;

    private void Start()
    {
       // curHp = monsterData.maxHp;
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        
        Move();
       // Death();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 5 * Time.deltaTime);

       if (3 > 1)
            animator.SetBool("walk", true);

       transform.LookAt(player.transform.position);
    }

    void Death()
    {
        if(curHp <= 0)
            Destroy(gameObject);
    }
}
