using System;
using System.Collections;
using System.Collections.Generic;
using PublicScripts.Entity;
using UnityEngine;

public class CardCreator : MonoBehaviour
{
    public static CardCreator instance;

    private void Awake()
    {
        instance = this;
    }

    public Card Create(ECard entity,Transform parent)
    {
        var card = Instantiate(ShareResources.Instance.CardPrefab, parent);
        card.Bind(entity);
        return card;
    }
    public Card Create(ECard entity,Vector3 firstPos,Quaternion firstRot)
    {
        var card = Instantiate(ShareResources.Instance.CardPrefab,firstPos,firstRot);
        card.Bind(entity);
        return card;
    }
    public Card Create(ECard entity,Vector3 firstPos,Quaternion firstRot,Transform parent)
    {
        var card = Instantiate(ShareResources.Instance.CardPrefab,firstPos,firstRot, parent);
        card.Bind(entity);
        return card;
    }
}
