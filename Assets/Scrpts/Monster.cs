using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    public MonsterData monsterData;
    [SerializeField] public float curHp;
    [SerializeField] public float exp;
    public GameObject bead;
    Animator animator;
    GameObject player;

    int Hp;
    int atk;

    private void Start()
    {
        curHp = monsterData.maxHp;
        exp = monsterData.exp;
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
        
        Move();
        Death();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, 5 * Time.deltaTime);

       if (3 > 1) // 구동 테스트용 매직넘버
            animator.SetBool("walk", true);

       transform.LookAt(player.transform.position);
    }

    void Death()
    {
        if (curHp <= 0)
        {
            Destroy(gameObject);
            Instantiate(bead);

        }
    }
}
