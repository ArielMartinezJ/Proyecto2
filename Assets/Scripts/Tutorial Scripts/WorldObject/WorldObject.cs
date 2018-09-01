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
}
