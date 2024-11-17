using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private SpecialInteractions specialInteractions;

    private InteractionManager  interactionManager;
    private List<Interactive>   requirements;
    private List<Interactive>   dependents;
    private Animator            animator;
    private bool                requirementsMet;
    private int                 interactionCount;

    public InteractiveData      interactiveData;
    public PlayerInventory      playerInventory;
    public bool                 isOn;

    public InteractiveData InteractiveData
    {
        get { return interactiveData; }
    }

    public string InventoryName
    {
        get { return interactiveData.inventoryName; }
    }

    public Sprite InventoryIcon
    {
        get { return interactiveData.inventoryIcon; }
    }

    private bool IsType(InteractiveData.Type type)
    {
        return interactiveData.type == type;
    }

    void Awake()
    {
        interactionManager =    InteractionManager.Instance;
        playerInventory =       interactionManager.PlayerInventory;
        requirements =          new List<Interactive>();
        dependents =            new List<Interactive>();
        animator =              GetComponent<Animator>();
        requirementsMet =       interactiveData.requirements.Length == 0;
        interactionCount =      0;
        isOn =                  interactiveData.startsOn;

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
        if (requirementsMet)
            InteractSelf(true);
        else if (PlayerHasRequirementSelected())
            UseRequirementFromInventory();
    }
    private void InteractSelf(bool direct)
    {
        if (direct && IsType(InteractiveData.Type.Indirect))
            return;
        else if (IsType(InteractiveData.Type.Pickable) && !playerInventory.IsFull())
            PickUpInteractive();
        else if (IsType(InteractiveData.Type.InteractOnce) || IsType(InteractiveData.Type.InteractMulti))
            DoDirectInteraction();
        else if (IsType(InteractiveData.Type.Indirect))
            PlayAnimation("Interact");
    }

    private void PickUpInteractive()
    {
        playerInventory.Add(this);
        gameObject.SetActive(false);
    }

    private void DoDirectInteraction()
    {
        ++interactionCount;

        if (IsType(InteractiveData.Type.InteractOnce))
            isOn = false;

        CheckDependentsRequirements();
        DoIndirectInteractions();

        PlayAnimation("Interact");
    }

    private void CheckDependentsRequirements()
    {
        foreach (Interactive dependent in dependents)
            dependent.CheckRequirements();
    }

    private void CheckRequirements()
    {
        foreach (Interactive requirement in requirements)
        {
            if (!requirement.requirementsMet ||
               (!requirement.IsType(InteractiveData.Type.Indirect) && requirement.interactionCount == 0))
            {
                requirementsMet = false;
                return;
            }
        }

        requirementsMet = true;
        PlayAnimation("Awake");

        CheckDependentsRequirements();
    }

    private void DoIndirectInteractions()
    {
        // Work on this a bit
        if (specialInteractions != null)
            specialInteractions.SpecialInteract(this);

        foreach (Interactive dependent in dependents)
            if (dependent.IsType(InteractiveData.Type.Indirect) && dependent.requirementsMet)
                dependent.InteractSelf(false);
    }

    private void PlayAnimation(string animation)
    {
        if (animator != null)
        {
            gameObject.SetActive(true);
            animator.SetTrigger(animation);
        }
    }

    private void UseRequirementFromInventory()
    {
        Interactive requirement = playerInventory.GetSelected();

        playerInventory.Remove(requirement);

        ++requirement.interactionCount;

        requirement.PlayAnimation("Interact");

        CheckRequirements();
    }
}
