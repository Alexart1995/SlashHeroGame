using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject[] healthBar;

    private int healthBarIndex;

    private int health;
    private void Start()
    {
        healthBar = GameObject.FindWithTag(TagHelper.healthBarHolder).GetComponent<HealthBarHolder>().healthBar;
        health = healthBar.Length;
        healthBarIndex = health - 1;
    }

    public void SubtractHealth()
    {
        healthBar[healthBarIndex].SetActive(false);
        healthBarIndex--;
        health--;

        if (health <= 0)
        {
            SoundManager.instance.PlayGameOverSound();
            GameObject.FindWithTag(TagHelper.gameplayControllerTag).GetComponent<GameOverController>().ShowGameOverCanvas();
            //Destroy(gameObject);
            // gameover
        }
    }

    void AddHealth()
    {
        if (health == healthBar.Length)
            return;
        if (health < healthBar.Length)
        {
            health++;
            healthBarIndex++;
            healthBar[healthBarIndex].SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D healthCollider)
    {
        if (healthCollider.CompareTag(TagHelper.healthTag))
        {
            SoundManager.instance.PlayCollectableSound();
            AddHealth();
            //Destroy(gameObject);
            healthCollider.gameObject.SetActive(false);
        }
    }
}
