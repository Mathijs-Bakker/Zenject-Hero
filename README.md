[<img src="https://private-user-images.githubusercontent.com/7645831/483198011-85f45fc1-779e-4f18-b794-4a4190156f10.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NTYzOTE0NDksIm5iZiI6MTc1NjM5MTE0OSwicGF0aCI6Ii83NjQ1ODMxLzQ4MzE5ODAxMS04NWY0NWZjMS03NzllLTRmMTgtYjc5NC00YTQxOTAxNTZmMTAucG5nP1gtQW16LUFsZ29yaXRobT1BV1M0LUhNQUMtU0hBMjU2JlgtQW16LUNyZWRlbnRpYWw9QUtJQVZDT0RZTFNBNTNQUUs0WkElMkYyMDI1MDgyOCUyRnVzLWVhc3QtMSUyRnMzJTJGYXdzNF9yZXF1ZXN0JlgtQW16LURhdGU9MjAyNTA4MjhUMTQyNTQ5WiZYLUFtei1FeHBpcmVzPTMwMCZYLUFtei1TaWduYXR1cmU9MDBkMDdhZjM5MzFlYmI3YzJjMjBjM2JlMDIxNWYwZTQ2NzIxMjI4NzFmMzFhNjc2ODVjNjhmNDc0ZTQ1MTc1NiZYLUFtei1TaWduZWRIZWFkZXJzPWhvc3QifQ.TjrBF77IU1gvZNo2h95s3wxHserSRMSklwpGbjs5c8c" width=150>](https://buymeacoffee.com/mathijs.bakker)
# Zenject H.E.R.O. (WIP)
## Unity3D project using a dependency injection framework.
Example game with Zenject 7, DiContainer, Installers, Factories, MemoryPools, Signals, etc.

Remember H.E.R.O.? An ancient 8 bit game by Activision made famous on the Atari 2600. Watch on YouTube. Because of the 'simple'game mechanics I chose to recreate this game while learning Zenject.  

![](https://i.imgur.com/ABdBN3A.gif)  
(images from the original game)

## SOLID Principles
## Dependency Injection
Dependency injection is a technique whereby one object supplies the dependencies of another object. A dependency is an object that can be used (a service). An injection is the passing of a dependency to a dependent object (a client) that would use it.  

This fundamental requirement means that using values (services) produced within the class from new or static methods is prohibited. The client should accept values passed in from outside. This allows the client to make acquiring dependencies someone else's problem.  

The intent behind dependency injection is to decouple objects to the extent that no client code has to be changed simply because an object it depends on needs to be changed to a different one.

Dependency injection is one form of the broader technique of inversion of control. As with other forms of inversion of control, dependency injection supports the dependency inversion principle. The client delegates the responsibility of providing its dependencies to external code (the injector). The client is not allowed to call the injector code. It is the injecting code that constructs the services and calls the client to inject them. This means the client code does not need to know about the injecting code. The client does not need to know how to construct the services. The client does not need to know which actual services it is using. The client only needs to know about the intrinsic interfaces of the services because these define how the client may use the services. This separates the responsibilities of use and construction.

## What is Zenject?
Zenject is a lightweight dependency injection framework built specifically to target Unity 3D (however it can be used outside of Unity as well). It can be used to turn your application into a collection of loosely-coupled parts with highly segmented responsibilities. Zenject can then glue the parts together in many different configurations to allow you to easily write, re-use, refactor and test your code in a scalable and extremely flexible way.  
*Source: [Zenject ReadMe](https://github.com/modesttree/Zenject/blob/master/README.md)*

## Getting Started

Download and open the project in Unity3D.

## Built With

* [Unity3D - 2018.2.10f1](https://unity3d.com/get-unity/download)
* [Zenject 7.2.0](https://github.com/svermeulen/Zenject/releases) - Zenject Dependency Injection IOC

![](https://i.imgur.com/Y28u4Nh.png)  
(Screenshot from this game)

## H.E.R.O.

H.E.R.O. (standing for Helicopter Emergency Rescue Operation) is a video game written by John Van Ryzin and published by Activision for the Atari 2600 in March 1984. It was ported to the Apple II, Atari 5200, Atari 8-bit family, ColecoVision, Commodore 64, MSX, and ZX Spectrum. Sega released a version of the game for its SG-1000 console in Japan in 1985. While the gameplay was identical, Sega changed the backpack from a helicopter to a jetpack.

The player uses a helicopter backpack and other tools to rescue victims trapped deep in a mine. The mine is made up of multiple screens using a flip screen style.  

### Gameplay

The player assumes control of Roderick Hero (sometimes styled as "R. Hero"), a one-man rescue team. Miners working in Mount Leone are trapped, and it's up to Roderick to reach them.

The player is equipped with a backpack-mounted helicopter unit, which allows him to hover and fly, along with a helmet-mounted laser and a limited supply of dynamite. Each level consists of a maze of mine shafts that Roderick must safely navigate in order to reach the miner trapped at the bottom. The backpack has a limited amount of power, so the player must reach the miner before the power supply is exhausted.  
  
Mine shafts may be blocked by cave-ins or magma, which require dynamite to clear. The helmet laser can also destroy cave-ins, but more slowly than dynamite. Unlike a cave-in, magma is lethal when touched. Later levels include walls of magma with openings that alternate between open and closed requiring skillful navigation. The mine shafts are populated by spiders, bats and other unknown creatures that are deadly to the touch; these creatures can be destroyed using the laser or dynamite.  
  
Some deep mines are flooded, forcing players to hover safely above the water. In later levels, monsters strike out from below the water. Some mine sections are illuminated by lanterns. If the lantern is somehow destroyed, the layout of that section becomes invisible. Exploding dynamite lights up the mine for a brief time.  
  
Points are scored for each cave-in cleared and each creature destroyed. When the player reaches the miner, points are awarded for the rescue, along with the amount of power remaining in the backpack and for each remaining stick of dynamite. Extra lives are awarded for every 20,000 points scored.  
*Source: [Wikipedia](https://en.wikipedia.org/wiki/H.E.R.O.)*

## Authors

* **Mathijs Bakker** - *Development* - | [LinkedIn](https://www.linkedin.com/in/mathijs-bakker-a56a453) | [GitHub](https://github.com/Mathijs-Bakker) |

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Acknowledgments

* Hat tip to the creator of Zenject - [GitHub](https://github.com/modesttree/Zenject)
* Infallible Code for introducing the World (and me) to DI within Unity3D - [Infallible Code] (http://infalliblecode.com) 
  And if you made it here reading than you should say 'Hi!' @ the [Discord Server] (https://discordapp.com/invite/NjjQ3BU)
