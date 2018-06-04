using System;

namespace Zenject
{
    public enum ValidationErrorResponses
    {
        Log,
        Throw,
    }

    public enum RootResolveMethods
    {
        NonLazyOnly,
        All,
    }

    [Serializable]
    [ZenjectAllowDuringValidation]
    public class ZenjectSettings
    {
        public static ZenjectSettings Default = new ZenjectSettings();

        public ZenjectSettings(
            ValidationErrorResponses validationErrorResponse = ValidationErrorResponses.Log,
            RootResolveMethods validationRootResolveMethod = RootResolveMethods.NonLazyOnly,
            bool displayWarningWhenResolvingDuringInstall = true)
        {
            ValidationErrorResponse = validationErrorResponse;
            ValidationRootResolveMethod = validationRootResolveMethod;
            DisplayWarningWhenResolvingDuringInstall = displayWarningWhenResolvingDuringInstall;
        }

        // Setting this to Log can be more useful because it will print out
        // multiple validation errors at once so you can fix multiple problems before
        // attempting validation again
        public ValidationErrorResponses ValidationErrorResponse
        {
            get; private set;
        }

        // Settings this to true will ensure that every binding in the container can be
        // instantiated with all its dependencies, and not just those bindings that will be
        // constructed as part of the object graph generated from the nonlazy bindings
        public RootResolveMethods ValidationRootResolveMethod
        {
            get; private set;
        }

        public bool DisplayWarningWhenResolvingDuringInstall
        {
            get; private set;
        }
    }
}
