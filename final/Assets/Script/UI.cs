using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
   
   [SerializeField] private TMP_Text _testUI;
    [SerializeField] private Weapon _weapon;
    
     // Update is called once per frame
     void Update()
     {
          _testUI.text = _weapon._targetName;
     }
    
}
