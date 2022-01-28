using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICreateAccount : MonoBehaviour
{

[SerializeField] Canvas canvas;
[SerializeField] Text errorText;

string username, password, emailaddress;

private void OnEnable() {
    UserAccountManager.OnCreateAccountFailed.AddListener(OnCreateAccountFailed);
    UserAccountManager.OnLoginSuccess.AddListener(OnLoginSucces);
}

private void OnDisable() {
    UserAccountManager.OnCreateAccountFailed.RemoveListener(OnCreateAccountFailed);
     UserAccountManager.OnLoginSuccess.RemoveListener(OnLoginSucces);
}

void OnCreateAccountFailed (string error)
{
    errorText.gameObject.SetActive(true);
errorText.text = error;

}
void OnLoginSucces ()
{
canvas.enabled = false;
SceneManager.LoadScene("Menu");
}


    public void UpdateUsername(string _username )
    {
        username = _username;
    }
        public void UpdatePassword(string _password )
    {
        password = _password;
    }
        public void UpdateEmailaddress(string _emailaddress )
    {
        emailaddress = _emailaddress;
    }
    public void CreateAcount ()
    {
     UserAccountManager.instance.CreateAccount(username,emailaddress,password);   
    }

}
