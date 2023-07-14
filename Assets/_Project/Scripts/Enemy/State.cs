using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSurrender.Enemy;

public class State
{
    protected EnemyAI enemyAI;
    protected StateMachine stateMachine;

    public enum StateIds
    {
        Attacking,
        GoingForPill
    }
    public State(StateMachine stateMachine, EnemyAI enemyAI)
    {
        this.stateMachine = stateMachine;
        this.enemyAI = enemyAI;
    }

    
    public  virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void Tick() { }
    public virtual void FixedTick() { }
    public virtual void OnCollisionEnter(Collision collision) { }




}
