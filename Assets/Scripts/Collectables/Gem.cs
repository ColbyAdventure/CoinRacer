using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public float MultipleIncreasePerGem = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpGem");
            CollectableManager.numberOfGems += 1;
            MultipleManager.currentMultiple += MultipleIncreasePerGem;

            Destroy(gameObject);

        }
    }
}
