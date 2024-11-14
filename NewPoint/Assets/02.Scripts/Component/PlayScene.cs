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
        Time.timeScale = 1.0f;
    }

    public void Piairie_1()
    {
        SceneManager.LoadScene("Map_Piairie-1");
        Time.timeScale = 1.0f;
    }

    public void Piairie_2()
    {
        SceneManager.LoadScene("Map_Piairie-2");
        Time.timeScale = 1.0f;
    }

    public void Cave_1()
    {
        SceneManager.LoadScene("Map_Cave-1");
        Time.timeScale = 1.0f;
    }

    public void Cave_2()
    {
        SceneManager.LoadScene("Map_Cave-2");
        Time.timeScale = 1.0f;
    }

    public void Temple_1()
    {
        SceneManager.LoadScene("Map_Temple-1");
        Time.timeScale = 1.0f;
    }

    public void Temple_2()
    {
        SceneManager.LoadScene("Map_Temple-2");
        Time.timeScale = 1.0f;
    }

    // 모든 어플리 캐이션에서 플레이를 종료 시키는 함수
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
Application.Quti();
#endif
    }
}
