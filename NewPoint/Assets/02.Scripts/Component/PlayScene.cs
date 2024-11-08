using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour
{
    public void LobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void MapHelp()
    {
        SceneManager.LoadScene("Map_Help");
    }

    public void Map_1()
    {
        SceneManager.LoadScene("Map_1");
    }

    public void Map_2()
    {
        SceneManager.LoadScene("");
    }

    public void Map_3()
    {
        SceneManager.LoadScene("");
    }

    public void Map_4()
    {
        SceneManager.LoadScene("");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
Application.Quti();
#endif
    }
}
