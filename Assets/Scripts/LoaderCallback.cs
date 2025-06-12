using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool _isFirstApdate = true;

    private void Update()
    {
        if (_isFirstApdate)
        {
            _isFirstApdate = false;
            Loader.LoaderCallback();
        }
    }
}
