using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseInventory : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;

    public void OpenOrClose(GameObject pannel)
    {
        if (Inventory.activeSelf) Inventory.SetActive(false);
        else Inventory.SetActive(true);
    }
}