using UnityEngine;

namespace PublicScripts.Entity
{
    [CreateAssetMenu(fileName = "DataModel", menuName = "GameData", order = 0)]
    public class GameDataModel : ScriptableObject
    {
        public string ID;

        public Sprite GetSprite => Resources.Load<Sprite>("GameResources/Design/Avatars/Sprites/" + ID);
    }
}