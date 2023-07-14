using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoSurrender.Enemy
{
    public class ChaseState : State
    {
        private GameObject _target;
        CharacterDistanceCheck characterDistance;
        PillDistanceCheck pillDistance;

        public ChaseState(StateMachine stateMachine, EnemyAI enemyAI, CharacterDistanceCheck characterDistance, PillDistanceCheck pillDistance) : base(stateMachine, enemyAI)
        {
            this.characterDistance = characterDistance;
            this.pillDistance = pillDistance;
        }
        
        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Target");
            
        }


        public override void EnterState()
        {
            base.EnterState();
            
        }

        public override void ExitState()
        {
            base.ExitState();

            
        }

        public override void Tick()
        {
            base.Tick();

            if(characterDistance.GetCurrentTarget() != null)
            {
                Vector3 destination = (characterDistance.GetCurrentTarget().position);
                enemyAI.MoveEnemy(destination);
            }
            
            if(characterDistance.GetCurrentTarget() == null)
            {
                enemyAI.StateMachine.ChangeState(enemyAI.PillState);
            }

            

            

            
        }

        public override void FixedTick()
        {
            base.FixedTick();
        }
    }

}
