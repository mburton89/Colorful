using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Collectible
{
    public enum ItemType
    {
        Axe,
        Thing1,
        Thing2
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
        }
    }
}
