using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideText : MonoBehaviour
{
    public GameObject[] plabetstext;
    public GameObject[] planets;
    // Start is called before the first frame update
    private int randomNumber;
    public GameObject rocket;

    public void TextHide()
    {
        for (int i = 0; i <= 8; i++)
        {
            plabetstext[i].SetActive(false);
        }
    }

    public void RandomPlanetPoss()
    {
        //PlayerPrefs.SetInt("randomNumber" , Random.Range(1, 8));
        randomNumber = Random.Range(1, 8);
        Debug.Log(PlayerPrefs.GetInt("randomNumber"));
        rocket.SetActive(true);

    

        //Instantiate(rocket, planets[randomNumber].transform.position, planets[randomNumber].transform.rotation);
        rocket.transform.position = Vector3.Lerp(rocket.transform.position, planets[randomNumber].transform.position,1);


        //Vector3 pos = rocket.transform.position;

        //pos.y = planets[randomNumber].transform.position.y+1;
        //rocket.transform.position = pos;

        Debug.Log(randomNumber + " Rocket SPawn");

    }

}
