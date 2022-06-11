using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private bool destroyEnemy;

    public void TakeDamage()
    {
        if (gameObject.CompareTag(TagHelper.enemyTag))
        {
            SoundManager.instance.PlayEnemyDeathSound();
        }
        else
        {
            SoundManager.instance.PlayObstacleDestroySound();
        }
        Destroy(gameObject);
    }
}
