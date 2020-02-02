using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public bool sim;
    public string[] sentences;
    public string[] datingsimprompts;
    public string[] answerchoices;
    public int[] correctanswers;
    public string[] correctreply;
    private int index;
    public float typingspeed;
    private AudioSource source;

    int answer;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;
    public GameObject continueButton;
    public GameObject failure;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Type());

        choice1.SetActive(false);
        choice2.SetActive(false);
        choice3.SetActive(false);
        failure.SetActive(false);

    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
        
    }

    IEnumerator Typevisual(string [] arr,int index1)
    {
        foreach (char letter in arr[index1].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }

    }



    public void buttonname()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    public void NextSentence()
    {
        source.Play();
        continueButton.SetActive(false);
        if (index <sentences.Length-1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);

            if(sim==true)
            visualnovel();
        }
    }

    public void visualnovel()
    {
        StartCoroutine(Typevisual(datingsimprompts, 0));
        choice1.SetActive(true);
        choice2.SetActive(true);
        choice3.SetActive(true);
        
        int answer = 0;
        //while (answer == 0)
        //Debug.Log("please choose a choice");

        /*if(answer !=correctanswers[0])
        {
            failure.SetActive(true);
        }
        else
        {
            StartCoroutine(Typevisual(correctreply, 0));
        }
        */
        //StartCoroutine(WaitForAnswer());


    }

    public void buttonchoice()
    {
        answer = int.Parse(EventSystem.current.currentSelectedGameObject.name);
    }
 
}
