using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckPlanet : MonoBehaviour
{
    private int check=0;
    //public Animator anim;
    public GameObject[] planetsName;
    public GameObject planet;
    public GameObject[] planetsButtons;
    private string namePlanet;
    private string ClicketButtonname;
    public GameObject PlanetsNamesPanel;
    public GameObject ZuWechem_3Text;
    public GameObject RightButtonText;
    public GameObject TryAgainText;
    public GameObject TryAgianBotton;







    public void OnTriggerEnter(Collider other)
    {
        
        if (other.tag== "Mercury")
        {
            PlayerPrefs.SetInt("check",0);
            check = 0;
           // Debug.Log("Check " + check);
            namePlanet = "mercury";
            planetsName[0].SetActive(true);
            Debug.Log("Mercury");
            straightPos();

        }
        else if (other.tag == "Venus")
        {
            PlayerPrefs.SetInt("check", 1);
            check = 1;
           // Debug.Log("Check " +check);
            namePlanet = "venus";
            planetsName[1].SetActive(true);
            Debug.Log("Venus");
            straightPos();

        }
        else if (other.tag == "Earth")
        {
            PlayerPrefs.SetInt("check", 2);
            check = 2;
           // Debug.Log("Check " + check);
            namePlanet = "earth";
            planetsName[2].SetActive(true);
            Debug.Log("Earth");
            straightPos();

        }
        else if (other.tag == "Mars")
        {
            PlayerPrefs.SetInt("check", 3);
            check = 3;
            //Debug.Log("Check " + check);
            namePlanet = "mars";
            planetsName[3].SetActive(true);
            Debug.Log("Mars");
            straightPos();

        }
        else if (other.tag == "Jupiter")
        {
            PlayerPrefs.SetInt("check", 4);
            check = 4;
            //Debug.Log("Check " + check);
            namePlanet = "jupiture";
            planetsName[4].SetActive(true);
            Debug.Log("Jupiter");
            straightPos();

        }
        else if (other.tag == "Saturn")
        {
            PlayerPrefs.SetInt("check", 5);
            check = 5;
            //Debug.Log("Check " + check);
            namePlanet = "saturn";
            planetsName[5].SetActive(true);
            Debug.Log("Saturn");
            straightPos();

        }
        else if (other.tag == "Uranus")
        {
            PlayerPrefs.SetInt("check", 6);
            check = 6;
            //Debug.Log("Check " + check);
            namePlanet = "uranus";
            planetsName[6].SetActive(true);
            Debug.Log("Uranus");
            straightPos();


        }
        else if (other.tag == "Neptune")
        {
            PlayerPrefs.SetInt("check", 7);
            check = 7;
           // Debug.Log("Check " + check);
            namePlanet = "naptune";
            planetsName[7].SetActive(true);
            Debug.Log("Neptune");
            straightPos();


        }
    }

    public void findPlanet(int presedIndex)
    {
        ClicketButtonname = EventSystem.current.currentSelectedGameObject.name;
        
        Debug.Log(" Pressed button"+ ClicketButtonname);
        Debug.Log("Check " + PlayerPrefs.GetInt("check"));
        if (ClicketButtonname == namePlanet || presedIndex== PlayerPrefs.GetInt("check"))
        {
            Debug.Log("Right Button Pressed");
            PlanetsNamesPanel.SetActive(false);
            RightButtonText.SetActive(true);
            StartCoroutine(wiatSec(3));
        }
        else
        {
            TryAgainText.SetActive(true);
            StartCoroutine(WiatForWrongText());
           
        }
       
    }

    IEnumerator WiatForWrongText()
    {
        
        yield return new WaitForSeconds(3);
        TryAgainText.SetActive(false);
       

    }

    IEnumerator wiatSec(int sec)
    {
        yield return  new WaitForSeconds(sec);
        RightButtonText.SetActive(false);
        TryAgianBotton.SetActive(true);
    }

    public void straightPos()
    {
        //StartCoroutine(wiatSec(5));
        moveTowarsPlanets.instance.check = false;
        planet.transform.eulerAngles = new Vector3(0, -90, 90);
        planet.transform.position = moveTowarsPlanets.instance.planetsName[moveTowarsPlanets.instance.randomNumber].transform.position;
        
    }

     IEnumerator waitForButtonName()
    {
        yield return new WaitForSeconds(5);
        ZuWechem_3Text.SetActive(false);
        PlanetsNamesPanel.SetActive(true);
    }
    public void ShowPlanetsNameButtons()

    {
        StartCoroutine(waitForButtonName());
        
    }

}
