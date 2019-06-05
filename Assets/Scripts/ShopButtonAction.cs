using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonAction : MonoBehaviour
{
    public PlayerAction player;
    public Button button;
    public Text text;
    public GameObject factory;
    public GameObject factoriesArea;
    int price;
    int passiveGain;

	void Start ()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();

        var factoryAction = factory.GetComponent<FactoryAction>();
        price = factoryAction.price;
        passiveGain = factoryAction.passiveGain;

        button.onClick.AddListener(() => BuyFactory());
        text.text = factory.name + "\n" + factoryAction.price;
    }

    void BuyFactory()
    {
        if (player.score >= price)
        {
            player.score -= price;
            player.passiveScoreGain += passiveGain;

            price = Convert.ToInt32(Math.Abs(price * 1.50));
            text.text = factory.name + "\n" + price;

            Instantiate(factory, factoriesArea.transform);
        }
    }
}
