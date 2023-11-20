using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;

public class cartInventory : MonoBehaviour
{
    [SerializeField]
    private Cart cart;
    [SerializeField]
    private GameObject cartItem;
    private GameObject cartPointer;
    [SerializeField]
    private Transform scrollArea;
    [SerializeField]
    TMP_Text priceTxt;
    [SerializeField]
    TMP_Text shippingStatus;
    public void UpdateCart()
    {
        float totalPrice = 0;
        // Iterate through each child of the parent GameObject
        foreach (Transform child in scrollArea)
        {
            // Destroy the child GameObject
            Destroy(child.gameObject);
        }

        //now new items
        for (int i = 0; i < cart.currentInventory.Count; i++)
        {
            cartPointer = Instantiate(cartItem, scrollArea);
            cartPointer.transform.Find("StickPng").GetComponent<Image>().sprite = cart.currentInventory[i].stick.stickPng;
            cartPointer.transform.Find("Stick name").GetComponent<TextMeshProUGUI>().text = cart.currentInventory[i].stick.name;
            cartPointer.transform.Find("Amount").GetComponent<TextMeshProUGUI>().text = cart.currentInventory[i].amount.ToString();
            totalPrice += cart.currentInventory[i].stick.price * cart.currentInventory[i].amount;
        }
        //check if price can get free shipping
        //update the price
        if (totalPrice <= 38 && totalPrice != 0)
        {
            shippingStatus.color = Color.white;
            shippingStatus.text = (38 - totalPrice).ToString() + " more SGD for free shipping";
            //adds shipping
            totalPrice += 3.5f;
            priceTxt.text = totalPrice.ToString() + " SGD";
            
        }
        else
        {
            shippingStatus.color= Color.green;
            shippingStatus.text = "Free shipping";
            priceTxt.text = totalPrice.ToString() + " SGD";
        }


    }

}
