using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    AudioSource source;
    Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    public void SetValue(AnimParams _name)
    {
        animator.SetTrigger(_name.ToString());
    }

    public void SetValue(AnimParams _name, bool _value)
    {
        animator.SetBool(_name.ToString(), _value);
    }

    public void SetValue(AnimParams _name, float _value)
    {
        animator.SetFloat(_name.ToString(), _value);
    }

    
    public enum AnimParams
    {
        Null,
        Forward,
        Strafe,
        Jump,
        YMCA,
        isMoving
    }
}



