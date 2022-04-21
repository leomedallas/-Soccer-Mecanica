using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Score")]
    public static int pointsA = 0;
    public static int pointsP = 0;
    [SerializeField] TextMeshProUGUI scoreP;
    [SerializeField] TextMeshProUGUI scoreA;

    void Start()
    {
   
    }

    void Update()
    {
        scoreP.text = " " + pointsA;
        scoreA.text = " " + pointsP;

    }
}
