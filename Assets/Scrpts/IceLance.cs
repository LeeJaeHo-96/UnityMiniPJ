using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLance : MonoBehaviour
{
    Coroutine damaged = null;
    GameObject target;

    private void Start()
    {
        
    }
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.collider.tag == "Monster")
    //     damaged = StartCoroutine(CoDamage(collision.gameObject));
    //
    // }
    //
    // private void OnCollisionExit(Collision collision)
    // {
    //     StopCoroutine(damaged);
    //     Debug.Log("코루틴 종료");
    // }
    //
    // IEnumerator CoDamage(GameObject obj)
    // {
    //     yield return new WaitForSecondsRealtime(1f);
    //     Destroy(obj, 1f);
    //     Debug.Log("코루틴 시작");
    // }

     private void OnTriggerStay(Collider other)
     {
         if (other.CompareTag("Monster"))
         damaged = StartCoroutine(CoDamage(other.gameObject));
    
     }
    
     private void OnTriggerExit(Collider other)
     {
         StopCoroutine(damaged);
         Debug.Log("코루틴 종료");
     }
    
     IEnumerator CoDamage(GameObject obj)
     {
         yield return new WaitForSecondsRealtime(0.5f);
         Destroy(obj);
         Debug.Log("코루틴 시작");
     }
}
