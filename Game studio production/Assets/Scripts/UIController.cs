using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI[] tmpText;
    [SerializeField]
    PlayerControls player;
    Inventory inventory;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory = player.GetComponent<Inventory>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < tmpText.Length; i++)
        {
            GameObject _item = inventory.GetItem(i);
            if (_item != null)
            {
                tmpText[i].text = _item.name;
            }
        }
    }
    public void ItemSelect(int index)
    {
        player.HoldObject(index);
    }
}
