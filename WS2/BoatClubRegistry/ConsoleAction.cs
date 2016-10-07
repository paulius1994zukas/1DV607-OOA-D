using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoatClubRegistry
{
    public enum ActionType
    {
        Quit,
        SaveToFile,
        LoadFromFile,
        ViewVerboseList,
        ViewCompactList,
        ViewMember,
        AddMember,
        EditMember,
        RemoveMember,
        AddBoat,
        EditBoat,
        RemoveBoat,
    }
}