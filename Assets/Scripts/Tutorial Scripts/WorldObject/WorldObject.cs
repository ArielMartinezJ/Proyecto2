using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public string objectName;
    public Texture2D buildImage;
    public int cost, sellValue, hitPoints, maxHitPoints;

    public void SetSelection(bool selected)
    {
        currentlySelected = selected;
    }

    public string[] GetActions()
    {
        return actions;
    }

    public virtual void PerformAction (string actionToPerform)
    {
        //It is up to the children with specific actions to determine what to do with each of those actions
    }

    public virtual void MouseClick (GameObject hitObject, Vector3 hitPoint, Player controller)
    {
        if (currentlySelected && hitObject && hitObject.name != "Ground")
        {
            WorldObject worldObject = hitObject.transform.root.GetComponent<WorldObject>();
            if (worldObject) //worldObject != null
            {
                ChangeSelection(worldObject, controller);
            }
        }
    }
    protected Player player;
    protected string[] actions = { };
    protected bool currentlySelected = false;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        player = transform.root.GetComponent<Player>();
    }

    protected virtual void Update()
    {

    }

    protected virtual void OnGUI()
    {

    }

    private void ChangeSelection (WorldObject worldObject, Player controller)
    {
        //this should be called by the following line, but there is an outside chance it will not
        SetSelection(false);
        if (controller.SelectedObject)
        {
            controller.SelectedObject.SetSelection(false);
        }
        controller.SelectedObject = worldObject;
        worldObject.SetSelection(true);

    }
}
