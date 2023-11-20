using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Cart : MonoBehaviour
{
    bool cartOpened;

    [SerializeField]     
    Animator animator;
    [SerializeField]
    Image BgBG;

    public List<StickAmountEntry> currentInventory;
    // Start is called before the first frame update
    void Start()
    {
        cartOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void checkToggleCart()
    {
        cartOpened = !cartOpened;

        if (cartOpened == true)
        {
            animator.Play("openAnimation");
            BgBG.raycastTarget = true;

        }
        else
        {
            BgBG.raycastTarget = false;
            animator.Play("closeAnimation");
        }
       
    }
}
[System.Serializable]
public class StickAmountEntry
{
    public stickObject stick;
    public int amount;
}
