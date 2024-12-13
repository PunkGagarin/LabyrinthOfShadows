using System.ComponentModel;
using UnityEngine;
using Zenject;

public class Testinstaller : MonoInstaller
{
//
//     [SerializeField]
//     private RepoSoTest _repoSoTest;
//
//     [SerializeField]
//     private Transform _parent;
//
//     //БЕЗ настройки
//     // public override void InstallBindings()
//     // {
//     //     //from new по дефолту и так работает
//     //     Container.Bind<SomethingElse>().FromNew().AsSingle();
//     //     var objectNeededToInject = _repoSoTest.GetObjByIndex(1);
//     //     Container.Bind<ObjectNeededToInject>().FromComponentInNewPrefab(objectNeededToInject).AsSingle();
//     //     // Container.Bind<ObjectNeededToInject>().FromFactory(InstantiateObject).AsSingle();
//     // }
//
//     // public override void InstallBindings()
//     // {
//     //     //from new по дефолту и так работает
//     //     Container.Bind<SomethingElse>().FromNew().AsSingle();
//     //     var objectNeededToInject = _repoSoTest.GetObjByIndex(1);
//     //     Container.Bind<ObjectNeededToInject>().FromComponentInNewPrefab(objectNeededToInject)
//     //         .WithGameObjectName("ObjectNeededToInject").UnderTransform(_parent)
//     //         // .OnInstantiated(SetSettings)
//     //         .AsSingle();
//     //     // Container.Bind<ObjectNeededToInject>().FromFactory(InstantiateObject).AsSingle();
//     // }
//     
//     public override void InstallBindings()
//     {
//         //Factory нужна чтобы пользоваться ею ПОТОМ.
//         // Container.Bind<ObjectNeededToInject>().FromFactory<MyObjFactory>().AsSingle();
//         Container.Bind<ObjectNeededToInject>().FromMethod(MyInstantiateMethod).AsSingle().NonLazy();
//     }
//     
//     //не разобрался, почитать доки
//     // public override void InstallBindings()
//     // {
//     //     //Factory нужна чтобы пользоваться ею ПОТОМ.
//     //     // Container.Bind<ObjectNeededToInject>().FromFactory<MyObjFactory>().AsSingle();
//     //     // Container.Bind<ObjectNeededToInject>().FromFactory<MyObjFactory>().AsSingle().NonLazy();
//     // }
//
//     private ObjectNeededToInject MyInstantiateMethod()
//     {
//         var objectNeededToInject = _repoSoTest.GetObjByIndex(1);
//         var obj = Instantiate(objectNeededToInject, _parent);
//         return obj;
//     }
//
// }
//
// public class MyObjFactory : PrefabFactory<ObjectNeededToInject>
// {
//
//     [Inject] private RepoSoTest _repoSoTest;
//
//     private ObjectNeededToInject MyInstantiateMethod()
//     {
//         var objectNeededToInject = _repoSoTest.GetObjByIndex(1);
//         var obj = GameObject.Instantiate(objectNeededToInject);
//         return obj;
//     }
}
//
// // public class PrefabFactory<T> : IFactory<UnityEngine.Object, T>
// // //where T : Component
// // {
// //     [Inject]
// //     readonly DiContainer _container = null;
// //
// //     public DiContainer Container
// //     {
// //         get { return _container; }
// //     }
// //
// //     public virtual T Create(UnityEngine.Object prefab)
// //     {
// //         Assert.That(prefab != null,
// //             "Null prefab given to factory create method when instantiating object with type '{0}'.", typeof(T));
// //
// //         return _container.InstantiatePrefabForComponent<T>(prefab);
// //     }
// //
// //     // Note: We can't really validate here without access to the prefab
// //     // We could validate the class directly with the current container but that fails when the
// //     // class is inside a GameObjectContext
// // }
//
// // public class PrefabResourceFactory<T> : IFactory<string, T>
// // //where T : Component
// // {
// //     [Inject]
// //     readonly DiContainer _container = null;
// //
// //     public DiContainer Container
// //     {
// //         get { return _container; }
// //     }
// //
// //     public virtual T Create(string prefabResourceName)
// //     {
// //         Assert.That(!string.IsNullOrEmpty(prefabResourceName),
// //             "Null or empty prefab resource name given to factory create method when instantiating object with type '{0}'.", typeof(T));
// //
// //         var prefab = (GameObject)Resources.Load(prefabResourceName);
// //         return _container.InstantiatePrefabForComponent<T>(prefab);
// //     }
// //
// //     // Note: We can't really validate here without access to the prefab
// //     // We could validate the class directly with the current container but that fails when the
// //     // class is inside a GameObjectContext
// // }