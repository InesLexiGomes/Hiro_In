using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private InteractiveData _interactiveData;

    public bool isOn;

    //private List<Interactive> 

    public string inventoryName
    { get { return _interactiveData.inventoryName; } }


}
