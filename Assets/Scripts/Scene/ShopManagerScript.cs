using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopManagerScript : MonoBehaviour
{
   
    public static ShopManagerScript instance;

    private void Awake()
    {
        instance = this; 
    }

    [SerializeField] private ShopItemUI shopUI;
    [SerializeField] private EventSystem eventSystem;
    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text coinsTxt;



    void Start()
    {
        coinsTxt.text = "Coins: " + coins.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        //Quatity
        shopItems[3, 1] = 0;
        shopItems[3, 2] = 0;
        shopItems[3, 3] = 0;
        shopItems[3, 4] = 0;

        shopUI.Init(new List<int> { 1, 2, 3, 4 });
    }

    public void Buy()
    {
        //if (eventSystem != null && eventSystem.currentSelectedGameObject != null) 
        //{
        //    GameObject buttonRef = eventSystem.currentSelectedGameObject;
        //    ButtonInfo buttonInfo = buttonRef.GetComponent<ButtonInfo>();

        //    int itemID = buttonInfo.ItemID;
        //    int itemCost = shopItems[2, itemID];

        //    // Kiểm tra số tiền đủ để mua hay không
        //    if (coins >= itemCost)
        //    {
        //        coins -= itemCost;
        //        shopItems[3, itemID]++;

        //        // Cập nhật giao diện
        //        //coinsTxt.text = "Coins: " + coins.ToString();
        //       // buttonInfo.quatityTxt.text = shopItems[3, itemID].ToString();
        //    }
        //}

        /*GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().itemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID]++;
            coinsTxt.text = "Coins: " + coins.ToString();
            ButtonRef.GetComponent<ButtonInfo>().quatityTxt.text 
                = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().itemID].ToString();
        }*/
    }

    public void UpdateItem(ButtonInfo btn)
    {
        int currentID = btn.ItemID;
        int itemCost = shopItems[2, currentID];

        // Kiểm tra số tiền đủ để mua hay không
        if (coins >= itemCost)
        {
            coins -= itemCost;
            shopItems[3, currentID]++;

            // Cập nhật giao diện

            shopUI.ShowCoin(coins);
            btn.SetQuatity(shopItems[3, currentID]);
        }
    }

    public int GetPrice(int itemID)
    {
        return shopItems[2, itemID];
    }
}
