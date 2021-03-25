﻿using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirebaseUserManager : MonoBehaviour {

    [Header ("Login UI")]
    [SerializeField] public InputField loginEmail;
    [SerializeField] public InputField loginPassword;

    [Header ("Sign Up UI")]
    [SerializeField] public InputField signUpEmail;
    [SerializeField] public InputField signUpPassword;
    [SerializeField] public InputField signUpPasswordCheck;

    FirebaseAuth auth;

    void Awake () {
        auth = FirebaseAuth.DefaultInstance;
    }
    void Start () {

        auth.StateChanged += AuthStateChange;

        if (auth.CurrentUser != null) {
            SceneManager.LoadScene ("GarageScene");
        }
    }

    void AuthStateChange (object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser != null) {
            SceneManager.LoadScene ("GarageScene");
        }
    }

    public void SignUp () {
        if (SignUpDataControl ()) {

            auth.CreateUserWithEmailAndPasswordAsync (signUpEmail.text, signUpPassword.text).ContinueWithOnMainThread (task => {
                if (task.IsCanceled) {
                    Debug.Log ("Canceled");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError ("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat ("Firebase user created successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
            });

        } else {
            Debug.LogWarning ("Missing Fields");
        }
    }

    bool SignUpDataControl () {

        if (signUpEmail.text == null || signUpEmail.text == "") {
            return false;
        }
        if (signUpPassword.text == null || signUpPassword.text == "" || signUpPasswordCheck.text == null || signUpPassword.text == "") {
            return false;
        }

        if (signUpPassword.text != signUpPasswordCheck.text) {
            return false;
        }

        return true;
    }

    public void UserLogin () {

        if (LoginDataControl ()) {
            auth.SignInWithEmailAndPasswordAsync (loginEmail.text, loginPassword.text).ContinueWithOnMainThread (task => {
                if (task.IsCanceled) {
                    Debug.LogError ("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted) {
                    Debug.LogError ("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }

                Firebase.Auth.FirebaseUser newUser = task.Result;
                Debug.LogFormat ("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);

            });
        }
    }
    bool LoginDataControl () {

        if (loginEmail.text == null || loginEmail.text == "") {
            return false;
        }
        if (loginPassword.text == null || loginPassword.text == "") {
            return false;
        }
        return true;
    }
}