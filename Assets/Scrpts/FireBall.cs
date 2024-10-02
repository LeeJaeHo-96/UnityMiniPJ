using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    GameObject target;
    float shortDis;
    List<GameObject> FoundMonsters;
    GameObject monsters;

    private void Start()
    {
        target = GameObject.FindWithTag("Monster");
    }
    void Update()
    {
        Attack();
    }

    void Attack()
    {


        if (target == null)
        {
            shortDis = 100;
        }

        if (target != null)
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

                    transform.position = Vector3.MoveTowards(gameObject.transform.position, monsters.transform.position, 0.1f);
                }
            }
            transform.position = Vector3.MoveTowards(gameObject.transform.position, monsters.transform.position, 0.1f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log("몬스터 피격");
            Destroy(gameObject);
            target.GetComponent<Monster>().curHp -= 1;
            if (target.GetComponent<Monster>().curHp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
