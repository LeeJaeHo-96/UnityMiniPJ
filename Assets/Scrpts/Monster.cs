using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    const float MOVESPEED = 3;
    void Update()
    {
        transform.Translate(Vector3.forward * MOVESPEED * Time.deltaTime);
    }
}
