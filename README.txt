
1. Once the project is imported (or before if you like), create the database
2. Run create-tables.sql to create all the tables

3. Modify the Web.Config it to your web.config connection strings. LIkely you can do a find and replace replacing 'aspnet-dot-not-a-goat-20170602044944' with 'scat'.

 <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\scat;Initial Catalog=scat;Integrated Security=True" providerName="System.Data.SqlClient" />
 <add name="NotGoatEntities" connectionString="metadata=res://*/Models.NotGoatEntities.csdl|res://*/Models.NotGoatEntities.ssdl|res://*/Models.NotGoatEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDb)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\scat.mdf;initial catalog=aspnet-dot-not-a-goat-20170602044944;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings>
 
 Depending on where you created your DB, you may also need to modify the Data Source in the connection string

 3. Ensure the application will come up to the home page

 4. Once the application is up, create 5 users in the application manually ... All with the same password
/*
candace@tri.state
phineas@tri.state
ferb@tri.state
doofemshmirtz@tri.state
perry@owca.gov
*/

5. Run the application and click around