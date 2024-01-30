using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim1 : MonoBehaviour
{
    public string triggerName = "NextAnim";
        Animator anim;

    void Start()
    {
       anim = this.GetComponent<Animator>();
            
    }
    public void NextAnim()
    {
        anim.SetTrigger(triggerName);
    }
}
