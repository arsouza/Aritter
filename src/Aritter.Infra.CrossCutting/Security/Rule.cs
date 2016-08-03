using System;

namespace Aritter.Infra.Crosscutting.Security
{
    [Flags]
    public enum Rule
    {
        None = 0,
        Read = 1,
        Write = 2,
        Modify = 4,
        Delete = 8,
        FullControl = 16
    }
}
