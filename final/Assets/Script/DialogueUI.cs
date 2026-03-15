using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject _NpcDialogue;
    [SerializeField] private GameObject _PlayerOptions;
    [SerializeField] private TMP_Text _DialogueText;
    [SerializeField] private TMP_Text _PlayerOption1;
    [SerializeField] private TMP_Text _PlayerOption2;

    public void ShowDialogue(string DialogueText)
    {
        gameObject.SetActive(true);
        _NpcDialogue.SetActive(true);
        _PlayerOptions.SetActive(false);
        _DialogueText.text = DialogueText;
    }   

    public void ShowAnswer(string [] Options)
    {
        _NpcDialogue.SetActive(false);
        _PlayerOptions.SetActive(true);
        _PlayerOption1.text = Options[0];
        if (Options.Length >= 2)
        {
            _PlayerOption2.transform.parent.gameObject.SetActive(true);
            _PlayerOption2.text = Options[1];
        }
        else
        {
            _PlayerOption2.transform.parent.gameObject.SetActive(false);
            _PlayerOption2.text = "";
        }
        
    }
    
    public void DialogueHide()
    {
        _NpcDialogue.SetActive(false);
        _PlayerOptions.SetActive(false);
        gameObject.SetActive(false);
        _DialogueText.text = "";
    }
}
