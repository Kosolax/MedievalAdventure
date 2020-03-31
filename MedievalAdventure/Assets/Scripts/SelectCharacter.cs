using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    
    private int selectedCharacterId;
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private Image physiqueCharacter;
    [Header("List of character")]
    [SerializeField] private List<CharacterSelect> characterList = new List<CharacterSelect>();

    private void Start()
    {
        UpdateCharacter();
    }

    public void LeftArrow()
    {
        selectedCharacterId--;
        if(selectedCharacterId < 0)
        {
            selectedCharacterId = characterList.Count - 1;
        }
        UpdateCharacter();
    }

    public void RightArrow()
    {
        selectedCharacterId++;
        //Si on est au max de la liste on retourne à 0
        if (selectedCharacterId == characterList.Count)
        {
            selectedCharacterId = 0;
        }
        UpdateCharacter();
    }
    public void Confirm()
    {
        Debug.Log(string.Format("Character {0}:{1} has been chosen", selectedCharacterId, characterList[selectedCharacterId].characterName));
    }
    
    // Update is called once per frame
    private void UpdateCharacter(){
        characterName.text = characterList[selectedCharacterId].characterName;
        physiqueCharacter.sprite = characterList[selectedCharacterId].physiqueCharacter;
    }
    [System.Serializable]
    public class CharacterSelect{
        public string characterName;
        public Sprite physiqueCharacter;
    }
}
