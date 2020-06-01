# ARE_Seminario
Este proyecto esta realizado en C# ASP.NET

Se utiliza el IDE de visual studio 2019 v.16.4.3 y 
SQL Server Management Studio						15.0.18206.0
Microsoft Analysis Services Client Tools						15.0.1567.0
Microsoft Data Access Components (MDAC)						10.0.18362.1
Microsoft MSXML						3.0 6.0 
Microsoft Internet Explorer						9.11.18362.0
Microsoft .NET Framework						4.0.30319.42000
Operating System						10.0.18363

Para la implementacion de este proyecto de manera local se debera tener lo previamente indicado.

Se procede a correr el script de la base de datos (Debe llamarse ARE_Seminario).

Seguido de esto una vez clonado el repositorio se debera sustituir el string de conexion con el de la base de datos local en la que se este trabajando, este string de conexion se debe sustituir en los proyectos llamados Seminario.API, Seminario.BS,Seminario.Dal,Seminario.Dal.EF, Seminario.Dal.Repository y Seminario.Apps en los archivos llamados App.Config 

EJEMPLO:
 <connectionStrings>
    <add name="ARE_SeminarioEntities" connectionString="metadata=res://*/SeminarioModel.csdl|res://*/SeminarioModel.ssdl|res://*/SeminarioModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=***AQUI VA EL NOMBRE DE SU INSTANCIA****;initial catalog=ARE_Seminario;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>

