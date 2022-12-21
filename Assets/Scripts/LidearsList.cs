using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LidearsList : MonoBehaviour
{
    [SerializeField] Text Leaders;
    void Start()
    {
        Save.Lead lead = Save.Instance.LoadLead();
        foreach (var item in lead.leaders)
        {
            Leaders.text += $"{item.playerName} : {item.score}" + '\n' ;
        }
    }
}
