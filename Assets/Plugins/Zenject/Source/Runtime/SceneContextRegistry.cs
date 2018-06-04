using System.Collections.Generic;
using UnityEngine.SceneManagement;
using ModestTree;

namespace Zenject
{
    public class SceneContextRegistry
    {
        readonly Dictionary<Scene, SceneContext> _map = new Dictionary<Scene, SceneContext>();

        public IEnumerable<SceneContext> SceneContexts
        {
            get { return _map.Values; }
        }

        public void Add(SceneContext context)
        {
            Assert.That(!_map.ContainsKey(context.gameObject.scene));
            _map.Add(context.gameObject.scene, context);
        }

        public SceneContext GetSceneContextForScene(string name)
        {
            var scene = SceneManager.GetSceneByName(name);
            Assert.That(scene.IsValid(), "Could not find scene with name '{0}'", name);
            return GetSceneContextForScene(scene);
        }

        public SceneContext GetSceneContextForScene(Scene scene)
        {
            return _map[scene];
        }

        public SceneContext TryGetSceneContextForScene(Scene scene)
        {
            SceneContext context;

            if (_map.TryGetValue(scene, out context))
            {
                return context;
            }

            return null;
        }

        public void Remove(SceneContext context)
        {
            bool removed = _map.Remove(context.gameObject.scene);

            if (!removed)
            {
                ModestTree.Log.Warn("Failed to remove SceneContext from SceneContextRegistry");
            }
        }
    }

}
