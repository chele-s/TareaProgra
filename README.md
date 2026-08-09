# Sistema Gestor Modular de Inventario y Ventas (Tienda de Mascotas)

Proyecto de Cátedra - **Fase 1 (Primer Avance)**  
**Universidad Don Bosco - Escuela de Computación**  
**Asignatura:** Programación Estructurada (PRE104) - Ciclo 02-2026  

---

## Estructura del Proyecto C#

```text
TareaProgra/
├── TareaProgra.csproj      # Archivo de proyecto .NET / Visual Studio
├── Program.cs              # Código fuente principal
├── inventario.txt          # Archivo de texto con datos de prueba (10 productos)
├── .gitignore              # Archivo de exclusión para Git/GitHub
└── README.md               # Documentación y guía de colaboración
```

---

## Distribución de Submódulos por Integrante

1. **Integrante 1 (Manejo de Archivos e Infraestructura de Datos)**:
   - Definición de `struct Producto`.
   - Función `MostrarInventario()` con lectura de `inventario.txt`, control de fin de archivo (`EOF`) y formato tabular de consola.
   - Manejo de excepciones de apertura sin colapsar el programa.

2. **Integrante 2 (Menú Principal e Interfaz de Navegación)**:
   - Control de flujo principal (`do-while`) y `switch-case` navegable (opciones 1 a 4).

3. **Integrante 3 (Validación de Entradas y Manejo de Errores)**:
   - Validación de entradas del menú (aceptar únicamente números enteros 1-4).
   - Control de errores para evitar bucles infinitos ante texto no numérico.
   - Métodos auxiliares `ValidarPrecio()` y `ValidarCantidad()`.

4. **Integrante 4 (Prototipos y Funciones Dummy)**:
   - Prototipos de funciones vacías `AgregarProducto()` y `VenderProducto()`.
   - Mensaje estandarizado *"Módulo a cargo de [Nombre del Estudiante]"*.

5. **Integrante 5 (Integración, Documentación y Portada)**:
   - Integración final y aseguramiento de compilación limpia.
   - Elaboración de la Portada Institucional en el documento PDF de entrega.

---

## Cómo Compilar y Ejecutar

### Opción A: Desde Visual Studio
1. Abrir Visual Studio.
2. Seleccionar `Abrir un proyecto o una solución` y seleccionar `TareaProgra.csproj`.
3. Presionar `F5` o el botón `Iniciar`.

### Opción B: Desde Consola / Terminal (.NET CLI)
```bash
dotnet build
dotnet run
```
