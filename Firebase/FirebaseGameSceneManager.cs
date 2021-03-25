using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirebaseGameSceneManager : MonoBehaviour {

    [Header ("Game Panel UI")]

    [SerializeField] Text nameText;
    [SerializeField] Text xpText;
    [SerializeField] Text levelText;

    [SerializeField] InputField changeNameInput;

    [Header ("Loading Panel UI")]
    [SerializeField] Text loadingText;

    [Header ("Panels")]
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject loadingPanel;

    FirebaseAuth auth;
    DatabaseReference reference;

    Coroutine loadingCoroutine;
    string loadingString = "Loading";
    int timer = 0;
    bool loaded = false;

    void Awake () {
        auth = FirebaseAuth.DefaultInstance;
    }
    void Start () {

        if (auth.CurrentUser == null) {
            SceneManager.LoadScene ("LoginScene");
        } else {
            loadingCoroutine = StartCoroutine (Loading ());
            //Database
            //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl ("https://racing-game-5a836-default-rtdb.firebaseio.com/");
            //google-services-json eklediğimiz için bu süürmde ullanmıyoruz

            reference = FirebaseDatabase.DefaultInstance.RootReference;
            PullData ();
        }
    }

    IEnumerator Loading () {
        loaded = false;
        gamePanel.SetActive (false);
        loadingPanel.SetActive (true);
        while (!loaded) {

            timer += 1;
            loadingText.text = loadingString + new String ('.', timer);

            if (timer > 3)
                timer = 0;
            yield return new WaitForSeconds (.1f);
        }
        gamePanel.SetActive (true);
        loadingPanel.SetActive (false);
    }

    void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            PullData ();
        }
    }

    public void updateName () {
        if (changeNameInput.text != null || changeNameInput.text != "" || changeNameInput.text != changeNameInput.text) {
            reference.Child ("GameDatas").Child (auth.CurrentUser.UserId).Child ("UserName").SetValueAsync (changeNameInput.text);
        }
    }

    void PullData () {
        loadingCoroutine = StartCoroutine (Loading ());
        
        reference.Child ("GameDatas").Child (auth.CurrentUser.UserId).GetValueAsync ().ContinueWithOnMainThread (task => {
            if (task.IsFaulted) {
                Debug.Log ("Database Error");
            } else if (task.IsCompleted) {
                DataSnapshot snapshot = task.Result;
                if (snapshot.GetRawJsonValue () == null) {
                    Debug.Log ("Empty");
                    CreateEmptyData ();
                    PullData ();
                } else {
                    //
                    Debug.Log (snapshot.GetRawJsonValue ());
                    GameData data = JsonUtility.FromJson<GameData> (snapshot.GetRawJsonValue ());
                    nameText.text = "User Name: " + data.UserName;
                    xpText.text = "Xp: " + data.xp;
                    levelText.text = "Level: " + data.level;

                    loaded = true;
                }
            }
        });
    }

    void CreateEmptyData () {
        GameData emptyData = new GameData {
            UserName = "JJ",
            xp = 0,
            level = 1
        };

        string emptyJson = JsonUtility.ToJson (emptyData);
        reference.Child ("GameDatas").Child (auth.CurrentUser.UserId).SetRawJsonValueAsync (emptyJson);
    }

    public void LogOut () {
        auth.SignOut ();
        SceneManager.LoadScene ("LoginScene");
    }
}

public class GameData {
    public string UserName;
    public float xp;
    public int level;
}