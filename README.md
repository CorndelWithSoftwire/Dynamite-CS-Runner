⚠️ This runner hasn't been tested and might be buggy

# Dynamite C\#

Local bot runner for developing [Dynamite](https://dynamite.softwire.com) bots in C#.

## Getting started

Open in Visual Studio and run the Dynamite-CS-Runner project, or from a shell:

```sh
dotnet run --project Dynamite-CS-Runner
```

## Creating your own Bot

The project comes with two example bots, `PaperBot` (which plays Paper) and `DynoRockBot` (which plays Dynamite, then Rocks).

To make your own bot:

* Create a new Class Library project in this solution using .NET Core 2.1
* Add `BotInterface.dll` as a project reference
* Implement the `IBot` class

Read the rules on <https://dynamite.softwire.com/>.

## Uploading your Bot

* If you don't have one sign up for an account on <https://dynamite.softwire.com/> and ask your trainer to approve it
* Publish the solution to a folder

```sh
dotnet publish -c Release -o ./publish
```

* Upload `<YourBotName>.dll` from the published folder
