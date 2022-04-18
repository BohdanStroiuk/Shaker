using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidBehavior : MonoBehaviour
{
    public bool isOpen;
    private Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.speed = 0;
    }

    public void OpenLid()
    {
        
        anim.speed = 1;
        
        anim.Play(0);
        isOpen = true;
        
    }

    public void CloseLid()
    {
        anim.speed = -1;


        anim.Play(0);
        isOpen = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
