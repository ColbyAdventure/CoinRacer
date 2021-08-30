using UnityEngine;

public class Coin : MonoBehaviour
{
    public float MultipleIncreasePerCoin = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            CollectableManager.numberOfCoins += 1;
            MultipleManager.currentMultiple += MultipleIncreasePerCoin;

            Destroy(gameObject);

        }
    }
}
//Problem 1: When you change scenes, the buttons on the canvas lose there reference to the audiomanager, because the one from the reference was destroyed when the one from the first scene "DontDestroyOnLoad" into the scene
//Problem 2: Once the Starting Panel is destroyed the first time, all the prefab clones lose the animation EDIT: Apparently Things like the Gem and Coins stop rotating too?? EDIT2: Does That mean i forgot to put "Time.timeScale = 1;" before loading the other scenes?? EDIT3: When adding that to all the buttons, when you game over, and leave to main menu, the first time the title is stopped, but go to the info screen and back, works like a charm EDIT4: Nope, adding "Time.timeScale = 1;" To a start funtion fixes it up nice -=Ticket Closed=-