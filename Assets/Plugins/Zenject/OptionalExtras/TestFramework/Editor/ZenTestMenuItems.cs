#if !NOT_UNITY3D

using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using ModestTree;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Zenject.Internal
{
    public static class ZenTestMenuItems
    {
        [MenuItem("Assets/Create/Zenject/Unit Test", false, 60)]
        public static void CreateUnitTest()
        {
            ZenMenuItems.AddCSharpClassTemplate("Unit Test", "UntitledUnitTest", 
                  "using Zenject;"
                + "\nusing NUnit.Framework;"
                + "\n"
                + "\n[TestFixture]"
                + "\npublic class CLASS_NAME : ZenjectUnitTestFixture"
                + "\n{"
                + "\n    [Test]"
                + "\n    public void RunTest1()"
                + "\n    {"
                + "\n        // TODO"
                + "\n    }"
                + "\n}");
        }

        [MenuItem("Assets/Create/Zenject/Integration Test", false, 60)]
        public static void CreateIntegrationTest()
        {
            ZenMenuItems.AddCSharpClassTemplate("Integration Test", "UntitledIntegrationTest", 
                  "using Zenject;"
                + "\nusing System.Collections;"
                + "\nusing UnityEngine.TestTools;"
                + "\n"
                + "\npublic class CLASS_NAME : ZenjectIntegrationTestFixture"
                + "\n{"
                + "\n    [UnityTest]"
                + "\n    public IEnumerator RunTest1()"
                + "\n    {"
                + "\n        // Setup initial state by creating game objects from scratch, loading prefabs/scenes, etc"
                + "\n"
                + "\n        PreInstall();"
                + "\n"
                + "\n        // Call Container.Bind methods"
                + "\n"
                + "\n        PostInstall();"
                + "\n"
                + "\n        // Add test assertions for expected state"
                + "\n        // Using Container.Resolve or [Inject] fields"
                + "\n        yield break;"
                + "\n    }"
                + "\n}");
        }

        [MenuItem("Assets/Create/Zenject/Scene Test", false, 60)]
        public static void CreateSceneTest()
        {
            ZenMenuItems.AddCSharpClassTemplate("Scene Test Fixture", "UntitledSceneTest", 
                  "using Zenject;"
                + "\nusing System.Collections;"
                + "\nusing UnityEngine;"
                + "\nusing UnityEngine.TestTools;"
                + "\n"
                + "\npublic class CLASS_NAME : SceneTestFixture"
                + "\n{"
                + "\n    [UnityTest]"
                + "\n    public IEnumerator TestScene()"
                + "\n    {"
                + "\n        yield return LoadScene(InsertSceneNameHere);"
                + "\n"
                + "\n        // TODO: Add assertions here now that the scene has started"
                + "\n        // Or you can just uncomment to simply wait some time to make sure the scene plays without errors"
                + "\n        //yield return new WaitForSeconds(1.0f);"
                + "\n"
                + "\n        // Note that you can use SceneContainer.Resolve to look up objects that you need for assertions"
                + "\n    }"
                + "\n}");
        }
    }
}
#endif

