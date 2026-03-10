using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject _NpcDialogue;
    [SerializeField] private GameObject _PlayerOptions;
    [SerializeField] private TMP_Text _DialogueText;

    public void ShowDialogue(string DialogueText)
    {
        gameObject.SetActive(true);
        _NpcDialogue.SetActive(true);
        _PlayerOptions.SetActive(false);
        _DialogueText.text = DialogueText;
    }   
}
