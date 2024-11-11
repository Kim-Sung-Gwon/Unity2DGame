using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    public AnimationClip clip;

    private readonly int Move = Animator.StringToHash("MoveFloat");
    private readonly int Jump = Animator.StringToHash("JumpBool");
    private readonly int DJump = Animator.StringToHash("DoubleJumpTrigger");
    private readonly int Die = Animator.StringToHash("DieTrigger");

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void MoveAni(Vector2 move)
    {
        Animator.SetFloat(Move, move.x);
    }

    public void JumpAni(bool value)
    {
        Animator.SetBool(Jump, value);
    }

    public void DoubleJumpAni()
    {
        Animator.SetTrigger(DJump);
    }

    public void DieAni()
    {
        Animator.SetTrigger(Die);
    }
}
