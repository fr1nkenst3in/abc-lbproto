using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    /// Game objects
    public GameObject canvas;
    GameObject fadein;
    GameObject blake;
    GameObject fred;
    GameObject dialoguePanel;
    GameObject choicePanel;
    GameObject namePanel;
    /// Dialogue Array
    public dialogues[] sceneDialogues;
    /// Bool to check if player made a choice
    public bool choiceMade;


    //Dialogues Class
    [System.Serializable]
    public class dialogues
    {
        public string speaker;
        public string dialogue;
    }
    
    // Initialization that assigns all needed game objects to variables, calls the
    // fade in function and dialogue script
    void Start()
    {
        if (canvas != null)
        {
            fadein = canvas.gameObject.transform.Find("FadeIn").transform.gameObject;
            blake = canvas.gameObject.transform.Find("Blake").transform.gameObject;
            fred = canvas.gameObject.transform.Find("Fred").transform.gameObject;
            dialoguePanel = canvas.gameObject.transform.Find("DialoguePanel").transform.gameObject;
            choicePanel = canvas.gameObject.transform.Find("ChoicePanel").transform.gameObject;
            namePanel = canvas.gameObject.transform.Find("NamePanel").transform.gameObject;
            
            fadeFromWhite();
            StartCoroutine(sceneOne());
        }
    }
    
    // Fade In Effect
    void fadeFromWhite()
    {
        fadein.GetComponent<Image>().CrossFadeColor(new Color(0, 0, 0, 0), 2, true, true);
    }

    // Fade Out Effect
    void fadeToWhite()
    {
        fadein.GetComponent<Image>().CrossFadeColor(new Color(255, 255, 255, 255), 2, true, true);
    }

    // Bool reset function whenever choices are made
    public void ToggleChoice()
    {
        choiceMade = !choiceMade;
    }

    // Coroutine for the entire scene
    IEnumerator sceneOne()
    {
        yield return new WaitForSeconds(2);
        // Activate Blake Character
        blake.gameObject.GetComponent<Image>().CrossFadeColor(new Color(255, 255, 255, 255), 1,true,true);
        yield return new WaitForSeconds(1);
        // Activate Dialogue Panel
        dialoguePanel.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(2);
        
        // Dialogue 1
        // Retrieves dialogue strings from the array and applies typewriter effect
        string dia1 = sceneDialogues[0].speaker + ": " + sceneDialogues[0].dialogue;
        string typeString = "";
        foreach (char i in dia1)
        {
            typeString = typeString + i;
            dialoguePanel.transform.GetChild(0).GetComponent<Text>().text = typeString;
            yield return new WaitForSeconds(0.02f);
        }

        // Dialogue 2
        // Changes sprite to relevant expression for the dialogue
        yield return new WaitForSeconds(4);
        blake.GetComponent<Image>().sprite = Resources.Load<Sprite>("blake2");
        dia1 = sceneDialogues[2].speaker + ": " + sceneDialogues[2].dialogue;
        typeString = "";
        foreach (char i in dia1)
        {
            typeString = typeString + i;
            dialoguePanel.transform.GetChild(0).GetComponent<Text>().text = typeString;
            yield return new WaitForSeconds(0.02f);
        }

        yield return new WaitForSeconds(1);
        // Display choices panel which the player can choose from
        choicePanel.SetActive(true);
        // Doesn't proceed till the choice is made
        yield return new WaitUntil(() => choiceMade == true);
        choiceMade = false;
        choicePanel.SetActive(false);
        
        // Activate Fred Character
        fred.gameObject.SetActive(true);

        // Dialogue 3 - Similar to previous dialogue sections
        yield return new WaitForSeconds(2);
        fred.GetComponent<Image>().sprite = Resources.Load<Sprite>("fred3");
        dia1 = sceneDialogues[3].speaker + ": " + sceneDialogues[3].dialogue;
        typeString = "";
        foreach (char i in dia1)
        {
            typeString = typeString + i;
            dialoguePanel.transform.GetChild(0).GetComponent<Text>().text = typeString;
            yield return new WaitForSeconds(0.02f);
        }

        // Dialogue 4  - Similar to previous dialogue sections
        yield return new WaitForSeconds(2);
        blake.GetComponent<Image>().sprite = Resources.Load<Sprite>("blake3");
        dia1 = sceneDialogues[4].speaker + ": " + sceneDialogues[4].dialogue;
        typeString = "";
        foreach (char i in dia1)
        {
            typeString = typeString + i;
            dialoguePanel.transform.GetChild(0).GetComponent<Text>().text = typeString;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2);
        fred.GetComponent<Image>().sprite = Resources.Load<Sprite>("fred1");
        blake.SetActive(false);

        // Dialogue 5  - Similar to previous dialogue sections
        yield return new WaitForSeconds(2);
        fred.GetComponent<Image>().sprite = Resources.Load<Sprite>("fred2");
        dia1 = sceneDialogues[5].speaker + ": " + sceneDialogues[5].dialogue;
        typeString = "";
        foreach (char i in dia1)
        {
            typeString = typeString + i;
            dialoguePanel.transform.GetChild(0).GetComponent<Text>().text = typeString;
            yield return new WaitForSeconds(0.02f);
        }
        // Activates input text panel with a button to confirm the player name
        namePanel.SetActive(true);
        // Choice
        yield return new WaitUntil(() => choiceMade == true);

        // Dialogue 6  - Similar to previous dialogue sections
        yield return new WaitForSeconds(2);
        fred.GetComponent<Image>().sprite = Resources.Load<Sprite>("fred1");
        namePanel.SetActive(false);
        dia1 = sceneDialogues[6].speaker + namePanel.transform.GetChild(0).GetChild(2).GetComponent<Text>().text + sceneDialogues[6].dialogue;
        typeString = "";
        foreach (char i in dia1)
        {
            typeString = typeString + i;
            dialoguePanel.transform.GetChild(0).GetComponent<Text>().text = typeString;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2);

        // Fades to white at the end of scene
        fadeToWhite();
    }


}
