using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCardSetting : MonoBehaviour
{
    [Header("Asset")]
    public GameObject blackCardCollection;

    private BlackCardCollection _BlackCardCollection;
    private List<GameObject> cardCollectionList;
    private StageManager _StageManager;

    private Vector3 cardSetPosition;
    private const int totalCardAmount = 52;


    private void Awake()
    {
        _BlackCardCollection = blackCardCollection.GetComponent<BlackCardCollection>();
        cardCollectionList = _BlackCardCollection.collection;
        _StageManager = gameObject.GetComponent<StageManager>();
        cardSetPosition = new Vector3(0, 0.51f, 0f);
    }

    private void Start()
    {
        SetCardsOnMap();
    }

    private void SetCardsOnMap()
    {
        List<int> randomCards = GetRandomCardPairs();
        int usingCardNum = _StageManager.vertCardNum * _StageManager.horzCardNum;

        for (int i = 0; i < usingCardNum; i++)
        {
            int randomCardNum = Random.Range(0, randomCards.Count);
            GameObject card = cardCollectionList[randomCards[randomCardNum]];
            
            Instantiate(card, cardSetPosition, card.transform.rotation);
            randomCards.RemoveAt(randomCardNum);

            if ((i + 1) % _StageManager.horzCardNum == 0)
            {
                cardSetPosition.x = 0;
                cardSetPosition.z += card.transform.localScale.z;
            }
            else
            {
                float fixedZ = 0.7f;
                cardSetPosition.x += card.transform.localScale.x * fixedZ;
            }
        }
    }

    private List<int> GetRandomCardPairs()
    {
        int usingCardNum = _StageManager.vertCardNum * _StageManager.horzCardNum / 2;
        int minCardRange = 0;
        int maxCardRange = totalCardAmount;
        int randomNum = Random.Range(minCardRange, maxCardRange);

        List<int> selectedCards = new List<int>();

        for (int i = 0; i < usingCardNum;)
        {
            if (selectedCards.Contains(randomNum))
            {
                randomNum = Random.Range(minCardRange, maxCardRange);
            }
            else
            {
                selectedCards.Add(randomNum);
                selectedCards.Add(randomNum);
                i++;
            }
        }

        return selectedCards;
    }
}
