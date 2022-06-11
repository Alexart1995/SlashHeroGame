using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator enemyAnimator;

    [SerializeField]
    private GameObject damageCollider;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void PlayEnemyAttack()
    {
        enemyAnimator.SetTrigger(TagHelper.attackTriggerParameter);
    }

    public void PlayEnemyDeath(bool death)
    {
        enemyAnimator.SetBool(TagHelper.deathAnimationParameter, true);
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
