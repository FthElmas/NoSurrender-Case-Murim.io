using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatsSO", menuName = "ScriptableObjects/EnemyStatsSO")]
public class EnemyStatsSO : ScriptableObject
{
    public int EnemyNumber;

    public float EnemySpeed;

    public float PushPower;

}
