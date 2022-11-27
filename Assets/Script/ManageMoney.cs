using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text moneyText;

    public Player a;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(a.money >=0 ) moneyText.text = "" + a.money;
    }
}
