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
    GameObject convoHistoryUI;
    [SerializeField]
    TextMeshProUGUI TextPrefab;

    public List<string> PastConvo;
    GameObject ConvohistoryUI;
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
        PastConvo.RemoveRange(0,2);
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
            PastConvo.Add(Dialg.text);
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
            Destroy(convoHistoryUI);
            PastConvo.Clear();
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
    public void LoadConvoHistory()
    {
        ConvohistoryUI = Instantiate(convoHistoryUI, transform).gameObject;
        conversationHistory = ConvohistoryUI.transform.GetChild(0).GetChild(0).GetChild(0);
        foreach (string dialogLine in PastConvo)
        {
            TextMeshProUGUI Spawned = Instantiate(TextPrefab, conversationHistory);
            Spawned.text = dialogLine;
        }
    }
    public void DestroyConvoH()
    {

    }
    
}
 