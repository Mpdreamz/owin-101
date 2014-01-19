# Owin 101

Progressively walking through owin into katana and back.

## 01 - BareBones

No dlls, just a simple owin handler. Use 01.bat to run.

## 02 - Barebones Middleware

Still no dlls, combining owin middleware by ourselves. Use 02.bat to run.

## 03 - Introducing IAppBuilder

We take a dependency on owin.dll and see what that gives us in return. Use 03.bat to run

## 04 - Helper assemblies

We take on additional dependencies on Owin.Extensions and Owin.Types and again look into how these
help us write terser/better typed owin middleware. Use 04.bat to run

## 05 - Branching the builder

We take a dependency on Microsoft.Owin.Mapping to see how we can get a very simple routing going on. Up untill now our handlers were 
completely sequential. This shows how to branch off and have different endpoints doing different things.

Use 05.bat to run

## 06 - Hosting

This example shows how katana handles the hosting be it self host in a console/service or in IIS.

Run this using F5 in visual studio.


*** NOTE:*** build once prior to running the bat files

