Package Manager Console (PMC) commands (change with your connection string):

add-migration InitialMigration -Args 'server=localhost;database=medicalequipmentsupplysystem;uid=root;pwd=root;'
update-database -Args 'server=localhost;database=medicalequipmentsupplysystem;uid=root;pwd=root;'

Database flow:

Remove database (if exists)
Remove Migrations folder (if exists)
Set DataAccess as startup project (right click on project -> set as startup project)
Set DataAccess as default project in PMC
Run PMC commands from above
