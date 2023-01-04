using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalMoney : MonoBehaviour
{

    private float money;

    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
    money = 0;
    text = GetComponent<TextMeshProUGUI>();   
    }

    public void updateMoney(){
        ++money;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = money.ToString("0");
    }
}
