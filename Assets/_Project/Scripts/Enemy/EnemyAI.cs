using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NoSurrender.Control;
using System;
using NoSurrender.Anim;

namespace NoSurrender.Enemy
{
    public class EnemyAI : MonoBehaviour, IEnemyMoveable, ITriggerCheckable
    {
        public Rigidbody Rb{get; set;}
        public NavMeshAgent NavMeshAgent{get; set;}
        public StateMachine StateMachine{get; set;}
        public PillState PillState {get; set;}
        public ChaseState ChaseState{get; set;}
        CharacterAnimation _anim;
        
        

        public EnemyStatsSO EnemyStat{get{return enemyStat;}}
        [SerializeField] private EnemyStatsSO enemyStat;


        #region TriggerBools
        public bool IsTherePill {get; set;} = false;

        public bool IsThereCharacter {get; set;} = false;

        

        #endregion

        private void Awake()
        {
            StateMachine = new StateMachine();

            PillState = new PillState(StateMachine, this, GetComponentInChildren<PillDistanceCheck>(), GetComponentInChildren<CharacterDistanceCheck>());
            ChaseState = new ChaseState(StateMachine, this, GetComponentInChildren<CharacterDistanceCheck>(), GetComponentInChildren<PillDistanceCheck>());
            _anim = GetComponent<CharacterAnimation>();


        }
        private void Start()
        {
            Rb = GetComponent<Rigidbody>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            StateMachine.Initialize(PillState);
            Invoke("EnableNavMeshAgent", 0.025f);
            
        }

        private void Update()
        {
            
            StateMachine.CurrentState.Tick();

            
            
        }

        private void FixedUpdate()
        {
            StateMachine.CurrentState.FixedTick();
        }

        private void EnableNavMeshAgent ()
        {
            NavMeshAgent.enabled = true;
        }

        public void MoveEnemy(Vector3 destination)
        {
            NavMeshAgent.destination = destination;
            NavMeshAgent.isStopped = false;
            NavMeshAgent.speed = EnemyStat.EnemySpeed;
            
            
        }

        #region DistanceChecks

        public void SetPillStatus(bool isTherePill)
        {
            IsTherePill = isTherePill;
        }

        public void SetCharacterRangeStatus(bool isThereCharacter)
        {
            IsThereCharacter = isThereCharacter;
        }

       
            
        #endregion

        

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Target"))
            {
                Vector3 direction = (collision.contacts[0].point - transform.position).normalized ;

                collision.rigidbody.AddForce(direction * EnemyStat.PushPower, ForceMode.Impulse);
                _anim.PushAnimation();
                
            }
            if(collision.gameObject.CompareTag("Fog"))
            {
                Destroy(gameObject);
            }
            
        }

        

        private void OnCollisionExit(Collision collision)
        {
            if(collision.gameObject.CompareTag("Target"))
            {
                _anim.ResetPushAnimation();
                
                
            }
        }



    }

}
