using System.Collections.Generic;
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
        
        [SerializeField] private List<Sprite> avatars;
        [SerializeField] private List<Sprite> cardsSkin;
        public Sprite GetAvatarAtID(string id) => avatars.Find(x => x.name == id);
        public Sprite GetCardSkinAtID(int id) => cardsSkin.Find(x => x.name == id.ToString());

    }
}