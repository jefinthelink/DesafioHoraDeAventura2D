using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiSingIn : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Text errorText;
string username, password;

private void OnEnable() {
    UserAccountManager.OnLoginFailed.AddListener(OnLoginFailed);
    UserAccountManager.OnLoginSuccess.AddListener(OnLoginSucces);
}

private void OnDisable() {
    UserAccountManager.OnLoginFailed.RemoveListener(OnLoginFailed);
     UserAccountManager.OnLoginSuccess.RemoveListener(OnLoginSucces);
}

void OnLoginFailed (string error)
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

    public void SignIn ()
    {
     UserAccountManager.instance.SingIn(username, password);   
    }
}
