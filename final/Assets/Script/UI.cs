using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{

    //[SerializeField] private Weapon _weapon;
    [SerializeField] private GameObject _HitHolder;
    [SerializeField] private TMP_Text _ClipNumText;
    

    private void Start()
    {
        //_weapon.Onhit += damgeHolderUI;
        _ClipNumText.text = "Mag NUM: " + GameController.Instance.Weapon._clipNUM.ToString();
    }
    private void Update()
    {
        _ClipNumText.text = "Mag NUM: " + GameController.Instance.Weapon._clipNUM.ToString();
    }

    public void 激活受击反馈UI()
    { 
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
