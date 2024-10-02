using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 3;

    Animator animator;

    [SerializeField] GameObject enemy;
    public List<GameObject> FoundMonsters;
    public GameObject monsters;
    public float shortDis = 100;
    public float cooldown = 1f;
    public float range = 30f;

    Coroutine fire = null;

    [SerializeField] public float curExp;
    [SerializeField] GameObject fireBall;
    [SerializeField] GameObject nozzle;

    void Start()
    {
        enemy = GameObject.FindWithTag("Monster");
        animator = GetComponent<Animator>();
        curExp = 0;

        fire = StartCoroutine(CoAttack());

    }


    void Update()
    {
        Move();
        MonsterScanning();
    }




    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * x * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 6;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3;
        }
        animator.SetFloat("moveSpeed", moveSpeed);

        if (new Vector3(x, 0, z) == Vector3.zero)
        {
            animator.SetFloat("moveSpeed", 0);


        }
        if (new Vector3(x, 0, z) == Vector3.forward)
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            animator.SetBool("Back", false);
        }

        if (new Vector3(x, 0, z) == Vector3.left)
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Back", false);
        }
        if (new Vector3(x, 0, z) == Vector3.right)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Back", false);
        }
        if (new Vector3(x, 0, z) == Vector3.back)
        {
            animator.SetBool("Back", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }


    }
    

    void MonsterScanning()
    {
        enemy = GameObject.FindWithTag("Monster");

        if (enemy != null)
        {

            FoundMonsters = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
            shortDis = Vector3.Distance(gameObject.transform.position, FoundMonsters[0].transform.position);

            monsters = FoundMonsters[0];

            foreach (GameObject found in FoundMonsters)
            {
                float Distance = Vector3.Distance(gameObject.transform.position, found.transform.position);

                if (Distance < shortDis)
                {
                    monsters = found;
                    shortDis = Distance;

                    
                    transform.LookAt(monsters.transform);
                }
            }
        }
        else 
        {
            shortDis = 100;
        }

    }
    IEnumerator CoAttack()
    {
        Debug.Log("코루틴 실행");
        while (monsters != null)
        {
            Debug.Log("파이어볼생성");
            Instantiate(fireBall, GameObject.Find("nozzle").transform.position, Quaternion.identity);


            yield return new WaitForSecondsRealtime(cooldown);

            if (monsters == null)
            {
                StopCoroutine(fire);
                Debug.Log("코루틴 종료");
            }
        }

    }


}
