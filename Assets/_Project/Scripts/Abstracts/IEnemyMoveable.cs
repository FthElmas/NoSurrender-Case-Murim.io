using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public interface IEnemyMoveable
{
    Rigidbody Rb {get; set;}
    NavMeshAgent NavMeshAgent{get; set;}

    void MoveEnemy(Vector3 destination);

    
}
