using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHitterManager : MonoBehaviour
{
    public int currentNumber = 0;
    public int nextNumber = 0;
    public bool isPlaying;
    private float duration;
    private GameObject diceHitter;
    private GameObject newDiceHitter;
    private Vector3 diceHitterPosition = new Vector3(0, 20f, 30);
    private Quaternion diceHitterRotation = Quaternion.Euler(-90, 0, 0);

    void Start()
    {
        diceHitter = GameObject.Find("DiceHitter");
        duration = 6f;
        isPlaying = true;
        StartCoroutine(generateDiceHitter());
    }

    IEnumerator generateDiceHitter()
    {
        while (isPlaying)
        {
            currentNumber = nextNumber;
            do{
                nextNumber = Random.Range(1, 7);
            } while (currentNumber == nextNumber);
            newDiceHitter = Instantiate(diceHitter, diceHitterPosition, diceHitterRotation);
            newDiceHitter.GetComponent<DiceHitterController>().ChangeNumber(nextNumber);
            yield return new WaitForSeconds(duration);
            if (duration > 2.5f) {
                duration -= 0.1f;
            }
        }
        
    }

}
