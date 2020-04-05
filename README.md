# drews-libs
 Small libraries I've made that add various features to programs, such as Windows Forms projects. This project is licensed under Apache License 2.0.

## Libraries
### libscrollswitchtabs
Switch tabs in the Windows Forms TabControl using the mouse scroll wheel, like many Linux applications. Currently only available for VB.Net, though I'd like it to be usable with C# someday.

How to use:
1. Clone the repository.
2. Either build the `drews-libs-winforms.sln` solution under the `drews-libs-winforms` folder, or build `libscrollswitchtabs.vbproj` under the `drews-libs-winforms\libscrollswitchtabs` folder.
3. Add a reference to `libscrollswitchtabs.dll` located in `drews-libs-winforms\libscrollswitchtabs\bin\Debug`. It may be a good idea to copy the DLL somewhere more local to your application first, so it's easier to keep track of.
4. Import `libscrollswitchtabs`.
4. Get the `MouseWheel` event of the `TabControl` you want to allow scrolling on, and pass `ScrollSwitchTabs.switch` the tab control you want to allow scroll switching on and the `MouseEventArgs` (`e`, by default).

Example code:
```vbnet
    Private Sub tabcontrolFileOutput_MouseWheel(sender As Object, e As MouseEventArgs) Handles tabcontrolFileOutput.MouseWheel
        ' Allow switching tabs by scrolling on them with the mouse wheel.
        ScrollSwitchTabs.switch(tabcontrolFileOutput, e)
    End Sub
```

Alternatively, you could use `CType(sender, TabControl)` in place of the `TabControl`'s name, and it should still work. This may make it easier to implement, though it may, in turn, decrease readability.

Example code:
```vbnet
    Private Sub tabcontrolFileOutput_MouseWheel(sender As Object, e As MouseEventArgs) Handles tabcontrolFileOutput.MouseWheel
        ' Allow switching tabs by scrolling on them with the mouse wheel.
        ScrollSwitchTabs.switch(CType(sender, TabControl), e)
    End Sub
```
