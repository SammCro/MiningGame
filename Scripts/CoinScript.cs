using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float ValueOfCoin;
    public GameObject TextMeshPro;


    public GameObject Claw;
    public GameObject GameManager;
    public GameObject Aim;


    private float  initalValue;
    void Start()
    {

        initalValue = ValueOfCoin;
    }

    public void SetInitial()
    {
        ValueOfCoin = initalValue;
    }

    public void SetValueOfCoin(float value)
    {
        ValueOfCoin *= value;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Claw"))
        {
            col.gameObject.GetComponentInParent<HookMovement>().SetMoveDownFalse();
            gameObject.transform.SetParent(Claw.transform);
        }
        else if (col.CompareTag("LimitExecute"))
        {
            // increase progress
            float scoreŻnitital = Int32.Parse(TextMeshPro.GetComponent<TextMeshProUGUI>().text.ToString());
            scoreŻnitital += ValueOfCoin;

            TextMeshPro.GetComponent<TextMeshProUGUI>().text = scoreŻnitital.ToString();
            if (scoreŻnitital >= int.Parse(Aim.GetComponent<TextMeshProUGUI>().text.ToString()))
            {
                GameManager.GetComponent<GameManager>().LevelPassed();
            }

            Destroy(gameObject);
        }

    }
}
