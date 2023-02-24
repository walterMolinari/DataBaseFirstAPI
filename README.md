# Data Base First API
### Base de datos

![crearTablas](https://user-images.githubusercontent.com/99669275/221085430-a9c5a49f-350d-4e68-bca2-3c82da3125d4.png)

### Scaffold Entity Framework
_Guardando el string de conexion mediante secretos de usuario_

* `$ dotnet user-secrets init` _Inicializamos secretos de usuario_

* `$ dotnet user-secrets set <nombre_de_clave> "<valor_de_clave>"` _Guardamos secreto mediante clave-valor. En este caso ConnectionString(clave) "string de conexion"(valor)_

![6-UserSecrets](https://user-images.githubusercontent.com/99669275/221082165-d155dadb-1bb3-4230-bf1a-281630ca95e7.png)

_Scaffold_

* `$ dotnet user-secrets list` _listado de los secretos de usuarios creados_

* `$ dotnet ef dbcontext scaffold Name=<secreto-guardado> <proveedor> <directorio-de-salida> <eleccion-tablas>`
_La ejecucion de esta linea crea las entidades que sean necesarias a partir de la base de datos_

![7-scaffold](https://user-images.githubusercontent.com/99669275/221082173-7ed2089f-3327-4ae1-9abd-b684648bf09c.png)

_Hasta proximo codigo!!_

