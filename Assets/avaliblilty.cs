using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.RemoteConfig;
public class avaliblilty : MonoBehaviour
{
    public bool inStock; // Set this value to true to apply transparency
    public TMP_Text outofstockTxt;
    public GameObject selection;
    public stickObject stick;

    public struct userAttributes { };
    public struct appAttributes { };

    private void Awake()
    {
        ConfigManager.FetchCompleted += UpdateInStock;
        //Updates the game in real time
        tickUpdate();
    }
    private void Start()
    {
        Image stickPNG = GetComponentInChildren<Image>();
        stickPNG.sprite = stick.stickPng;
        transform.Find("Stick name").GetComponent<TextMeshProUGUI>().text = stick.name;
    }

    private void OnDestroy()
    {
        ConfigManager.FetchCompleted -= UpdateInStock;
    }
    void tickUpdate()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
        Invoke("tickUpdate", 1);
    }
    private void UpdateInStock(ConfigResponse response)
    {
        
        switch (stick.name)
        {
            case "Orange Translucent":
                inStock = ConfigManager.appConfig.GetBool("Orange Translucent In Stock");
                break;
            case "Orange Crystal":
                inStock = ConfigManager.appConfig.GetBool("Orange Crystal In Stock");
                break;
            case "Light Blue Translucent":
                inStock = ConfigManager.appConfig.GetBool("Lightblue Translucent In Stock");
                break;
            case "Light Blue Crystal":
                inStock = ConfigManager.appConfig.GetBool("Lightblue Crystal In Stock");
                break;
            case "Cyan Translucent":
                inStock = ConfigManager.appConfig.GetBool("Cyan Translucent In Stock");
                break;
            case "Cyan Crystal":
                inStock = ConfigManager.appConfig.GetBool("Cyan Crystal In Stock");
                break;
            case "Pink Translucent":
                inStock = ConfigManager.appConfig.GetBool("Pink Translucent In Stock");
                break;
            case "Pink Crystal":
                inStock = ConfigManager.appConfig.GetBool("Pink Crystal In Stock");
                break;
        }
    }
    void Update()
    {
        // You can put your logic here to toggle the bool value based on certain conditions
        // For example, you can use Input.GetKeyDown(KeyCode.Y) to toggle the bool when the Y key is pressed.


        if (!inStock)
        {
            becomeTranslucent(true);
            outofstockTxt.gameObject.SetActive(true);
            selection.SetActive(false);
        }
        else
        {
            becomeTranslucent(false);
            outofstockTxt.gameObject.SetActive(false);
            selection.SetActive(true);
        }
    }

    void becomeTranslucent(bool inStockCheck)
    {
        // Get all Image components
        Image[] images = GetComponentsInChildren<Image>();
        // Get all TextMeshProUGUI components
        TextMeshProUGUI[] textMeshPros = GetComponentsInChildren<TextMeshProUGUI>();

        // Set transparency based on the bool value
        float targetAlpha = inStockCheck ? 0.5f : 1f;

        // Modify Image components
        foreach (Image image in images)
        {
            Color color = image.color;
            color.a = targetAlpha;
            image.color = color;
        }

        // Modify TextMeshProUGUI components
        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            Color color = textMeshPro.color;
            color.a = targetAlpha;
            textMeshPro.color = color;
        }
    }
}
