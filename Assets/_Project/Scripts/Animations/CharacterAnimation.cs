using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSurrender.Enemy;


namespace NoSurrender.Anim
{
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _anim;
        Rigidbody rigidb;
        private void Awake()
        {
            _anim = GetComponent<Animator>();
            rigidb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
            WalkAnimation();
        }

        private void WalkAnimation()
        {
            
        var localVelocity = Quaternion.Inverse(transform.rotation) * (rigidb.velocity);

        
        _anim.SetFloat("Speed", Mathf.Clamp(localVelocity.z, 0, 10), 0.1f, Time.deltaTime * 100);
        
        }

        public void PushAnimation()
        {
            _anim.SetBool("Push", true);
        }

        public void ResetPushAnimation()
        {
            _anim.SetBool("Push", false);
        }
        public void PushedBackAnimation()
        {
            _anim.SetTrigger("Pushed");
        }
        
        
    }

}
