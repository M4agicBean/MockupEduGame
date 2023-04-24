using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckTracker : MonoBehaviour
{

    //Track cards the player has in their collection
    public List<SO_Card> collectedCards;

    //Track the artifacts the player has in their collection
    public List<SO_Artifact> collectedArtifacts;

    // Track collected potions (hard limit?)
    public List<SO_Potion> collectedPotions;

    // The kind of card that is given to the player once they run out of cards
    public SO_Card burnedCard;

    //Singleton
    public static DeckTracker Instance { get; private set; }

    private void Awake()
    {
        // start of singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        // end of singleton pattern
    }



    public void buy(SO_Card card) {
        collectedCards.Add(card);
    }

    
    public void buy(SO_Potion potion) {
        collectedPotions.Add(potion);
    }

    public void removeFromDeck(SO_Card card) {
        collectedCards.Remove(card);
    }

    public void removePotionAt(int index)
    {
        collectedPotions[index] = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
