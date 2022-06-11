using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationWithTransition : MonoBehaviour
{
    private Animator playerAnimator;

    [SerializeField]
    private GameObject damageCollider;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void PlayFromJumpToRunning(bool run)
    {
        playerAnimator.SetBool(TagHelper.runningAnimationParameter, run);
    }
    public void PlayJump(float velocityY)
    {
        playerAnimator.SetFloat(TagHelper.jumpAnimatiomParameter, velocityY);
    }
    public void PlayDoubleJump()
    {
        playerAnimator.SetTrigger(TagHelper.doubleJumpAnimationParameter);
    }
    public void PlayAttack()
    {
        playerAnimator.SetTrigger(TagHelper.attackAnimationParameter);
    }
    public void PlayJumpAttack()
    {
        playerAnimator.SetTrigger(TagHelper.jumpAttackAnimationParameter);
    }
    void ActivateDamageCollider()
    {
        damageCollider.SetActive(true);
    }
    void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }
}
