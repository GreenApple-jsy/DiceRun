using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public GameObject OptionButton;
    public GameObject StartButton;
    public GameObject StoreButton;
    public GameObject QuitButton;
    public GameObject RankingButton;
    public GameObject TutorialButton;
    public GameObject Tutorial_Ranking_Buttons;

    //씬 로드
    private IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
    }

    //전체 버튼 비활성화
    private void DisableAllButtons()
    {
        OptionButton.GetComponent<Button>().interactable = false;
        StartButton.GetComponent<Button>().interactable = false;
        StoreButton.GetComponent<Button>().interactable = false;
        QuitButton.GetComponent<Button>().interactable = false;
        RankingButton.GetComponent<Button>().interactable = false;
        TutorialButton.GetComponent<Button>().interactable = false;
    }

    public void StartButtonClick()
    {
        DisableAllButtons();

        OptionButton.GetComponent<Animation>().Play();
        QuitButton.GetComponent<Animation>().Play();
        StoreButton.GetComponent<Animation>().Play();
        Tutorial_Ranking_Buttons.GetComponent<Animation>().Play();

        StartCoroutine(LoadScene("DiceRunMain"));
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
