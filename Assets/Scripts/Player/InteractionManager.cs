using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory    playerInventory;
    [SerializeField] private string             pickMessage;

    private List<Interactive> interactives;
    private static InteractionManager instance;

    public static InteractionManager Instance
    {
        get { return instance; }
    }

    private InteractionManager()
    {
        instance = this;
        interactives = new List<Interactive>();
    }

    public PlayerInventory PlayerInventory
    {
        get { return playerInventory; }
    }

    public string PickMessage
    {
        get { return pickMessage; }
    }

    public void RegisterInteractive(Interactive interactive)
    {
        interactives.Add(interactive);
    }

    void Start()
    {
        ProcessDependencies();
        interactives = null;
    }

    private void ProcessDependencies()
    {
        foreach (Interactive interactive in interactives)
        {
            foreach (InteractiveData requirementData in interactive.InteractiveData.requirements)
            {
                Interactive requirement = FindInteractive(requirementData);
                interactive.AddRequirement(requirement);
                requirement.AddDependent(interactive);
            }
        }
    }

    public Interactive FindInteractive(InteractiveData interactiveData)
    {
        foreach (Interactive interactive in interactives)
            if (interactive.InteractiveData == interactiveData)
                return interactive;

        return null;
    }
}
