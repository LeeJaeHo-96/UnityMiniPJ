using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterFactory : MonoBehaviour
{
    public abstract void CreateMoster();
}

//public class GoblinFactory : MonsterFactory
//{
//    public GameObject goblin;
//    public GameObject clawGoblin;
//
//    public override GameObject CreateMoster(string type)
//    {
//        GameObject monster = null;
//
//        if (type.Equals("goblin"))
//        {
//            monster = Instantiate(goblin);
//        }
//
//        else if (type.Equals("clawGoblin"))
//        {
//            monster = Instantiate(clawGoblin);
//        }
//
//        return monster;
//    }
//}