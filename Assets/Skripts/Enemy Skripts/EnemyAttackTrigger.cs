using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyAnimation enemyAnim;
    private void Awake()
    {
        enemyAnim = GetComponentInParent<EnemyAnimation>();
    }

    private void OnTriggerStay2D(Collider2D playerDetection)
    {
        if (playerDetection.CompareTag(TagHelper.playerTag))
        {
            SoundManager.instance.PlayEnemyAttackSound();
            enemyAnim.PlayEnemyAttack();
        }
    }
}
