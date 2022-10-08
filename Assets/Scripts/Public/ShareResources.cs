using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareResources : MonoBehaviour
{
    public static ShareResources instance
    {
        get
        {
            if (_instance == null)
            {
                var shareResourcePrefab = Resources.Load<GameObject>("ShareResources");
                var go = Instantiate(shareResourcePrefab);
                _instance = go.GetComponent<ShareResources>();
                DontDestroyOnLoad(go);
            }
            else
            {
                Destroy(_instance.gameObject);
            }

            return _instance;
        }
    }
    static ShareResources _instance;


    public CardsData cardsData;
}
