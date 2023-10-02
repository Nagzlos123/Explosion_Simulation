using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestructionReporter : MonoBehaviour
{
    public int activeElements;
    public int maxActiveElements;
    public int activeCrackedElements;
    public float activePercentage = 100f;
    private bool isDo = false;
    [SerializeField] private TextMeshProUGUI numberOfElements;
    [SerializeField] private TextMeshProUGUI numberOfCrackedElements;
    [SerializeField] private TextMeshProUGUI procentOf;

    void Start()
    {

        
    }


    void Update()
    {

   


        FindElements();
        CalculatePercentage();


    }

    void FindElements()
    {
        activeElements = GameObject.FindGameObjectsWithTag("Element").Length;
        activeCrackedElements = GameObject.FindGameObjectsWithTag("Cracked").Length;
        maxActiveElements = activeCrackedElements + activeElements;
        numberOfElements.text = activeElements.ToString();
        numberOfCrackedElements.text = activeCrackedElements.ToString();
        //Debug.Log("Number of activeEnemies" + activeEnemies);

    }

    void CalculatePercentage()
    {
        if (activeCrackedElements == 0)
        {
            activePercentage = 0;
            procentOf.text = activePercentage.ToString();
        }
        else
        {
            activePercentage = ((float) activeCrackedElements / (float) maxActiveElements) * 100;
            var activePercentageRound = System.Math.Round(activePercentage, 2);
            procentOf.text = activePercentageRound.ToString();
        }
        
    }
}
