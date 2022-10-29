using PublicScripts.Entity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UserView : MonoBehaviour
{
    [SerializeField] private Image imgAvatar;
    [SerializeField] private TMP_Text txtPublicID;
    private UserModel _userData;

    public void Bind(UserModel model)
    {
        _userData = model;
        imgAvatar.sprite = model.GetAvatar;
        txtPublicID.text = model.entity.PublicID;
    }
}

