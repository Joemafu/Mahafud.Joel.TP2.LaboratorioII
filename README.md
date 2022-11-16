# Truco Argentino

### Sobre mí:

Me llamo Joel, tengo 30 años y actualmente estoy cursando el segundo cuatrimestre la Tecnicatura Universitaria en Programación en la Universidad Tecnológica Nacional. Además trabajo como administrador de sistemas a tiempo completo.

### Sobre el proyecto:

El presente proyecto fue una propuesta evaluativa de mi Profesor de Programación y Laboratorio II, y se corresponde al segundo parcial de la materia Laboratorio II.
Para este proyecto elegí el Truco Argentino, ya que me resultó interesante y desafiante la idea de traducir a código la complejidad de opciones que maneja cada jugador turno a turno y cómo éstas se ven afectadas por las decisiones de su contrincante.

En resumen, estamos ante una aplicación de escritorio de Windows Forms que simula un lobby en el que se puede generar un número indeterminado de salas o mesas en cada cual se juega una partida independiente de dicho juego.

A su vez, esta cuenta con algunas estadísticas históricas que hacen un poco de excusa para aplicar distintos métodos de persistencia de datos vistos en la cursada.

La solución está implementada en C# y Net Core 5.0, utilizando base de datos MS SQL para la persistencia de datos. 

Los archivos de base de datos se encuentran en el subdirectorio 

```sh
\Mahafud.Joel.TP2\InterfazGrafica\bin\Debug\net5.0-windows\Truco_db.mdf
\Mahafud.Joel.TP2\InterfazGrafica\bin\Debug\net5.0-windows\Truco_db_log.ldf
```

Así también un archivo generado en .txt y archivos de serialización en formato XML y JSON.

```sh
\Mahafud.Joel.TP2\InterfazGrafica\bin\Debug\net5.0-windows\Historial_De_Flores.json
\Mahafud.Joel.TP2\InterfazGrafica\bin\Debug\net5.0-windows\Historial_de_manos.XML
\Mahafud.Joel.TP2\InterfazGrafica\bin\Debug\net5.0-windows\Historial_De_Pardas.txt
```

#### Cabe mencionar que para que la funcionalidad de lectura y escritura de base de datos funcione correctamente se debe estar corriendo de forma local un servidor SQL con la base provista montada.

En mi caso utilicé SQL 2019 developer edition.

El diagrama de clases utilizado es el siguiente:

# /* Acá insertaré captura del diagrama una vez finalizado */




### Justificación técnica:

A lo largo de su desarrollo, la solución implementa diferentes conceptos del lenguaje C# en un entorno .Net vistos en la segunda mitad de la cursada. Estos son:

## Temas obligatorios:

### ○ SQL
Se implementa persistencia de datos a través de base de datos en SQL. (Utilizado para guardar historial de datos de partidas finalizadas).

### ○ Manejo de excepciones
Se cuenta con una clase derivada de Exception para lanzar excepciones personalizadas, así como lógicas try - catch - finally según corresponda en segmentos de código propensos a arrojar excepciones.

### ○ Unit Testing
Se incluyen pruebas unitarias varias.

### ○ Generics
Se implementa una clase Serialización de tipo genérica, con métodos genéricos. Este formato de diseño permite la serialización de cualquier tipo de objeto que reciban.

### ○ Serialización
Se realiza Serialización y deserialización tanto en formato XML como JSON. Se utiliza para el guardado de distintos tipos de estadísticas históricas adicionales.

### ○ Escritura de archivos
Se utiliza escritura y lectura de archivos. Se utiliza tanto para el guardado de los datos serializados en JSON, como en guardado de archivos de formato .txt común. Nuevamente guardando estadísticas históricas.




## Temas Opcionales:

### ○ Interfaces
Se implementa una interfaz para definir métodos de firma y nombre idéntico que realizan diferentes acciones según la clase de la que son miembros.

### ○ Delegados
Se implementa un delegado personalizado de tipo Action que trabaja con un evento propio.

### ○ Task
Se generan subprocesos en cada instancia del formulario que cumple el rol de mesa o partida. Esto permite agregar una funcionalidad de reloj que se actualiza en tiempo real sin tomar el hilo principal del programa.

### ○ Eventos
Se lanza evento personalizado que está asociado a su vez con el delegado que se diseñó.



## Reflexiones finales:
Este desarrollo me ayudó a poner en práctica muchos conceptos que venía incorporando a lo largo de la cursada, así como afianzar conocimientos e incentivarme a investigar también por mi cuenta.

Si bien en cuanto a interfaz gráfica y diseño de experiencia al usuario se puede mejorar mucho, me enfoqué principalmente en que el código respondiera a lo que sería una partida real de truco con toda la lógica que ello implica por detrás, y debo decir que fue un gran desafío, pero estoy conforme con el resultado.
