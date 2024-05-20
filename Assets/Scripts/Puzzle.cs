using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;

    public GameObject keyObject;
    public GameObject panel;
    //public Text resultText;

    private readonly string expectedCode1 = "C";
    private readonly string expectedCode2 = "G";
    private readonly string expectedCode3 = "F";
    private readonly string expectedCode4 = "D";

    public void CheckCode()
    {
        string input1 = inputField1.text.ToUpper();
        string input2 = inputField2.text.ToUpper();
        string input3 = inputField3.text.ToUpper();
        string input4 = inputField4.text.ToUpper();

        if (input1 == expectedCode1 && input2 == expectedCode2 &&
            input3 == expectedCode3 && input4 == expectedCode4)
        {
            Debug.Log("Correct code entered!");
            keyObject.SetActive(true);
            panel.SetActive(false);

        }
        else
        {
            Debug.Log("Wrong code entered.");
        }
    }
}
