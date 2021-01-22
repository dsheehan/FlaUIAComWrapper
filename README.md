A fork of UIAComWrapper
=============

- Allows interoperability of [TestStack.White](https://github.com/TestStack/White) and [FlaUI](https://github.com/FlaUI/FlaUI) within the same project (AppDomain).
- Reworks [UIAComWrapper](https://github.com/TestStack/UIAComWrapper) to depend on [UIAutomation-Interop](https://github.com/FlaUI/UIAutomation-Interop).
- Allows for gradual transition, where a full-migration was not economically feasible in a single-shot
- A prior PoC using [FlaUI.Adapter.White](https://github.com/FlaUI/FlaUI.Adapter.White) proved to be unusable, given the complex workarounds we had already made in our project for limitations in TestStack.White. Simpler projects may not run into the same issues.  
- No effort has (intentionally) been made to cleanup code in order to minimize future fork rebase efforts, bare minimum to build and achieve interop.
- Package name kept as UIAComWrapper to allow for drop in replacement, and trying to mitigate issues with signing, without forking/rebuilding TestStack.White
- Example usage of interop can be seen in branch [InteropPoC](https://github.com/dsheehan/FlaUIAComWrapper/tree/InteropPoC) / [Program.cs](https://github.com/dsheehan/FlaUIAComWrapper/blob/InteropPoC/InteropPoC/Program.cs)  

![Screenshot](https://raw.githubusercontent.com/dsheehan/UIAComWrapper/0cb7685fbd4475ac22fd5b4d318cebf4a3335419/InteropPoC/UIA.png)

Changes
-------
### v1.1.1.16
- Use NuGet Interop.UIAutomationClient.Signed v10.18362.0 from https://github.com/FlaUI/UIAutomation-Interop so that we can use TestStack.White alongside FlaUI
- InteropPoC an example using TestStack.White and FlaUI in the same assembly/appdomain, and converting between the two
- instead of using an internal package reference it requires installing the NuGet package locally. This is how an independent project would use it; easier copy/paste the example.
- Update README

### v1.1.0.14 (fork)
- added source indexing with [GitLink](https://github.com/GitTools/GitLink). Makes issue debugging much easier as stepping into UIAComWrapper code in VS automatically downloads proper source code from GitHub.
