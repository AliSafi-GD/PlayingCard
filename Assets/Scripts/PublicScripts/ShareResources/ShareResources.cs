using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PublicScripts.Entity
{
    public class ShareResources : MonoBehaviour
    {
      
        public static ShareResources Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<ShareResources>("GameResources/ShareResources");
                    DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }
        private static ShareResources _instance;

        public Card CardPrefab;
        
        public Sprite GetCardSprite(string skinNumber, int cardId)
        {
            return Resources.LoadAll<Sprite>($"GameResources/Design/Cards/{skinNumber}/1").ToList()
                .Find(x => x.name == cardId.ToString());
        }


    }
}