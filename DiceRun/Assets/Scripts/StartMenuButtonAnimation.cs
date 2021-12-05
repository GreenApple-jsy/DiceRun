using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuButtonAnimation : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject OptionButton;
    public GameObject StoreButton;
    public GameObject RankingButton;
    public GameObject TutorialButton;
    public GameObject QuitButton;

    public float rotationSpeed = 0.01f;
    public float rotationAngle = 1f;
    public float rightAngleVal = 0.705f;

    public void DeactivateButtons()
    {
        StartButton.GetComponent<Button>().interactable = false;
        OptionButton.GetComponent<Button>().interactable = false;
        StoreButton.GetComponent<Button>().interactable = false;
        RankingButton.GetComponent<Button>().interactable = false;
        TutorialButton.GetComponent<Button>().interactable = false;
        QuitButton.GetComponent<Button>().interactable = false;
    }

    public void StartMenu_ButtonAnimation()
    {
        SetParentObject(RankingButton, TutorialButton);

        StartCoroutine(Rotate_x_clockwise(RankingButton));
        StartCoroutine(Rotate_x_clockwise(TutorialButton));
        StartCoroutine(Rotate_y_clockwise(OptionButton));
        StartCoroutine(Rotate_y_anti_clockwise(StoreButton));
        StartCoroutine(Rotate_x_anti_clockwise(QuitButton));

        StartCoroutine(DisableButton(TutorialButton));
    }

    public void OptionMenu_ButtonAnimation()
    {
        SetStartButtonPivot(0);

        SetParentObject(RankingButton, TutorialButton);
        SetParentObject(StartButton, StoreButton);
        SetParentObject(StartButton, RankingButton);
        SetParentObject(StartButton, QuitButton);

        StartCoroutine(Rotate_x_clockwise(RankingButton));
        StartCoroutine(Rotate_x_clockwise(TutorialButton));
        StartCoroutine(Rotate_y_anti_clockwise(StartButton));
        StartCoroutine(Rotate_y_anti_clockwise(StoreButton));
        StartCoroutine(Rotate_x_anti_clockwise(QuitButton));

        StartCoroutine(DisableButton(TutorialButton));
        StartCoroutine(DisableButton(StoreButton));
        StartCoroutine(DisableButton(QuitButton));
    }

    public void TutorialMenu_ButtonAnimation()
    {
        SetRankingButtonPivot(0);
        SetStartButtonPivot(2);
       
        
        SetParentObject(RankingButton, StartButton);
        SetParentObject(StartButton, StoreButton);
        SetParentObject(StartButton, OptionButton);
        SetParentObject(StartButton, QuitButton);

        StartCoroutine(Rotate_x_anti_clockwise(RankingButton));
        StartCoroutine(Rotate_y_clockwise(OptionButton));
        StartCoroutine(Rotate_x_anti_clockwise(StartButton));
        StartCoroutine(Rotate_y_anti_clockwise(StoreButton));
        StartCoroutine(Rotate_x_anti_clockwise(QuitButton));
    }

    public void StoreMenu_ButtonAnimation()
    {

    }

    public void RankingMenu_ButtonAnimation()
    {

    }

    public void QuitMenu_ButtonAnimation()
    {

    }

    void SetParentObject(GameObject parent, GameObject child)
    {
        child.transform.SetParent(parent.transform);
    }

    //pivot : 0왼쪽, 1오른쪽, 2위, 3아래
    void SetStartButtonPivot(int pivotDir)
    {
        Vector2 dir = new Vector2(0f, 0f);
        Vector2 newPos = new Vector2(0f, 0f);

        if (pivotDir == 0)
        {
            newPos = new Vector2(-200, -450);
            dir = new Vector2(0, 0.5f);
        }
        else if (pivotDir == 1) dir = new Vector2(1, 0.5f);
        else if (pivotDir == 2) {
            newPos = new Vector2(0, -250);
            dir = new Vector2(0.5f, 1f);
        }  
        else if (pivotDir == 3) dir = new Vector2(0.5f, 0f);

        StartButton.GetComponent<RectTransform>().pivot = dir;
        StartButton.GetComponent<RectTransform>().anchorMin = dir;
        StartButton.GetComponent<RectTransform>().anchorMax = dir;

        StartButton.transform.localPosition = newPos;
    }

    //pivot : 0위쪽, 1아래쪽
    void SetRankingButtonPivot(int pivotDir)
    {
        Vector2 dir = new Vector2(0f, 0f);
        Vector2 newPos = new Vector2(0f, 0f);

        if (pivotDir == 0)
        {
            newPos = new Vector2(0, 150);
            dir = new Vector2(0.5f, 1f);
        }
        else if (pivotDir == 1)
        {
            newPos = new Vector2(-200, -450);
            dir = new Vector2(0.5f, 0f);
        }
           
        RankingButton.GetComponent<RectTransform>().pivot = dir;
        RankingButton.GetComponent<RectTransform>().anchorMin = dir;
        RankingButton.GetComponent<RectTransform>().anchorMax = dir;

        RankingButton.transform.localPosition = newPos;
    }


    IEnumerator DisableButton(GameObject ob)
    {
        yield return new WaitForSeconds(0.6f);
        ob.SetActive(false);
    }

    IEnumerator Rotate_y_clockwise(GameObject ob)
    {
        while (ob.transform.localRotation.y < rightAngleVal)
        {
            ob.transform.Rotate(new Vector3(0f, rotationAngle, 0));
            yield return rotationSpeed;
        }
    }

    IEnumerator Rotate_y_anti_clockwise(GameObject ob)
    {
        while (ob.transform.localRotation.y > -rightAngleVal)
        {
            ob.transform.Rotate(new Vector3(0f, -rotationAngle, 0));
            yield return rotationSpeed;
        }
    }

    IEnumerator Rotate_x_clockwise(GameObject ob)
    {
        while (ob.transform.localRotation.x < rightAngleVal)
        {
            ob.transform.Rotate(new Vector3(rotationAngle, 0f, 0f));
            yield return rotationSpeed;
        }
    }

    IEnumerator Rotate_x_anti_clockwise(GameObject ob)
    {
        while (ob.transform.localRotation.x > -rightAngleVal)
        {
            ob.transform.Rotate(new Vector3(-rotationAngle, 0f, 0f));
            yield return rotationSpeed;
        }
    }


}
