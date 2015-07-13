Roles Management
=================
This tab shows all the roles in a grid with buttons to allow navigation. Also, you can collapse or expand the roles grid. You can view or search an existing role, add new roles, edit or delete existing roles from Admin section. 

![Roles Management](/Protiviti.Boilerplate.Docs/images/Admin/manageroles.jpg)


###Overview
---------------

* **Roles Grid** : 
  This grid displays all the roles in the system. Two columns are displayed, one having the role name and the other containing the edit and delete icon. On clicking the column name 'Role', the column gets sorted. 

* **Expand/Collapse** : 
  There is an arrow in the header of the grid to expand or collapse the grid.

* **Pagination** : 
  Maximum 10 records can be displayed on a single page of the grid. There are buttons- 'First Page', 'Previous Page' and 'Next Page' to navigate to respective pages. Also, the current page number is displayed. 
				
* **Search Existing Roles** : 
  There is a textbox having 'Search' as the placeholder followed by a 'Search' button. On searching for any role, having some subtext, then the corresponding result should be displayed. 

* **Add Role** : 
  This page displays an Role Name label followed by a textbox. Also, an Add button is displayed which remains disable until some text is entered in the Role Name textbox. A 'Back To List' link is displayed to navigate back to the roles page.
			   On clicking the Add button, role updation message is displayed and a new role gets added in the list. On trying to add role with same name an error stating "Name is already taken" message is displayed and the role doesn't get added.  

* **Edit Role** : 
  This page displays an Role Name label followed by a textbox containing the value of the Role to be edited. Also, an Update button is displayed which remains disable until any alteration is made. A 'Back To List' link is displayed to navigate back to the roles page.
			  On making changes and clicking the Update button, an updation message is displayed and the changes are reflected in the list. Also, an error stating "Name is already taken" message is displayed if the same name already exist in the list.

* **Delete Role** : 
  On clicking the delete icon, an alert message is displayed to confirm the deletion, if 'Delete Role' is clicked then the role gets permanently deleted from the list otherwise the role remains in the list. 	

<br />

![Roles](/Protiviti.Boilerplate.Docs/images/Admin/Roles.png)
<p class="updated">Updated on 11/17/2014 by Preiksha Sipani</p>
<p class="reviewed">Reviewed on 11/21/2014 by Ajay Singh</p>
