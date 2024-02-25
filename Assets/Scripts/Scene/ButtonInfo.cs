using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    private int itemID;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Text quatityTxt;
    [SerializeField] Button btn;


    public void Init(int id)
    {
        itemID = id;
        priceTxt.text = "Price: $" + ShopManagerScript.instance.GetPrice(itemID);
        quatityTxt.text = ShopManagerScript.instance.shopItems[3, itemID].ToString();
        btn.onClick.AddListener(UpdateItem);
    }

    private void UpdateItem(){
        ShopManagerScript.instance.UpdateItem(this);
    }

    public void SetQuatity(int value)
    {
        quatityTxt.text = value.ToString();
    }

    public int ItemID => itemID;
}

