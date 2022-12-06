using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuStateHandler : MonoBehaviour
{

    [SerializeField] List<GameObject> menus = new List<GameObject>();

    public void hrefMenu(string menu)
    {

        foreach (var index in menus)
        {

            if (index.ToString().StartsWith(menu))
            {

                index.SetActive(true);
            }

            if (!index.ToString().StartsWith(menu))
            {

                index.SetActive(false);
            }
        }
    }

    public void backButton()
    {
        hrefMenu("Main Menu");
    }
}
