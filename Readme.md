# Owin 101

Progressively walkthrough owin into katana and back.

## 01 - BareBones

No dlls, just a simple owin handler. Use 01.bat to run.

[Owin101.BareBones's Readme](Owin101.BareBones)

## 02 - Barebones Middleware

Still no dlls, combining owin middleware by ourselves. Use 02.bat to run.

[Owin101.BareBonesMiddleware's Readme](Owin101.BareBonesMiddleware)

## 03 - Introducing IAppBuilder

We take a dependency on owin.dll and see what that gives us in return. Use 03.bat to run

[Owin101.IntroducingIAppBuilder's Readme](Owin101.IntroducingIAppBuilder)

## 04 - Helper assemblies

We take on additional dependencies on Owin.Extensions and Owin.Types and again look into how these
help us write terser/better typed owin middleware. Use 04.bat to run

[Owin101.HelperAssemblies's Readme](Owin101.HelperAssemblies)

## 05 - Branching the builder

We take a dependency on Microsoft.Owin.Mapping to see how we can get a very simple routing going on. Up until now our handlers were 
completely sequential. This shows how to branch off and have different endpoints doing different things.

Use 05.bat to run

[Owin101.BranchingBuilder's Readme](Owin101.BranchingBuilder)

## 06 - Hosting

This example shows how katana handles the hosting be it self host in a console/service or in IIS.

Run this using F5 in visual studio.

[Owin101.Hosting's Readme](Owin101.Hosting)


*** NOTE:*** build once prior to running the bat files

