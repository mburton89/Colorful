using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Collectible
{
    public enum ItemType
    {
        Axe,
        Thing1,
        Thing2,
        Berry1,
        Berry2,
        Berry3 
    }

    public ItemType CurrentItemType;

    private bool _canCollect;

    private void Start()
    {
        _canCollect = true;
    }

    public override void GetCollected()
    {
        if (_canCollect)
        {
            _canCollect = true;
            print("Got Item.");

            if (CurrentItemType == ItemType.Axe)
            {
                Nomad.Instance.axe.SetActive(true);
            }

            if (CurrentItemType == ItemType.Berry1)
            {
                Nomad.Instance.berry1.SetActive(true);
            }

            if (CurrentItemType == ItemType.Berry2)
            {
                Nomad.Instance.berry2.SetActive(true);
            }

            if (CurrentItemType == ItemType.Berry3)
            {
                Nomad.Instance.berry3.SetActive(true);
            }
        }
    }
}
