using UnityEngine;

namespace PublicScripts.Entity
{
    public class EUser
    {
        public EUser()
        {
        }
        
        public EUser(string publicID, string privateID, string avatarID)
        {
            PublicID = publicID;
            PrivateID = privateID;
            AvatarID = avatarID;
        }

       

        public string PublicID { get; set; }
        public string PrivateID { get; set; }
        public string AvatarID { get; set; }
        
        
    }
}