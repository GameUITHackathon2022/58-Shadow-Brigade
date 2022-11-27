using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseItem2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int countItem = 10;

    public TMP_Text moneyText;

    public Player a;

    public Unit g;

    public TMP_Text textCountItem;

    private void Start()
    {
        countItem = a.levelskill1;
        textCountItem.text = "" + countItem;
    }
    private void Update()
    {
        BuyItem();
    }

    public void BuyItem()
    {
        countItem = a.levelskill1;
        textCountItem.text = "" + countItem;
    }
}
