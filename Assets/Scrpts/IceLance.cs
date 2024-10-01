using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLance : MonoBehaviour
{
    Coroutine damaged = null;
    GameObject target;
    Animator animator;
    GameObject player;
    private void Start()
    {
        animator = GameObject.Find("Player").GetComponent<Animator>();
    }
    

     private void OnTriggerStay(Collider other)
     {
         if (other.CompareTag("Monster"))
         damaged = StartCoroutine(CoDamage(other.gameObject));
    
     }
    
     private void OnTriggerExit(Collider other)
     {
         StopCoroutine(damaged);
         
     }
    
     IEnumerator CoDamage(GameObject obj)
     {
        animator.SetBool("isAttack", true);
        yield return new WaitForSecondsRealtime(3f);
        if (obj != null)
        {
            obj.GetComponent<Monster>().curHp -= 1;
            Debug.Log("몬스터 피격");
            animator.SetBool("isAttack", false);
        }
        
        
     }
}
