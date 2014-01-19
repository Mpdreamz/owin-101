# Owin Barebones

This project shows how you can use owin without any dlls, appbuilders

It uses katana's "OwinHost.exe" to run the dll, however it still expects a "web" like output directory. Meaning no `bin/{Platform}/` folder but `bin/` instead.

See: http://katanaproject.codeplex.com/workitem/52

This is katana specific but in practice quite a few application frameworks (i.e nancyfx *) assume dlls/views to be in bin folders. 

All the projects in this 101 have a custom output path which is set to `bin`.

### RUN

run 01.bat in the root after a debug build to run the application inside this assembly.