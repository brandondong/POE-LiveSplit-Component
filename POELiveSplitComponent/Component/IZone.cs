using System;

namespace POELiveSplitComponent.Component
{

    interface IZone
    {
        // A mechanism for storing zones that should be split on.
        string Serialize();
    }
}