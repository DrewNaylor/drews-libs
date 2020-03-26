' libscrollswitchtabs - Switch tabs in the Windows Forms TabControl
' using the mouse scroll wheel, like many Linux applications.
' Copyright 2020 Drew Naylor
' (Note that the copyright years include the years left out by the hyphen.)
'
' This file is a part of the drews-libs project.
'
'
'   Licensed under the Apache License, Version 2.0 (the "License");
'   you may not use this file except in compliance with the License.
'   You may obtain a copy of the License at
'
'     http://www.apache.org/licenses/LICENSE-2.0
'
'   Unless required by applicable law or agreed to in writing, software
'   distributed under the License is distributed on an "AS IS" BASIS,
'   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
'   See the License for the specific language governing permissions and
'   limitations under the License.


Imports System.Windows.Forms


Public Class ScrollSwitchTabs
    Public Shared Sub switch(tabpage As TabPage, tabcontrol As TabControl, e As MouseEventArgs)
        ' Getting the mouse scroll direction was based on this SO answer:
        ' https://stackoverflow.com/a/2378365

        ' Allows the tabs to be scrolled with the mouse, like in many
        ' Linux applications.
        ' Perhaps this could be made into a sub with args for easier reuse.

        ' Ensure the mouse isn't in the tabpage itself.
        ' This is based on this SO answer:
        ' https://stackoverflow.com/a/21098227

        If Not tabpage.ClientRectangle.Contains(tabpage.PointToClient(Control.MousePosition)) Then

            If e.Delta > 0 Then
                ' If scrolling down, go left.
                If tabcontrol.SelectedIndex - 1 = -1 Then
                    ' If the next tab is out of bounds, select the last tab.
                    tabcontrol.SelectTab(tabcontrol.TabCount - 1)
                Else
                    ' Otherwise, select the tab to the left.
                    tabcontrol.SelectTab(tabcontrol.SelectedIndex - 1)
                End If
            Else
                ' If scrolling up, go right.
                If tabcontrol.SelectedIndex + 1 > tabcontrol.TabCount - 1 Then
                    ' If the next tab is out of bounds above the usable tab indexes,
                    ' select the first tab.
                    tabcontrol.SelectTab(0)
                Else
                    ' Otherwise, select the next tab to the right.
                    tabcontrol.SelectTab(tabcontrol.SelectedIndex + 1)
                End If
            End If
        End If
    End Sub
End Class
