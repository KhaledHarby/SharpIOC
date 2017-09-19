### Sharp IOC

## Contents

1. <a href="#introduction">Introduction</a>
2. <a href="#features">Features</a>
3. <a href="#concepts">Concepts</a>
	1. <a href="#about-di">About dependency injection (DI)</a>
		1. <a href="#what-is">What is a DI container?</a>
		2. <a href="#why-use-it">Why use a DI container?</a>
		3. <a href="#why-use-with-unity">Why use it with Unity?</a>
		4. <a href="#common-use-cases">Common use cases</a>
		5. <a href="#further-readings">Further readings</a>
		
		
4. <a href="#howtouse">How to use ?</a>

5. <a href="#Example">Examples</a>
	1. <a href="#Example">Code Examples (DI)</a>	        
		1. <a href="#ewindows">Windows</a>
		2. <a href="#eweb">Web</a>
		3. <a href="#ewebapi">Web API</a>
		4. <a href="#econsole">Console</a>		

## <a id="introduction"></a>Introduction

SharpIoc is a lightweight dependency injection container C# (or .Net) project.

## <a id="features"></a>Features

* Bind types, singleton instances, factories, game objects and prefabs.
* Instance resolution by type, identifier and complex conditions.
* Injection on constructor, fields and properties.
* Can resolve and inject instances from types that are not bound to the container.
* Can inject automatically on components of a scene.
* Fast dependency resolution with internal cache.<a href=#performance>\*</a>
* Use of attributes to indicate injections, preferable constructors and post constructors.
* Can be easily extended through extensions.
* Simple API.

## <a id="concepts"></a>Concepts

### <a id="about-di"></a>About dependency injection (DI)

#### <a id="what-is"></a>What is a DI container?

A *dependency injection container* is a piece of software that handles the resolution of dependencies in objects. It's related to the [dependency injection](http://en.wikipedia.org/wiki/Dependency_injection) and [inversion of control](http://en.wikipedia.org/wiki/Inversion_of_control) design patterns.

The idea is that any dependency an object may need should be resolved by an external entity rather than the own object. Practically speaking, an object should not use `new` to create the objects it uses, having those instances *injected* into it by another object whose sole existence is to resolve dependencies.

So, a *dependency injection container* holds information about dependencies (the *bindings*) that can be injected into another objects by demand (injecting into existing objects) or during resolution (when you are creating a new object of some type).

#### <a id="why-use-it"></a>Why use a DI container?

In a nutshell, **to decouple your code**.

