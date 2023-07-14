using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSurrender.Anim;


namespace NoSurrender.Control
{
    public class PlayerController : MonoBehaviour
    {   
        [SerializeField] private StatsSO statData;
        [SerializeField] FloatingJoystick floatingJoystick;
        public StatsSO StatData{get{return statData;}}
        private float speed;
        private float pillBuffDuration;
        Vector3 _clamp;

        private CharacterAnimation _anim;
        
        private Rigidbody rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            _anim = GetComponent<CharacterAnimation>();
        }
        private void Start()
        {
            
            pillBuffDuration = StatData.PillBuffDuration;
            speed = StatData.Speed;
        }


        private void Update()
        {
            _clamp = transform.position;
            _clamp.Set(_clamp.x, Mathf.Clamp(_clamp.y, 0f, 10f), _clamp.z);
            transform.position = _clamp;
            if (Input.GetButton("Fire1"))
            {
                JoystickBehaviour();
            }
            else if(Input.GetButtonUp("Fire1"))
            {
                rb.velocity = Vector3.zero;
            } 
        }
        private void JoystickBehaviour()
        {
            float horizontal = floatingJoystick.Horizontal;
            float vertical = floatingJoystick.Vertical;

            Vector3 addedPos = new Vector3(horizontal, 0f, vertical);

            rb.velocity = addedPos.normalized * speed;
            
            Vector3 direction  = Vector3.forward * vertical + Vector3.right * horizontal;
            if(horizontal !=0 && vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(direction);
                
            }
             
        }

        

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Target"))
            {
                _anim.PushAnimation();
                
                Vector3 direction = (collision.contacts[0].point - transform.position).normalized ;
                
                collision.rigidbody.AddForce(direction * StatData.PushPower, ForceMode.Impulse);
                
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
                
                _anim.PushedBackAnimation();
            }
        }
    }

}
