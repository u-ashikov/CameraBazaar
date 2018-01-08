namespace CameraBazaar.Data.Enums
{
    using System;

    [Flags]
    public enum LightMetering
    {
		Spot = 1,
		CenterWeighted = 2,
		Evaluative = 4
    }
}
