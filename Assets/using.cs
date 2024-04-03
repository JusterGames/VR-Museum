using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorSlider : MonoBehaviour
{
    public Animator anim;
    public Slider slider;
    public string floatName;

    private void Start()
    {
        anim = GetComponent<Animator>();
        slider.onValueChanged.AddListener(UpdateAnimSpeed);
    }

    private void UpdateAnimSpeed(float value)
    {
        anim.SetFloat(floatName, value);
    }
}
