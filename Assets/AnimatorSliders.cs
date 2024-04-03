using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFloatSlider : MonoBehaviour
{

    public Animator anim;
    [Range(0.0f, 1.0f)] // Define the range for animSpeed (0.0f to 1.0f)
    public float animSpeed;
    public string floatName;

    private void Update()
    {
        anim.SetFloat(floatName, animSpeed);
    }

    public void UpdateAnimSpeed(float value)
    {
        animSpeed = value;
    }

}
