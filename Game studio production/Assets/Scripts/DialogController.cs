using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
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
    private void Start()
    {
        
        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartDialog()
    {
        _inkStory = new Story(inkFile.storyJson);
        _inkStory.BindExternalFunction("GetItem", (int ID) => {
            inventory.GetItem(ID);
        });
        SetDialog();
    }

    void SetDialog()
    {
        if (_inkStory.canContinue)
        {
            Dialg.text = _inkStory.Continue();
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
 