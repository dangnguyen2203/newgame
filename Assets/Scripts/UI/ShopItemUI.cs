using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private List<ButtonInfo> buttonInfos = new List<ButtonInfo>();
    [SerializeField] Text coinsTxt;

    public void Init(List<int> itemIDs)
    {
        for (int i = 0; i < itemIDs.Count; i++)
        {
            // Đảm bảo danh sách không trống
            if (i < buttonInfos.Count)
            {
                buttonInfos[i].Init(itemIDs[i]);
            }
        }
    }

    public void ShowCoin(float coins)
    {
        coinsTxt.text = "Coins: " + coins.ToString();
    }
}
