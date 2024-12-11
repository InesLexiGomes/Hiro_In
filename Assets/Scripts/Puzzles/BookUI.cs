using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pagesFront;
    [SerializeField] List<Transform> pagesBack;
    int index = -1;
    bool rotate = false;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject forwardButton;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameObject bookUI;

    private bool rotateForward = true;

    private void Start()
    {
        InitialState();
    }

    public void InitialState()
    {
        for (int i=0; i<pagesFront.Count; i++)
        {
            pagesFront[i].transform.rotation=Quaternion.identity;
            pagesBack[i].transform.rotation=Quaternion.identity;
        }
        pagesFront[0].SetAsLastSibling();
        backButton.SetActive(false);
    }

    public void RotateForward()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 180; //in order to rotate the page forward, set the rotation by 180 degrees around the y axis
        ForwardButtonActions();
        rotateForward = true;
        StartCoroutine(Rotate(angle, true));
    }

    public void ForwardButtonActions()
    {
        if (backButton.activeInHierarchy == false)
        {
            backButton.SetActive(true); //every time we turn the page forward, the back button activates
        }
        if (index == pagesFront.Count - 1)
        {
            forwardButton.SetActive(false); //if the page is last then turn off the forward button
        }
    }

    public void RotateBack()
    {
        if (rotate == true) { return; }
        float angle = 0; //in order to rotate the page back, set the rotation to 0 degrees around the y axis
        rotateForward = false;
        BackButtonActions();
        StartCoroutine(Rotate(angle, false));
    }

    public void BackButtonActions()
    {
        if (forwardButton.activeInHierarchy == false)
        {
            forwardButton.SetActive(true); //every time we turn the page back, the forward button activates
        }
        if (index - 1 == -1)
        {
            backButton.SetActive(false); //if the page is first turn off the back button
        }      
    }
    private void Quit()
    {
        uiManager.EnablePlayer();
        bookUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Quit();
    }

    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            rotate = true;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            value += Time.deltaTime * pageSpeed;
            pagesFront[index].rotation = Quaternion.Slerp(pagesFront[index].rotation, targetRotation, value); //smoothly turn the page
            pagesBack[index].rotation = Quaternion.Slerp(pagesBack[index].rotation, targetRotation, value); //smoothly turn the page
            float angle1 = Quaternion.Angle(pagesFront[index].rotation, targetRotation); //calculate the angle between the given angle of rotation and the current angle of rotation
            if (angle1 < 90f)
            {
                if (rotateForward)
                    pagesBack[index].SetAsLastSibling();
                else
                    pagesFront[index].SetAsLastSibling();
            }

            if (angle1 < 0.1f)
            {
                if (forward == false)
                {
                    index--;
                }
                rotate = false;
                break;

            }
            yield return null;
        }
    }
}
