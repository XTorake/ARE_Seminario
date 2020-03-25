# ARE_Seminario
Para el funcionamiento local de este proyecto se debera sustituir el string de conexion con el de la base de datos local en la que se este trabajando, este string de conexion se debe sustituir en los proyectos llamados Seminario.API, Seminario.BS,Seminario.Dal,Seminario.Dal.EF, Seminario.Dal.Repository y Seminario.Apps en los archivos llamados App.Config 

EJEMPLO:
 <connectionStrings>
    <add name="ARE_SeminarioEntities" connectionString="metadata=res://*/SeminarioModel.csdl|res://*/SeminarioModel.ssdl|res://*/SeminarioModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=***AQUI VA EL NOMBRE DE SU INSTANCIA****;initial catalog=ARE_Seminario;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>

