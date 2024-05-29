using TMPro;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public TMP_InputField inputField1; // Reference to the first input field for the puzzle code
    public TMP_InputField inputField2; // Reference to the second input field for the puzzle code
    public TMP_InputField inputField3; // Reference to the third input field for the puzzle code
    public TMP_InputField inputField4; // Reference to the fourth input field for the puzzle code

    public GameObject keyObject; // GameObject representing the key that appears on correct code entry
    public GameObject panel; // Panel containing the puzzle inputs

    private readonly string expectedCode1 = "C"; // Expected value for inputField1
    private readonly string expectedCode2 = "G"; // Expected value for inputField2
    private readonly string expectedCode3 = "F"; // Expected value for inputField3
    private readonly string expectedCode4 = "D"; // Expected value for inputField4

    public TextMeshProUGUI errorMessage; // Text element to display error or success messages

    // Method to check if the entered code is correct
    public void CheckCode()
    {
        // Get the text entered in each input field and convert to uppercase for case-insensitive comparison
        string input1 = inputField1.text.ToUpper();
        string input2 = inputField2.text.ToUpper();
        string input3 = inputField3.text.ToUpper();
        string input4 = inputField4.text.ToUpper();

        // Check if all input fields match the expected codes
        if (input1 == expectedCode1 && input2 == expectedCode2 &&
            input3 == expectedCode3 && input4 == expectedCode4)
        {
            Debug.Log("Correct chords entered!");
            errorMessage.text = "Correct chords entered!"; // Display success message
            keyObject.SetActive(true); // Activate the key object
            panel.SetActive(false); // Deactivate the puzzle panel
        }
        else
        {
            Debug.Log("Wrong chords entered.");
            errorMessage.text = "Wrong chords entered. Try Again!"; // Display error message
        }
    }
}
