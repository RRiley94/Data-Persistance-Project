using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler Instance;
    public Text scoreInput;
    public InputField nameInput;
    public string playerName;
    private string nameText;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        BestScore();
    }

    // Update is called once per frame
    void Update()
    {
        nameText = nameInput.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        UpdateName(nameText);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void UpdateName(string nameToAdd)
    {
        playerName += nameToAdd;
    }

    void BestScore()
    {
        SaveScore.Instance.LoadUser();

        scoreInput.text = "Best Score: " + SaveScore.Instance.Name + ":" + SaveScore.Instance.Score;

    }

}
