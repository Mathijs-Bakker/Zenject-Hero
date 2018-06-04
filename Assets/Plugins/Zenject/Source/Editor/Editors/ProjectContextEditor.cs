#if !ODIN_INSPECTOR

using UnityEditor;

namespace Zenject
{
    [CustomEditor(typeof(ProjectContext))]
    public class ProjectContextEditor : ContextEditor
    {
    }
}

#endif
