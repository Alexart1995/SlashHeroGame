using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject characterPanel;

    [SerializeField]
    private Text highscoreText;

    private CharacterSelectMenu charSelectMenu;
    private void Start()
    {
        highscoreText.text = "Highscore:" + DataManager.GetData(TagHelper.highscoreData) + "M";
        charSelectMenu = GetComponent<CharacterSelectMenu>();
    }
    public void PlayGameScene()
    {
        SceneManager.LoadScene(TagHelper.gameplaySceneName);
    }
    public void SelectCharacter()
    {
        int selectedChar =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameplayController.instance.selectedCharacter = selectedChar;
        DataManager.SaveData(TagHelper.selectedCharacterData, selectedChar);
        charSelectMenu.InitializeCharacterMenu();
    }
    public void EnableCharacterSelection()
    {
        characterPanel.SetActive(true);
        charSelectMenu.InitializeCharacterMenu();
    }
    public void DisableCharacterSelection()
    {
        characterPanel.SetActive(false);
    }
}
