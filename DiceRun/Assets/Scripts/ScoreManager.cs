using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score;
    private int Combo;
    private int BestCombo;
    public Text ScoreText;
    public Text ComboText;

    private void Awake()
    {
        Score = 0;
        BestCombo = 0;
        Combo = 0;
        UpdateScoreText();
        ComboText.gameObject.SetActive(false);
    }

    public void AddScore(int value)
    {
        Score += value;
        UpdateScoreText();
        AddCombo();

        // + Add Score Effect
    }

    public void MinusScore(int value)
    {
        Score -= value;

        if (Score < 0)
            Score = 0;

        BreakCombo();
        UpdateScoreText();

        // + Minus Score Effect
    }

    private void AddCombo()
    {
        Combo++;
        ComboText.text = Combo.ToString() + " Combo!";
        StartCoroutine(ShowComboText());

        //최대 콤보일경우 BestCombo 갱신
        if (Combo > BestCombo)
            BestCombo = Combo;
    }

    private void BreakCombo()
    {
        Combo = 0;
    }

    private IEnumerator ShowComboText()
    {
        ComboText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        ComboText.gameObject.SetActive(false);
    }

    private void UpdateScoreText()
    {
        ScoreText.text = "Score : " + Score.ToString();
    }
}
