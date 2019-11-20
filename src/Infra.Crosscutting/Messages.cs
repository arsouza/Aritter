using System.Diagnostics;

namespace Ritter.Infra.Crosscutting
{
    [DebuggerStepThrough]
    public static class Messages
    {
        public const string StringCannotBeNullOrWhitespace = "String value cannot be null or whitespace";
        public const string StringCannotBeNullOrEmpty = "String value cannot be null or empty";
        public const string ObjectValueCannotBeNull = "Object value cannot be null";
        public const string BothValuesMustNotBeEqual = "Both values must not be equal";
        public const string BothValuesMustBeEqual = "Both values must be equal";
    }
}
