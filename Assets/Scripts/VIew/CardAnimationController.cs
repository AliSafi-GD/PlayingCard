using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimationController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public void ShowFront() => anim.SetBool("show", true);
    public void ShowBack() => anim.SetBool("show", false);
}
