using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {

    public DialogDef[] dialogDefs;
    static public Dictionary<DialogCat, DialogDef> D_DEFS;

    static public DialogDef GetDialogDefinition(DialogCat cat)
    {
        if (D_DEFS.ContainsKey(cat))
        {
            return (D_DEFS[cat]);
        }
        return (new DialogDef());
    }

    // Use this for initialization
    void Awake () {
        D_DEFS = new Dictionary<DialogCat, DialogDef>();
        foreach (DialogDef def in dialogDefs)
        {
            D_DEFS[def.category] = def;
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
