using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuButtonAnimation : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject OptionButton;
    public GameObject StoreButton;
    public GameObject RankingButton;
    public GameObject TutorialButton;
    public GameObject QuitButton;
    public GameObject Start_Ranking_Tutorial_Buttons;
    public GameObject Ranking_Tutorial_Buttons;

    public float rotationSpeed = 0.02f;
    public float rotationAngle = 2f;
    public float rightAngleVal = 0.7f;

    public void StartMenu_ButtonAnimation()
    {
        StartCoroutine(Tutorial_Rotation());
        StartCoroutine(Option_Rotation());
        StartCoroutine(Store_Rotation());
        StartCoroutine(Quit_Rotation());
        StartCoroutine(Ranking_Tutorial_Rotation());
    }

    public void OptionMenu_ButtonAnimation()
    {

    }

    public void TutorialMenu_ButtonAnimation()
    {

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

    IEnumerator Option_Rotation()
    {
        while (OptionButton.transform.rotation.y < rightAngleVal)
        {
            OptionButton.transform.Rotate(new Vector3(0f, rotationAngle, 0));
            yield return rotationSpeed;
        }
    }

    IEnumerator Store_Rotation()
    {
        while (StoreButton.transform.rotation.y > -rightAngleVal)
        {
            StoreButton.transform.Rotate(new Vector3(0f, -rotationAngle, 0));
            yield return rotationSpeed;
        }
    }

    IEnumerator Quit_Rotation()
    {
        while (QuitButton.transform.rotation.x > -rightAngleVal)
        {
            QuitButton.transform.Rotate(new Vector3(-rotationAngle, 0f, 0f));
            yield return rotationSpeed;
        }
    }

    IEnumerator Ranking_Tutorial_Rotation()
    {
        while (Ranking_Tutorial_Buttons.transform.rotation.x < rightAngleVal)
        {
            Ranking_Tutorial_Buttons.transform.Rotate(new Vector3(rotationAngle, 0f, 0f));
            yield return rotationSpeed;
        }
    }

    IEnumerator Tutorial_Rotation()
    {
        while (TutorialButton.transform.rotation.x < rightAngleVal)
        {
            TutorialButton.transform.Rotate(new Vector3(rotationAngle, 0f, 0f));
            yield return rotationSpeed;
        }
        TutorialButton.SetActive(false);
    }
}
