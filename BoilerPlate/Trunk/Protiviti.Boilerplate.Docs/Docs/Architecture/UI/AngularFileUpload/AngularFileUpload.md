#Angular File Upload
============

## Overview ##
------------

The application lets the user upload a file of any format. The file details are stored in the database. The same can also be viewed from the grid placed on the same page. The maximum file upload limit is set around 65 MB.

* File Upload By Submit - 

User can select a file/ multiple files from the file placeholder. A required field 'Title' must also be provided. The submit button is activated only when a file is selected and the corresponding title is provided. In case of multiple file selection, all the files selected would have the same title.


* File Upload By Drag and Drop - 

User can upload by file by drag a file and dropping it in the required area. Once dropped, the file will be uploaded. If the title field is empty, the file name (without extension) is stored as the default title.


* Uploaded Files -

The grid has columns File Name, Title, Uploaded Date, Size (kB). The file name is in form of a hyperlink, clicking on which the same file would be downloaded. The grid shows maximum 10 items at a time. The user can navigate through the pages using the 'First Page' , 'Previous Page' and 'Next Page' buttons.

Each file can be edited as well as deleted from the grid itself. Each row of the grid has a edit and a delete icon. 

* Editing a file-

On clicking the edit icon, the file name and file title field become editable. Two additional buttons- Save and Cancel are visible. Since Title and file Name are required fields, if the user tries to save a blank field, the changes would not be saved. The user would be prompted to fill the required fields.

* Deleting a file-

On clicking on the delete icon, the user is presented with a confirm pop up. If the user confirms the same, the file gets deleted.

* Searching a file-

Just above the files grid, a search box is present. The user can search for his/her file by typing in the file name. The grid gets filtered as per the text entered. If the search string is present anywhere in the string, the file would be displayed.

Example -
-----------
<br />
Following is the screenshot when a user uploads a file by submit. 

![File Upload](/Protiviti.Boilerplate.Docs/images/AngularFileUpload/uploadBySubmit.png)

Now when the user tries to search for the file using the search feature, the file is listed as below:

![File Upload](/Protiviti.Boilerplate.Docs/images/AngularFileUpload/searchUploadedFile.png)

On trying to edit the file the user is presented with the following edit options: 

![File Upload](/Protiviti.Boilerplate.Docs/images/AngularFileUpload/editUploadedFile.png)


<p class="updated">Updated on 12/30/2014 by Shruti Pandey</p>
<p class="reviewed">Reviewed on 12/31/2014 by Shruti Pandey</p>





                      
