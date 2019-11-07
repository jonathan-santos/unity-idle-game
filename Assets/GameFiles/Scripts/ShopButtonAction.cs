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
    float posicaoFabrica;

    void Start()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<Text>();

        var factoryAction = factory.GetComponent<FactoryAction>();
        price = factoryAction.price;
        passiveGain = factoryAction.passiveGain;

        button.onClick.AddListener(() => BuyFactory());
        text.text = factory.name + "\n" + factoryAction.price;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            BuyFactory();
            Destroy(collision.gameObject);
        }
    }

    void BuyFactory()
    {
        if (player.score >= price)
        {
            player.score -= price;
            player.passiveScoreGain += passiveGain;

            price = Convert.ToInt32(Math.Abs(price * 1.50));
            text.text = factory.name + "\n" + price;

            var novaFabrica = Instantiate(factory, factoriesArea.transform);
            novaFabrica.transform.Translate(new Vector3(posicaoFabrica, -posicaoFabrica, 0));
            posicaoFabrica -= 1.5f;
        }
    }
}