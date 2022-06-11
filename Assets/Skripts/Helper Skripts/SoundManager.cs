using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource bgAudio;

    [SerializeField]
    private AudioClip bgMusic, mainMenuMusic, playerAttackSound, gameOverSound,
        playerJump, playerDeathSound, enemyAttackSound,
        enemyDeathSound, collectableSound, destroyObstacleSound;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        bgAudio = GetComponent<AudioSource>();
    }
    void PlayBGMusic(bool gameplay)
    {
        if (gameplay)
        {
            bgAudio.clip = bgMusic;
            bgAudio.Play();
        }
        else
        {
            bgAudio.clip = mainMenuMusic;
            bgAudio.Play();
        }
    }
    public void PlayGameOverSound()
    {
        AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
    }
    public void PlayPlayerAttackSound()
    {
        AudioSource.PlayClipAtPoint(playerAttackSound, transform.position);
    }
    public void PlayPlayerJumpSound()
    {
        AudioSource.PlayClipAtPoint(playerJump, transform.position);
    }
    public void PlayPlayerDeathSound()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
    }
    public void PlayEnemyAttackSound()
    {
        AudioSource.PlayClipAtPoint(enemyAttackSound, transform.position);
    }
    public void PlayEnemyDeathSound()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
    }
    public void PlayCollectableSound()
    {
        AudioSource.PlayClipAtPoint(collectableSound, transform.position);
    }
    public void PlayObstacleDestroySound()
    {
        AudioSource.PlayClipAtPoint(destroyObstacleSound, transform.position);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == TagHelper.gameplaySceneName)
        {
            PlayBGMusic(true);
            // 
        }
        else
        {
            PlayBGMusic(false);
        }
    }
}
