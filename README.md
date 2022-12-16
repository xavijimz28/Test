1. Crear una base de datos en SQL derver  
   CREATE DATABASE Test;
   
2. Dentro de la carpeta Test buscar archivo Program.cs para descomentar el codigo para realizar las migraciones de las tablas de la base de datos.

    ![image](https://user-images.githubusercontent.com/110143623/208111063-eb12e8f5-92fb-44c2-ac1e-98f45c42695a.png)


3. En el archivo appsetiings.json en la conexion con la base de datos cambiar el nombre del servidor

    ![image](https://user-images.githubusercontent.com/110143623/208111323-08ef85e4-0ee8-4cdc-a740-1f22932907ac.png)

4. Establecer como proyecto de inicio El proyecto Test

5. Abrir la Consola de administracion de paquetes seleccionar como proyecto predeterminado TestDB y ejecutar el comando
   Add-Migration InitDB
   
    ![image](https://user-images.githubusercontent.com/110143623/208112643-137b9131-0794-4c7e-9902-d20a6fc64127.png)

6. Se crean las migraciones y verificar en SQL server que se hayan creado las tablas

    ![image](https://user-images.githubusercontent.com/110143623/208113076-6b42bf43-5adc-4aea-a6bf-dd4274fd3668.png)
    
7. Ejecutamos el programa para realizar las pruebas con Swagger

    ![image](https://user-images.githubusercontent.com/110143623/208113811-b1cfcd66-52c7-4f5d-b4f4-e51c532134a6.png)






