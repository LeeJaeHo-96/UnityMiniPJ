using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObj", order = 1)]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public int maxHp;
    public float speed;
}
