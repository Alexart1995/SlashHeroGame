using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [HideInInspector]
    public int selectedCharacter = 0;

    [SerializeField]
    private int character2UnlockScore = 100, chararacter3UnlockScore = 300;

    [SerializeField]
    private GameObject[] player;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        int gameData = DataManager.GetData(TagHelper.dataInitialized);
        
        if (gameData == 0)
        {
            selectedCharacter = 0;
            DataManager.SaveData(TagHelper.selectedCharacterData, selectedCharacter);
            DataManager.SaveData(TagHelper.highscoreData, 0);
            DataManager.SaveData(TagHelper.characterData + "0", 1);
            DataManager.SaveData(TagHelper.characterData + "1", 0);
            DataManager.SaveData(TagHelper.characterData + "2", 0);
            DataManager.SaveData(TagHelper.dataInitialized, 1);
        }
        else if (gameData == 1)
        {
            selectedCharacter = DataManager.GetData(TagHelper.selectedCharacterData);
        }
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
            Instantiate(player[selectedCharacter]);
            Camera.main.gameObject.GetComponent<CameraFollow>().FindPlayerRefernece();
            // 
        }
    }
    public void CheckToUnlockCharacter(int score)
    {
        if (score >= chararacter3UnlockScore)
        {
            DataManager.SaveData(TagHelper.characterData + "1", 1);
            DataManager.SaveData(TagHelper.characterData + "2", 1);
        }
        else if (score >= character2UnlockScore)
        {
            DataManager.SaveData(TagHelper.characterData + "1", 1);
        }
    }
}
