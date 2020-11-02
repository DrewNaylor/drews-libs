[Repository homepage](https://github.com/drewnaylor/drews-libs)

## libscrollswitchtabs
Switch tabs in the Windows Forms TabControl using the mouse scroll wheel, like many Linux applications. Works with VB.Net and C# applications.

Usage instructions will assume you've already downloaded and extracted the library from the Releases page or you've added the library from NuGet.
1. Add a reference to `libscrollswitchtabs.dll` if you're using the non-NuGet version. It may be a good idea to copy the DLL somewhere more local to your application first, so it's easier to keep track of.
2. Add an `Imports libscrollswitchtabs` statement (`using libscrollswitchtabs;` for C#) to the top of the file if you want to. This isn't required as you can refer to the full namespace in the code itself instead, but importing makes it take up less space in the event handlers.
3. Get the `MouseWheel` event of the `TabControl` you want to allow scrolling on, and pass `ScrollSwitchTabs.switch` the tab control you want to allow scroll switching on and the `MouseEventArgs` (`e`, by default).

Example code for VB.NET:
```vbnet
    Private Sub tabcontrolFileOutput_MouseWheel(sender As Object, e As MouseEventArgs) Handles tabcontrolFileOutput.MouseWheel
        ' Allow switching tabs by scrolling on them with the mouse wheel.
        ScrollSwitchTabs.switch(tabcontrolFileOutput, e)
    End Sub
```

Alternatively, you could use `CType(sender, TabControl)` in place of the `TabControl`'s name, and it should still work. This may make it easier to implement (since you can just copy and paste it for multiple `TabControl`s), though it may, in turn, decrease readability. If Option Strict On isn't enabled, casting isn't required, so you could just do `...switch(sender, e)`.

Example code for VB.NET:
```vbnet
    Private Sub tabcontrolFileOutput_MouseWheel(sender As Object, e As MouseEventArgs) Handles tabcontrolFileOutput.MouseWheel
        ' Allow switching tabs by scrolling on them with the mouse wheel.
        ScrollSwitchTabs.switch(CType(sender, TabControl), e)
    End Sub
```

If you'd like to use it with a C# application, you'd need to add a `MouseScroll` event handler after the call to `InitializeComponent();`. You don't have to add a `using libscrollswitchtabs;` statement if you don't want to, and I didn't for the example below. Took me a while to figure out how to do it, but this StackOverflow answer helped: https://stackoverflow.com/a/1190202. `tabControl1` is the name of your tab control you're allowing scrolling on.

Example code for C#:
```csharp
public partial class Form1 : Form
{
// ...
	public Form1()
	{
		InitializeComponent();
		tabControl1.MouseWheel+= new MouseEventHandler(tabControl1_MouseWheel);
	}
		
	// ...
		
	private void tabControl1_MouseWheel(object sender, MouseEventArgs e)
	{
		// Switch tabs when they're scrolled.
		libscrollswitchtabs.ScrollSwitchTabs.@switch(tabControl1, e);
	}
// ...
}
```