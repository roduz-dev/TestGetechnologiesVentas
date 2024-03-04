Test Software Developer

Crear un proyecto.

Hacer referencia al patrón de diseño  Repository Design Pattern

DirectorioRestService: Componente que expone el servicio REST.
Directorio: Servicio de negocio con el objetivo de gestionar la información de personas (almacenar, buscar, borrar), el borrado de una persona elimina todos los datos de una persona incluso su facturacion.
Ventas: Servicio de negocio con el objetivo de gestionar la información de facturacion (almacenar, buscar),
Persona: Clase del modelo de dominio, que representa a una persona.
Factura: Clase del modelo de dominio, que representa las facturas de un persona.
PersonaRepository: Componente encargado ( Repository Design Pattern ) de la interacción del datasource para obtener, reconstruir los datos de las personas.
FacturaRepository: Componente encargado ( Repository Design Pattern )  de la interacción del datasource para obtener, reconstruir los datos de las facturas.

Todos los atributos de la clase Persona son obligatorios para persistir el objeto excepto apellidoMaterno.

Utilizar una base de datos embebida como h2 o la que desees para el ejercicio.

Como plus puedes agregar logger para mostrar en consola la información 

Realiza un cliente para la API anteriormente creada en el paso 1 y 2 , tomando en cuenta las tecnologías mencionadas en la sección de herramientas. Puedes utilizar el framework de estilos que prefieras o bien, crear tus propios estilos.

El objetivo es registrar usuarios en el sistema.

Valida los datos que son obligatorios (nombre,ApellidoPaterno,identificación), mostrar mensaje al usuario si no los ha ingresado, de forma reactiva sería excelente.
