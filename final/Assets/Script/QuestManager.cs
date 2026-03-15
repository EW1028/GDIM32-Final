using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject _questBoard;
    [SerializeField] private RectTransform _questUI;
    [SerializeField] private GameObject _alarmUI;

    private float space = 10f;
    //private RectTransform _lastSpawnQuest;
    private List<RectTransform>_activeQuests = new List<RectTransform>();
    private int _maxQuests = 3;
    private void Start()
    {
        QuestUI.QuestDestroy += OnQuestDestroy;
    }

    public void SpawnQuests()
    {
        _alarmUI.SetActive(false);
        if (_activeQuests.Count >= _maxQuests)
        {
            StartCoroutine(ShowForSecond());
            return;
        }

        GameObject NewQuest = Instantiate(_questBoard, _questUI);
        RectTransform rt = NewQuest.GetComponent<RectTransform>();


        rt.anchorMin = new Vector2(0, 1);
        rt.anchorMax = new Vector2(0, 1);
        rt.pivot = new Vector2(0, 1);

        if (_activeQuests.Count == 0)
        {
            rt.anchoredPosition = new Vector2(0, 0);
        }
        else
        {
            RectTransform Lastrt = _activeQuests[_activeQuests.Count - 1];
            float YPos = Lastrt.anchoredPosition.y - Lastrt.rect.height - space;
            rt.anchoredPosition = new Vector2(0, YPos);
        }
        _activeQuests.Add(rt);

        Debug.Log(_activeQuests.Count);
        
    }

   IEnumerator ShowForSecond()
    {
        _alarmUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        _alarmUI.SetActive(false);
    }
    public void OnQuestDestroy(QuestUI questUI)
    {
        RectTransform DestrouRt = questUI.GetComponent<RectTransform>();
        _activeQuests.Remove(DestrouRt);

        float currentY = 0;
        foreach (RectTransform questRt in _activeQuests)
        {
            questRt.anchoredPosition = new Vector2(0, currentY);
            currentY -= questRt.rect.height + space;
        }

    }
}
