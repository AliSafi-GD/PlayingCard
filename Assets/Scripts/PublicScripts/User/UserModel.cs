using UnityEngine;

namespace PublicScripts.Entity
{
    public class UserModel
    {
        public EUser entity;

        public UserModel(EUser entity)
        {
            this.entity = entity;
        }

        public Sprite GetAvatar => ShareResources.Instance.GetAvatarAtID(entity.AvatarID);
    }
}