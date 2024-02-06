using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [Header("Animation")]
    [SerializeField] private string animationName;
    [SerializeField] private EventSO animStartEvent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //animator.StopPlayback();
    }

    private void OnEnable()
    {
        animStartEvent.Action += StartAnimation;
    }

    private void OnDisable()
    {
        animStartEvent.Action -= StartAnimation;
    }

    private void StartAnimation()
    {
        animator.PlayInFixedTime(animationName);
    }

    private void StopAnimation()
    {
        animator.StopPlayback();
    }
}
