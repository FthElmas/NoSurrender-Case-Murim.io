using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NoSurrender.Enemy
{
    public class PillState : State
    {
        public Transform PillTransform;
        PillDistanceCheck pillDistance;
        CharacterDistanceCheck characterDistance;
        
        public PillState(StateMachine stateMachine, EnemyAI enemyAI, PillDistanceCheck pillDistance, CharacterDistanceCheck characterDistance) : base(stateMachine, enemyAI)
        {
            this.pillDistance = pillDistance;
            this.characterDistance = characterDistance;
        }

        private void Start()
        {
            
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


            
            if(pillDistance.GetCurrentTarget() != null)
            {
                Vector3 destination = (pillDistance.GetCurrentTarget().position);
                enemyAI.MoveEnemy(destination);
            }
            
            
            

            if(enemyAI.IsThereCharacter)
            {
                enemyAI.StateMachine.ChangeState(enemyAI.ChaseState);
            }
        }

        public override void FixedTick()
        {
            base.FixedTick();
        }
    }

}
