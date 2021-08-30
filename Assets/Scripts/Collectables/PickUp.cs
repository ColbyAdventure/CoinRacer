using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float MultipleIncreasePerItem; //10 For Gem, 0.1 For Coin

    public string SoundEffectYoudLikeToPlay; //PickUpGem or PickUpCoin

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("SoundEffectYoudLikeToPlay");
            if (transform.tag == "Gem")
            {
                CollectableManager.numberOfGems += 1;
            }
            else
            {
                CollectableManager.numberOfCoins += 1;
            }

            MultipleManager.currentMultiple += MultipleIncreasePerItem;

            Destroy(gameObject);

        }
    }
}
