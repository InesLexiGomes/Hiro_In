using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory    playerInventory;
    [SerializeField] private string             pickMessage;

    private List<Interactive> interactives;
    private static InteractionManager instance;

    private InteractionManager()
    {
        instance = this;
        interactives = new List<Interactive>();
    }

    private void Start()
    {
        ProcessDependencies();
        interactives = null;
    }

    public PlayerInventory Inventory
    { get { return playerInventory; } }

    public string PickMessage
    { get { return pickMessage; } }

    public void RegisterInteractive(Interactive interactive)
    { interactives.Add(interactive); }

    private void ProcessDependencies()
    {
        //foreach (Interactive interactive in interactives)
        {
            //foreach (InteractiveData requirementData in interactive.interactiveData.requirements)
            {
                //Interactive requirement = FindInteractive(requirementData);
               //interactive.AddRequirement(requirement);
                //requirement.AddDependent(interactive);
            }
        }
    }

    public static InteractionManager Instance
    { get { return instance; } }

    /*public void RegisterInteractive(Interactive interactive)
    { interactives.add(interactive); }

    public Interactive FindInteractive(InteractiveData interactiveData)
    {
        foreach(Interactive)
    }*/
}
