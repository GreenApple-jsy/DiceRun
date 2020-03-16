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
        //랭킹 패널 열기
    }


    void Update()
    {
        //뒤로가기 키 처리
    }

    public void QuitButtonClick()
    {
        //종료
        Application.Quit();
    }
}
