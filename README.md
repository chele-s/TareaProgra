# Sistema Gestor Modular de Inventario y Ventas

### Universidad Don Bosco — Facultad de Estudios Tecnológicos / Escuela de Computación
**Asignatura:** Programación Estructurada (PRE104)  
**Ciclo Academicó:** 02-2026  
**Fase de Entrega:** Fase 1 — Primer Avance  

---

## 1. Descripción del Proyecto

Sistema en consola desarrollado en **C# (.NET 8.0)** orientado a la gestión comercial de una tienda de productos para mascotas. El sistema implementa persistencia secuencial de datos mediante archivos de texto plano, modularidad estricta mediante subprogramas y estructuras de datos (`struct`).

En esta primera fase se establece la infraestructura básica de datos, lectura e interacción con el archivo `inventario.txt`, navegación del menú interactivo y la gestión resiliente de excepciones de entrada y apertura de archivos.

---

## 2. Arquitectura de Módulos y Distribución de Trabajo

El proyecto está diseñado bajo una arquitectura modular en un solo compilable. Cada integrante del equipo tiene a su cargo funciones específicas dentro de `Program.cs`:

| Módulo | Ámbito Técnico | Funciones Asignadas | Integrante Responsable |
| :--- | :--- | :--- | :--- |
| **Módulo 1** | Infraestructura de Datos y Archivos | Definición de `struct Producto`, lectura de `inventario.txt` (`EOF`) y función `MostrarInventario()`. | Integrante 1 |
| **Módulo 2** | Menú e Interfaz de Navegación | Control de flujo principal (`do-while`), visualización del menú en `MostrarMenu()` y flujo `switch-case`. | Integrante 2 |
| **Módulo 3** | Validaciones y Control de Búfer | Prevención de excepciones por texto inválido en `LeerOpcionValida()`, `ValidarPrecio()` y `ValidarCantidad()`. | Integrante 3 |
| **Módulo 4** | Operaciones de Inventario | Prototipos y desarrollo de lógica funcional para `AgregarProducto()` y `VenderProducto()`. | Integrante 4 |
| **Módulo 5** | Integración y Documentación | Revisión de compilación limpia, estándares de código y preparación del documento institucional de entrega. | Integrante 5 |

---

## 3. Estructura del Repositorio

```text
TareaProgra/
│
├── Program.cs              # Código fuente principal con menú y funciones del sistema
├── TareaProgra.csproj      # Configuración del proyecto en .NET 8.0 / Visual Studio
├── inventario.txt          # Archivo de persistencia de datos (10 productos iniciales)
├── .gitignore              # Configuración de exclusión de artefactos de compilación
└── README.md               # Documentación general del proyecto
```

---

## 4. Especificación Técnica de la Estructura de Datos

El sistema define la estructura principal `Producto` para la representación en memoria de los ítems del inventario:

```csharp
public struct Producto
{
    public int Id;
    public string Nombre;
    public float Precio;
    public int Cantidad;
}
```

### Formato del Archivo de Persistencia (`inventario.txt`)
Los registros se almacenan en formato de valores separados por comas (`CSV`):
`ID,Nombre_Producto,Precio_Unitario,Cantidad_Stock`

Ejemplo de estructura de datos precargada:
```text
101,Concentrado Perro 10kg,24.99,15
102,Collar Antipulgas Gato,8.50,30
103,Champu para Mascotas 500ml,6.75,20
```

---

## 5. Instrucciones de Compilación y Ejecución

### Requisitos Previos
- **.NET SDK 8.0** o superior instalado en el sistema, O bien
- **Visual Studio 2022** con la carga de trabajo *Desarrollo de escritorio de .NET*.

### Opción A: Mediante la CLI de .NET
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/chele-s/TareaProgra.git
   cd TareaProgra
   ```
2. Compilar el proyecto:
   ```bash
   dotnet build
   ```
3. Ejecutar la aplicación:
   ```bash
   dotnet run
   ```

### Opción B: Mediante Visual Studio
1. Abrir **Visual Studio**.
2. Seleccionar `Abrir un proyecto o una solución`.
3. Navegar hacia la carpeta del proyecto y seleccionar `TareaProgra.csproj`.
4. Ejecutar presionando la tecla `F5` o mediante el botón de reproducción `Iniciar`.

---

## 6. Criterios de Calidad Implementados

- **Robustez de Archivos:** Apertura mediante bloques `try-catch` y validaciones previas de existencia (`File.Exists`), previniendo colapsos de sistema.
- **Validación de Búfer:** Limpieza implícita del canal de lectura con reintentos controlados para entradas inválidas.
- **Alineación Visual:** Formateo tabular alineado a la izquierda mediante especificaciones de formato de cadenas en C#.
