using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private InteractiveData interactiveData;

    private InteractionManager  interactionManager;
    private PlayerInventory     playerInventory;
    private List<Interactive>   requirements;
    private List<Interactive>   dependents;
    private Animator            animator;
    private bool                requirementsMet;
    private int                 interactionCount;

    public bool isOn;

    public InteractiveData InteractiveData
    {
        get { return interactiveData; }
    }

    public string inventoryName
    {
        get { return interactiveData.inventoryName; }
    }

    public Sprite inventoryIcon
    {
        get { return interactiveData.inventoryIcon; }
    }

    private bool IsType(InteractiveData.Type type)
    {
        return interactiveData.type == type;
    }

    void Awake()
    {
        interactionManager = InteractionManager.Instance;
        playerInventory = interactionManager.PlayerInventory;
        requirements = new List<Interactive>();
        dependents = new List<Interactive>();
        animator = GetComponent<Animator>();
        requirementsMet = interactiveData.requirements.Length == 0;
        interactionCount = 0;
        isOn = interactiveData.startsOn;

        interactionManager.RegisterInteractive(this);
    }

    public void AddRequirement(Interactive requirement)
    {
        requirements.Add(requirement);
    }

    public void AddDependent(Interactive dependent)
    {
        dependents.Add(dependent);
    }

    public string GetInteractionMessage()
    {
        if (IsType(InteractiveData.Type.Pickable) && !playerInventory.Contains(this) && requirementsMet)
            return interactionManager.PickMessage.Replace("$name", interactiveData.inventoryName);
        else if (!requirementsMet)
        {
            if (PlayerHasRequirementSelected())
                return playerInventory.GetSelectedInteractionMessage();
            else
                return interactiveData.requirementsMessage;
        }
        else if (interactiveData.interactionMessages.Length > 0)
            return interactiveData.interactionMessages[interactionCount % interactiveData.interactionMessages.Length];
        else
            return null;
    }

    private bool PlayerHasRequirementSelected()
    {
        foreach (Interactive requirement in requirements)
            if (playerInventory.IsSelected(requirement))
                return true;

        return false;
    }

    public void Interact()
    {
        print("INTERACTING!");
    }
}
