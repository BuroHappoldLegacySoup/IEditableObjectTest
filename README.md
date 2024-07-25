Just a quick test to find out the best way to implement IEditableObject for Revit tools. Files below are just clones from Revit_UI because we should eventually move the code here to there:

![image](https://github.com/user-attachments/assets/747b7c79-fd62-49a2-91b0-59de9a90b81e)

I tried replicating the scenario we most commonly have: A window showing a list of objects, each of which to be edited in a child window.
Looks like using the `BaseEditableObject` is the cleanest way. The idea is to wrap inside it any objects that require editing and then call `BeginEdit`, `EndEdit` and `CancelEdit` wherever necessary. We then don't need to implement these methods again in each wrapped object class.

You can run the app to see all this in action.

![BaseEditableObject](https://github.com/user-attachments/assets/c3e206c9-a22b-4358-9c49-dac2a43e444e)
