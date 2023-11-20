using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class name : MonoBehaviour
{
    [SerializeField]
    TMP_Text userName;
    [SerializeField]
    Animator animator;
    [SerializeField]
    Image BgBG;
    [SerializeField]
    TMP_InputField newName;
    // Start is called before the first frame update
    void Start()
    {
        UpdateNameRequest();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateName()
    {
        if(newName.text != "")
        {
            userName.text = newName.text.ToString();
            animator.Play("closeNameChange");
            BgBG.raycastTarget = false;
        }

    }
    public void UpdateNameRequest()
    {
        BgBG.raycastTarget = true;
        animator.Play("openNameChange");
    }
}