A DI container, in pair with a good architecture, can ensure [SOLID principles](http://en.wikipedia.org/wiki/SOLID_%28object-oriented_design%29) and help you write better code.

Using such container, you can easily work with abstractions without having to worry about the specifics of each external implementation, focusing just on the code you are writing. It's all related to dependencies: any dependency your code needs is not resolved directly by your code, but externally, allowing your code to deal only with its responsibilities.

As a plus, there are other benefits from using a DI container:

1. **Refactorability**: with your code decoupled, it's easy to refactor it without affecting the entire codebase.
2. **Reusability**: thinking about abstractions allows your code to be even more reusable by making it small and focused on a single responsibility.
3. **Easily change implementations**: given all dependencies are configured in the container, it's easy to change a implementation for a given abstraction. It helps e.g. when implementing generic functionality in a platform specific way.
4. **Testability**: by focusing on abstractions and dependency injection, it's easy to replace implementations with mock objects to test your code.
5. **Improved architecture**: your codebase will be naturally better and more organized because you'll think about the relationships of your code.
6. **Staying sane**: by focusing on small parts of the code and having a consistent architecture, the sanity of the developer is also ensured!

#### <a id="why-use-with-unity"></a>Why use it with Unity?

Unity is not SOLID friendly out of the box. Even the official examples may give a wrong idea on how to code on Unity. Using a DI container in conjunction with Unity, it's possible to write code that is more extensible, reusable and less `MonoBehaviour` centric (in most cases, a regular class can do just fine or better).

This way your code can become more modular and your components less tightly coupled to each other.

#### <a id="common-use-cases"></a>Common use cases

##### Class dependency

Imagine you class depend on a given service that provides some action it may need:

```cs
public class SharpClass {
	public void DoAction() {
		var service = new SomeService();
		service.SomeAction();
	}
}
```

If in the future you need to change the implementation of the service, you'll have to get back to the class and change it. It can work just fine for small projects, but as the codebase grows, it can become a (error prone) nightmare to chase all these references.

So, you can change to a more decoupled code, making `SharpClass` not having to worry about the specific implementation of `SomeService` it uses:

```cs
public class SharpClass {
	private IService service;

	public SharpClass(IService service) {
		this.service = service;
	}

	public void DoAction() {
		this.service.SomeAction();
	}
}
```

#### <a id="further-readings"></a>Further readings

- [The truth behind Inversion of Control – Part I – Dependency Injection](http://www.sebaslab.com/the-truth-behind-inversion-of-control-part-i-dependency-injection/)
- [The truth behind Inversion of Control – Part II – Inversion of Control](http://www.sebaslab.com/the-truth-behind-inversion-of-control-part-ii-inversion-of-control/)
- [The truth behind Inversion of Control – Part III – Entity Component Systems](http://www.sebaslab.com/the-truth-behind-inversion-of-control-part-iii-entity-component-systems/)
- [The truth behind Inversion of Control – Part IV – Dependency Inversion Principle](http://www.sebaslab.com/the-truth-behind-inversion-of-control-part-iii-entity-component-systems/)
- [From STUPID to SOLID Code!](http://williamdurand.fr/2013/07/30/from-stupid-to-solid-code/)



#### <a id="howtouse"></a>How to use ?

1 - Create SharpIocContainer instance
```cs
 var container = new SharpIocContainter();
 ```
 
 2- Create Bootstrapper [You can directly register objects without bootsrtapper creation .It's depends on you]
 ```cs
  public static class BootStrapper
    {
        public static void Configure(IContainer container)
        {
            container.Register<DbContext, Models.masterEntities>(LifeCycle.Singleton);
            container.Register<HomeController, HomeController>(LifeCycle.Transient);
        }
    }
 ```
 
 3 - Configure Bootstrapper 
 ```cs
  var container = new SharpIocContainter();
  BootStrapper.Configure(container); 
 ```
 
 
 4 - Check if an objects is already registered  
  ```cs
 container.IsRegistered(typeof(DbContext));
```
 
   ```cs
 container.IsRegistered(typeof(DbContext), LifeCycle.Singleton);
 ```
 
   ```cs
  container.IsRegistered<DbContext>();
 ```
 
 
   ```cs
  container.IsRegistered<DbContext>();
 ```
 
   ```cs
container.IsRegistered<DbContext>(LifeCycle.Singleton);
```
 
 
   ```cs
  container.IsRegistered<DbContext, masterEntities>();
 ```
 
   ```cs
  container.IsRegistered<DbContext, masterEntities>(LifeCycle.Singleton);
 ```
 
 

#### <a id="Examples"></a>Code Examples

#### <a id="ewindows"></a>Windows

```cs
public partial class Form1 : Form
    {
        private readonly ILog _log;
        public Form1(ILog log)
        {
            InitializeComponent();
            _log = log;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnWriteMessage_Click(object sender, EventArgs e)
        {
            _log.Log("SharpIoc ");
        }
    }
    ```



#### <a id="eweb"></a>Web 

1 - Create Bootstrapper
```cs
 public static class BootStrapper
    {
        public static void Configure(IContainer container)
        {
            container.Register<DbContext, Models.masterEntities>(LifeCycle.Singleton);
            container.Register<HomeController, HomeController>(LifeCycle.Transient);
        }
    }
```


 2- Create IOC Factory thats respresents the controller factory registered by default
 
```cs
  public class IocFactory : DefaultControllerFactory
    {
        private readonly IContainer container;

        public IocFactory(IContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return container.Resolve(controllerType) as Controller;
        }
    }
```



3 - Go to Global.asax.cs > Application_Start 

```cs            var container = new SharpIocContainter();
            BootStrapper.Configure(container);
            ControllerBuilder.Current.SetControllerFactory(new IocFactory(container));	    
```







