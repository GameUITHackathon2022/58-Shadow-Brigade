using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text level;

    public Unit unit;
    // Update is called once per frame
    void Update()
    {
        level.text = "Level " + unit.level;
    }
}
