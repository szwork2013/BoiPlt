Entity migration for a database context
=

In EF5, entity migration was only able to manage a single user model (DbContext) per physical database instance but with EF6, entity migration is able to deal with managing multiple models per physical database instance. This allows us to define multiple EF database contexts and use those to generate migration files.

Enable Migration
-

To enable migration for a database context, run the following command by specifying feature folder name and database context name:

Enable-Migrations -ContextTypeName Protiviti.Boilerplate.Server.Api.FEATURE_NAME.EF_DATABASE_CONTEXT_NAME -MigrationsDirectory Migrations\EF_DATABASE_CONTEXT_NAME

Here is an example from "ApplicationWizard" feature and "ApplicationWizardContext" EF Database Context:

Enable-Migrations -ContextTypeName Protiviti.Boilerplate.Server.Api.ApplicationWizard.ApplicationWizardContext -MigrationsDirectory Migrations\ApplicationWizardContext

Add Migration
-

Run the following command to add a new migration file for your database context:

Add-Migration -ConfigurationTypeName Protiviti.Boilerplate.Server.Migrations.EF_DATABASE_CONTEXT_NAME.Configuration CHANGE_SET_NAME

Here is an example to add an "Initial" migration file for "ApplicationWizardContext" EF Database Context:

Add-Migration -ConfigurationTypeName Protiviti.Boilerplate.Server.Migrations.ApplicationWizardContext.Configuration Initial

<p class="updated">Updated on 12/15/2014 by Alok Gupta</p>
<p class="reviewed">Reviewed on 12/15/2014 by Alok Gupta</p>
















