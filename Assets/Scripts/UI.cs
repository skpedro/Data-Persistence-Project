using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] InputField inputField;
    public void StarGame()
    {
        if (inputField.text!=null){ Save.Instance.SaveData(inputField.text);}
        SceneManager.LoadScene(1);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Leaders()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
