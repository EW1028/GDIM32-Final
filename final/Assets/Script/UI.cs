using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{

    [SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _HitHolder;
    

    private void Start()
    {
        //_weapon.Onhit += damgeHolderUI;
    }
    public void 激活受击反馈UI()
    {
        _HitHolder.SetActive(true);
        if (_HitHolder.activeSelf)
        {
            StartCoroutine(HitHolderDisappear());
        }
    }

    IEnumerator HitHolderDisappear()
    {
        yield return new WaitForSeconds(0.2f);
        _HitHolder.SetActive(false);
    }

}
