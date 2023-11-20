using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Form : MonoBehaviour
{
    [SerializeField]
    private TMP_Text name;
    [SerializeField]
    private TMP_Text price;
    private Cart inventory;
    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfn9kavml5dDv42gNcB2b9PWyZGyDL08o2mwP6cBCqNVaAyTQ/formResponse";
    void Start()
    {
        inventory = GetComponent<Cart>();
    }
    public void Send()
    {

        //loop thru to check inventory
        //parameters takes in what to send
        StartCoroutine(Post(inventory.currentInventory.Count));

    }

    IEnumerator Post(int amountOfStickType)
    {
        WWWForm form = new WWWForm();
        for (int x = 0; x < amountOfStickType; x++)
        {
            form.AddField(inventory.currentInventory[x].stick.stringAddress, inventory.currentInventory[x].amount.ToString());
        }

        //add the total price
        form.AddField("entry.1313242092", price.text.ToString()); 
        //add the name
        form.AddField("entry.519796685", name.text);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }

}
