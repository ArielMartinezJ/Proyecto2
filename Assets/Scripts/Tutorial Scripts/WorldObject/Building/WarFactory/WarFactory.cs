using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarFactory : Building
{
    protected override void Start()
    {
        base.Start();
        actions = new string[] { "Tank" }; //para que haya más opciones, tengo que añadir una coma
        //y luego el nombre del prefab del item que quiero que salga para construir
    }

    public override void PerformAction(string actionToPerform)
    {
        base.PerformAction(actionToPerform);
        CreateUnit(actionToPerform);
    }
}
