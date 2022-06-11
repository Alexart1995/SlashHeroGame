using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectMenu : MonoBehaviour
{
    [SerializeField]
    private Button[] characterSelectButtons;

    [SerializeField]
    private GameObject[] selectedCharacterCheckbox;

    public void InitializeCharacterMenu()
    {
        for(int i = 0; i < characterSelectButtons.Length; i++)
        {
            int charData = DataManager.GetData(TagHelper.characterData + i.ToString());
            if (charData == 0)
            {
                characterSelectButtons[i].interactable = false;
            }
            selectedCharacterCheckbox[i].SetActive(false);
        }
        selectedCharacterCheckbox[DataManager.GetData(TagHelper.selectedCharacterData)].SetActive(true);
    }
}
