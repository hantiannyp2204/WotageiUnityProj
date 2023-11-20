using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class amount : MonoBehaviour
{
    stickObject lightStick;
    [SerializeField]
    Cart inventory;
    public TMP_Text quantity;
    int amountSelected;


    // Start is called before the first frame update
    private void Start()
    {
        lightStick = GetComponentInParent<avaliblilty>().stick;
        amountSelected = 0;
        updateText(amountSelected);
    }
    public void Add()
    {
        amountSelected++;
        updateText(amountSelected);


        // Check if the stick already exists in the list
        int index = inventory.currentInventory.FindIndex(entry => entry.stick == lightStick);

        if (index != -1)
        {
            // Stick already exists, increment the amount
            inventory.currentInventory[index].amount++;
        }
        else
        {
            // Stick doesn't exist, add a new entry
            StickAmountEntry newEntry = new StickAmountEntry { stick = lightStick, amount = 1 };
            inventory.currentInventory.Add(newEntry);
        }
    }
    public void Remove()
    {
        amountSelected--;
        if(amountSelected < 0)
        {
            amountSelected = 0;
        }
        updateText(amountSelected);

        // Check if the stick already exists in the list
        int index = inventory.currentInventory.FindIndex(entry => entry.stick == lightStick);

        if (index != -1)
        {
            // Stick exists, decrement the amount
            inventory.currentInventory[index].amount--;

            // If the amount becomes zero, remove the entry
            if (inventory.currentInventory[index].amount <= 0)
            {
                inventory.currentInventory.RemoveAt(index);
            }
        }
        // If the stick is not in the list, you can handle that case if neede

    }

    void updateText(int newNumber)
    {

        quantity.text = amountSelected.ToString();
    }


    // Function to add a stick to the list

}
