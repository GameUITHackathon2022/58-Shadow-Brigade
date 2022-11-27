using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateChatBox : MonoBehaviour
{
    // Start is called before the first frame update
    public Unit a;

    public TMP_Text moneySkillText;

    string b;
    private void Start()
    {
        b = moneySkillText.text;
    }
    // Update is called once per frame
    void Update()
    {
        modifyChatBox();
    }

    void modifyChatBox()
    {
        moneySkillText.text = b + a.level * 30 + "$";
    }
}
