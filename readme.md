![Caju](https://raw.githubusercontent.com/ivanpaulovich/manga/master/docs/manga-icon.png) Caju: Back-end with awesome architectures made easy!
=========
Service Template to help you build evolvable and maintainable applications. It follows the principles from the [Clean Architecture book](https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164) and built on Domain-Driven Design. This tool increases productivity on developing your next microservices.

![dotnet new caju](https://raw.githubusercontent.com/ivanpaulovich/caju/master/images/dotnet-new-caju.gif)

## Generate your own awesome Back-end!

To create a dotnet application based on this template:

```sh
dotnet new -i Paulovich.Caju
dotnet new caju -n "MyProject"
```

## The Architecture Styles

This architecture implementations is a software that encapsulate Business Rules in Use Cases and the Enteprise Rules in Entities. We prevent our software to be coupled from technology details like User Interface, Data Access frameworks or Web Servers. And there is some concepts which guided us:

| Concept | Description |
| --- | --- |
| DDD | This Bounded Context of this project contains the Ubiquitious Language around Account Balance and designed inside Domain Layer and Application layer. We use the Eric Evans terms like Entities, Value Object, Aggregates Root and Domain Events. |
| SOLID | The SOLID principles are all over the the solution. 
| Entity-Boundary-Interactor (EBI) | The software implementation is agnostic from technology, framework, or database. The result is focus on the  use cases with input/output ports. |
| Microservice | Designed around the Business Domain, having Continous Delivery and Independent Deployment. |
| Logging | Logging is a detail. We plugged Serilog and configured it to redirect every log message to the file system. |
| Docker | Docker is a detail. It was implemented to help us make a faster and reliable deployment. |
| MongoDB | MongoDB is a detail. You can create a new Data Access implementation and setup it at startup. |
| .NET Core 2.0 | .NET Core is a detail. Almost everything in this code base could be ported to other versions. |

## Sample applications

Run `dotnet new -i Paulovich.Caju` then try the following commands.

Clean Architecture Solution with basic use cases:

```sh
dotnet new caju \
	--architecture-style clean \
	--use-cases basic \
	-n "Clean-BasicProject"
```

Hexagonal Architecture Solution with all use cases:

```sh
dotnet new caju \
	--architecture-style hexagonal \
	--use-cases full \
	-n "Hexagonal-FullProject"
```

Empty Event-Sourcing Solution:

```sh
dotnet new caju \
	--architecture-style eventsourcing \
	--use-cases empty \
	-n "EventSourcing-EmptyProject"
```

For olher solution types check out the [Caju Samples folder](https://github.com/ivanpaulovich/caju/tree/master/samples).

## Switches

There are switches to generate your awesome application with your needs. Try-out:

| Switch | Options | Default Value |
| --- | --- | --- |
| --architecture-style | `clean` `hexagonal` `eventsourcing` | `clean` |
| --use-cases | `full` `basic` `readonly` `empty` | `full` |
| --ui | `none` `webapi` `console` `both` | `webapi` |
| --infrastructure | `mongodb` `sqlserver` | `mongodb` |
| --tips | `true` `false` | `true` |

## Roadmap
<a href="https://www.nuget.org/packages/Paulovich.Caju/" rel="Paulovich.Caju">![NuGet](https://img.shields.io/nuget/v/Paulovich.Caju.svg)</a> [![Build Status](https://travis-ci.org/ivanpaulovich/caju.svg?branch=master)](https://travis-ci.org/ivanpaulovich/caju)

* Allow to choose the **Architecture Style**
	* *Clean Architecture* :white_check_mark:
	* *Hexagonal Architecture* :white_check_mark:
	* *Event-Sourcing* :white_check_mark:
* Allow to choose built-in **Use Cases** sets
	* *Full* set of use cases :white_check_mark:
	* *Basic* set of use cases :white_check_mark:
	* *Read Only* :white_check_mark: 
	* *Empty* :white_check_mark:	
* Allow to choose **Infrastructure** details. 
	* *MongoDB*
	* *Kafka*
	* *SQL-Server*
* Allow to choose the **UI** implementations
	* *WebAPI*
	* *Console* 
	* *Both* 
	* *None*.
* Allow to **Skip dotnet restore** after code generation.
* Allow to include or remove the **Architecture Tips** :white_check_mark:
