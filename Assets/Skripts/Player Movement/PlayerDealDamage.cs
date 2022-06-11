using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDealDamage : MonoBehaviour
{
    [SerializeField]
    private bool deactivateSward;
    private void OnTriggerEnter2D(Collider2D attackDestination)
    {
        if (attackDestination.CompareTag(TagHelper.playerTag))
        {
            attackDestination.GetComponent<PlayerHealth>().SubtractHealth();
            //SoundManager.instance.PlayPlayerAttackSound();
            Debug.Log("Deal Damage to Player");
            if (deactivateSward)
                deactivateSward = false;
        }
        if (attackDestination.CompareTag(TagHelper.enemyTag) ||
            attackDestination.CompareTag(TagHelper.obstacleTag))
        {
            attackDestination.GetComponent<EnemyHealth>().TakeDamage();
            Debug.Log("Deal damage to Enemy");
        }
    }
}
