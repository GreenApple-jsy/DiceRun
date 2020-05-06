using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public void StartButtonClick()
    {
        SceneManager.LoadScene("DiceRunMain");
    }

    public void OptionButtonClick()
    {
        //옵션 패널 열기
    }

    public void RankingButtonClick()
    {
        //랭킹 씬 열기
    }

    public void StoreButtonClick()
    {
        //상점 씬 열기
    }

    public void TutorialButtonClick()
    {
        //튜토리얼 씬 열기
    }

    public void QuitButtonClick()
    {
        //종료
        Application.Quit();
    }

    void Update()
    {
        //안드로이드인 경우 뒤로가기 키 입력 처리
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                //종료
                Application.Quit();
            }
        }
    }
}
