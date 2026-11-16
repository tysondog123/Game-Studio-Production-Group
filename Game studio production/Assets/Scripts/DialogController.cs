using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class DialogController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Name;
    [SerializeField]
    GameController gameController;
    [SerializeField]
    TextAsset inkAsset;
    public InkFile inkFile;
    Story _inkStory;
    [SerializeField]
    TextMeshProUGUI[] Options = new TextMeshProUGUI[3];
    [SerializeField]
    TextMeshProUGUI Dialg;
    bool canContinue = false;
    [SerializeField]
    Inventory inventory;
    NPC NPC;
    [SerializeField]
    GameObject[] optionButtons;
    [SerializeField]
    Transform conversationHistory;
    [SerializeField]
    TextMeshProUGUI TextPrefab;
  
    public void SetNPC(NPC _NPC)
    {
        NPC = _NPC;
        inkFile = NPC.GetInkFile();

        Name.text = NPC.NPCName;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartDialog()
    {
        _inkStory = new Story(inkFile.storyJson);
        _inkStory.BindExternalFunction("Event", (int ID) => {
            gameController.loopManager.ActivateEvent(ID);
        });
        _inkStory.BindExternalFunction("CheckLocked", (int ID) => {
            CheckEventStatus(ID);
        });
        _inkStory.BindExternalFunction("UseAction", () => {
            gameController.loopManager.RemoveAction();
        });
        _inkStory.BindExternalFunction("Save", (int Item, int Value) => {
            NPC.Save(Item,Value);
        });
        _inkStory.variablesState["TimesSpokenTo"] = NPC.GetTimesSpokenTo();
        _inkStory.variablesState["PartsCompleted"] = NPC.GetPartsCompleted();
        SetDialog();
    }
    void CheckEventStatus(int UID)
    {
        if (gameController.loopManager.CheckEventStatus(UID))
        {
            _inkStory.variablesState["Locked"] = 1;
            Debug.Log(_inkStory.variablesState["Locked"]);
            return;
        }
        _inkStory.variablesState["Locked"] = 0;
    }

    void SetDialog()
    {
        if (_inkStory.canContinue)
        {
            for(int i =0;i< optionButtons.Length; i++)
            {
                optionButtons[i].SetActive(false);
            }
            Dialg.text = _inkStory.Continue();
            var Text = new UnityEngine.UIElements.Toggle() { text =Dialg.text};

            TextMeshProUGUI Spawned= Instantiate(TextPrefab, conversationHistory);
            Spawned.text = _inkStory.currentText;
        }

        if (_inkStory.currentChoices.Count > 0)
        {
            showChoices();
        }else if (_inkStory.canContinue)
        {
            canContinue = true;
        }
        else
        {
            conversationHistory.gameObject.SetActive(false);
            while (conversationHistory.childCount >0)
            {
                DestroyImmediate(conversationHistory.GetChild(0).gameObject);
            }
            gameController.CloseDialog();
        }
    }
    public void Next()
    {
        SetDialog();
    }
    void showChoices()
    {
        for(int i =0;i< _inkStory.currentChoices.Count; i++)
        {
            Choice choice = _inkStory.currentChoices[i];
            Options[i].text = choice.text;
            optionButtons[i].SetActive(true);
        }
    }
    public void SelectOption(int Choice)
    {
        if(_inkStory.currentChoices.Count > 0)
        {
            _inkStory.ChooseChoiceIndex(Choice);
            SetDialog();
        }
    }
    
}
 