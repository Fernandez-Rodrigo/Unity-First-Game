using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum BarType
{
    health,
    mana
}

public class Player_Bar : MonoBehaviour
{
    private Slider slider;

    public BarType type;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();   
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case BarType.health:
                slider.value = Player_Controler.sharedInstance.GetHealth();
                break;
            case BarType.mana:
                slider.value = Player_Controler.sharedInstance.GetMana();
                break;
        }
    }
}
