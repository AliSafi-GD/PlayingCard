using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHokmSymbols_View : MonoBehaviour
{
    [SerializeField] private Button btnHeart;
    [SerializeField] private Button btnSpade;
    [SerializeField] private Button btnDiamond;
    [SerializeField] private Button btnClubs;


    private void Start()
    {
        btnHeart.onClick.AddListener(()=>Hokm_GameManager.OnSetKingSymbol(Symbol.Heart));
        btnSpade.onClick.AddListener(()=>Hokm_GameManager.OnSetKingSymbol(Symbol.Spade));
        btnDiamond.onClick.AddListener(()=>Hokm_GameManager.OnSetKingSymbol(Symbol.Diamond));
        btnClubs.onClick.AddListener(()=>Hokm_GameManager.OnSetKingSymbol(Symbol.Clubs));
    }

}
