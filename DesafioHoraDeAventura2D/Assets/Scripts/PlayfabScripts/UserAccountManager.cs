using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.Events;

public class UserAccountManager : MonoBehaviour
{
   public static UserAccountManager instance;
   public static UnityEvent OnLoginSuccess = new UnityEvent();
   public static UnityEvent<string> OnLoginFailed = new UnityEvent<string>();
   public static UnityEvent<string> OnCreateAccountFailed = new UnityEvent<string>();
    void Awake() {
       
           instance = this;
       

   }
    public void CreateAccount(string userName, string emailAddress, string passWord)
    {
        PlayFabClientAPI.RegisterPlayFabUser(
            new  RegisterPlayFabUserRequest()
            {
                Email = emailAddress,
                Password = passWord,
                Username = userName,
                RequireBothUsernameAndEmail = true
            },
            response => 
            {
                Debug.Log("exito ao criar a conta");
                SingIn(userName, passWord);
            },
            error => 
            {
                Debug.Log("erro ao criar a conta");
                Debug.Log("erro = " + error.ErrorMessage);
                OnCreateAccountFailed.Invoke(error.ErrorMessage);
            }
        );

    }

    public void SingIn(string username, string password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
        {
            Username = username,
            Password = password
        },
        response => 
        {
            Debug.Log("exito ao logar");
            OnLoginSuccess.Invoke();
        },
        error => 
        {
            Debug.Log("erro ao logar");
            Debug.Log("erro = " + error.ErrorMessage);
            OnLoginFailed.Invoke(error.ErrorMessage);
        }
        );
    }

}
