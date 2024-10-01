using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 3;

    Animator animator;

    GameObject enemy;
    public List<GameObject> FoundMonsters;
    public GameObject monsters;
    public float shortDis;
    [SerializeField] GameObject iceTarget;
    [SerializeField] GameObject iceLance;


    void Start()
    {
        animator = GetComponent<Animator>();
        
        iceLance.SetActive(false);
        

    }

    
    void Update()
    {
       
        Move();
        Attack();

    }

    


    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * z * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right* x * moveSpeed * Time.deltaTime, Space.World);

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 6;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3;
        }
        animator.SetFloat("moveSpeed", moveSpeed);

        if(new Vector3(x, 0 ,z) == Vector3.zero)
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

    void Attack()
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
            iceTarget.transform.position = monsters.transform.position;
        }
        
        if (shortDis <= 30)
        {
            animator.SetBool("isAttack", true);
            iceLance.SetActive(true);

        }
        else
        {
            animator.SetBool("isAttack", false);
            iceLance.SetActive(false);
        }

        //범위안에 적이 들어오면
        // 아이스타겟의 위치가 그 적 위치로
        // 그럼 데미지 1입음 1초마다
    }
}
