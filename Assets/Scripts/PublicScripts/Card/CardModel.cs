using UnityEngine;

namespace PublicScripts.Entity
{
    [System.Serializable]
    public class CardModel
    {
        private ECard entity;

        public CardModel(ECard entity)
        {
            this.entity = entity;
        }

        public Sprite sprite
        {
            get => ShareResources.Instance.GetCardSkinAtID(entity.ID);
        }
    }
}