﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHitterController : MonoBehaviour
{
    private int myNumber;
    private SpriteRenderer NumberSprite;
    public Sprite[] DiceSprites = new Sprite[6];
    public int CurrentDiceSide;

    void Start()
    {
        myNumber = Random.Range(1, 7);
        NumberSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        ChangeNumber();
    }

    void Update()
    {
        
    }

    //DiceHitter Number 변경
    public void ChangeNumber()
    {
        int newNumber = Random.Range(1, 7);

        while (newNumber == myNumber)
        {
            newNumber = Random.Range(1, 7);
        }

        myNumber = newNumber;

        NumberSprite.sprite = DiceSprites[myNumber - 1];
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("DiceSide"))
        {
            CurrentDiceSide = int.Parse(other.name[4].ToString());
        }
        else if (other.tag.Equals("Dice"))
        {
            if (CurrentDiceSide == myNumber)
            {
                Debug.Log("맞음");
            }
            else
            {
                Debug.Log("틀림 / 부딪힌 면 :" + CurrentDiceSide);
            }
        }
    }
}
