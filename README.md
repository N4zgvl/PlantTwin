# 📘 README –  PlantTwin

Sistema de monitoreo y simulación de planta industrial (Digital Twin)
Proyecto académico – Instituto Tecnológico de Tijuana

## 📌 Descripción general

**PlantTwin** es una aplicación web desarrollada con **C# y ASP.NET Core MVC** que simula el funcionamiento de una línea de producción industrial mediante un **Clon Digital (Digital Twin)**.

El sistema permite simular de forma virtual:

* Encendido y apagado de maquinaria.
* Visualización de parámetros como temperatura, presión y RPM.
* Estados de operación (Operativo, Mantenimiento, Error, Apagado).
* Registro histórico de eventos.
* Proyección de comportamientos según variables de entrada.

---

## 🎯 Objetivos del proyecto

* Aplicar el patrón **MVC (Model-View-Controller)** correctamente.
* Refactorizar código con **malas prácticas intencionales**.
* Aplicar **Patrones de Diseño GoF**.
* Simular el comportamiento realista de máquinas industriales.
* Separar lógica de negocio de controladores y vistas.
* Implementar concurrencia segura (sin `Thread.Sleep` en controladores).

---

## 🏗️ Tecnologías utilizadas

| Categoría    | Tecnología                |
| ------------ | ------------------------- |
| Lenguaje     | C#                        |
| Framework    | ASP.NET Core MVC (.NET 8) |
| Arquitectura | MVC + Servicios           |
| Frontend     | HTML5, CSS3, Chart.js     |
| IDE          | Visual Studio 2022        |

---

## 🧠 Patrones de diseño aplicados

| Patrón         | Tipo           | Aplicación en el proyecto                                              |
| -------------- | -------------- | ---------------------------------------------------------------------- |
| State          | Comportamiento | Manejo de estados de máquina (Apagada, Operando, Falla, Mantenimiento) |
| Observer       | Comportamiento | Notificación de cambios de estado de las máquinas                      |
| Strategy       | Comportamiento | Diferentes lógicas de simulación por tipo de máquina                   |
| Command        | Comportamiento | Acciones como Encender, Apagar, Reiniciar                              |
| Factory Method | Creacional     | Creación de máquinas con `MachineFactory`                              |
| Prototype      | Creacional     | Clonación de máquinas para simulaciones                                |

---

## ⚠️ Problemas detectados en la versión original (código base entregado)

La versión inicial del proyecto contenía los siguientes **code smells** intencionales:

* Toda la lógica concentrada en `PlantaController.cs`.
* Uso de `Thread.Sleep()` dentro de controladores.
* Estados de máquinas manejados con `bool[]`.
* Valores de sensores hardcodeados.
* Sin interfaces para sensores ni máquinas.
* Sin separación de capas (SRP violado).
* Parámetros pasados por URL entre vistas.
* Colisiones en simulaciones concurrentes.
* Código duplicado al agregar nuevas máquinas.

---

## 🧹 Refactorización realizada

Durante el desarrollo se corrigieron los problemas:

✅ Separación de capas (Controllers → Services → Models)
✅ Implementación de interfaces (`IMachine`, `ISensor`)
✅ Uso de `async/await` en lugar de `Thread.Sleep`
✅ Implementación de patrones GoF
✅ Uso de ViewModels para las vistas
✅ Manejo de concurrencia seguro
✅ Registro centralizado de eventos

---

## 📂 Estructura del proyecto

```bash
PlantTwin/
│
├── Controllers/
│   ├── PlantController.cs
│   ├── HistoryController.cs
│   ├── SettingsController.cs
│   └── SimulationsController.cs
│
├── Models/
│   ├── MachineModel.cs
│   ├── SensorModel.cs
│   └── EventHistoryModel.cs
│
├── Services/
│   ├── MachineSimulatorService.cs
│   ├── MachineFactory.cs
│   └── EventLoggerService.cs
│
├── ViewModels/
│   └── ControlPanelViewModel.cs
│
├── Views/
│   ├── Plant/
│   ├── History/
│   ├── Settings/
│   └── Simulations/
```

---

## 🖥️ Funcionalidades del sistema

### 📊 Dashboard (Panel de control)

* Visualización de máquinas.
* Estados en tiempo real.
* Variables simuladas (Temperatura, Presión, RPM).

### 📜 Historial

* Registro de eventos (encendido, apagado, fallas, mantenimientos).
* Fecha y hora de cada evento.

### ⚙ Configuración

* Ajuste de valores límite.
* Parametrización de sensores simulados.

### 🧪 Simulaciones

* Generación de fallos controlados.
* Simulación de mantenimiento.
* Proyección de comportamientos futuros.

---

## ▶️ Instalación y ejecución local

### 1️⃣ Clonar el repositorio

```bash
git clone https://github.com/N4zgvl/PlantTwin.git
```

### 2️⃣ Restaurar dependencias

```bash
dotnet restore
```

### 3️⃣ Ejecutar la aplicación

```bash
dotnet run
```

Abrir en el navegador:

```
https://localhost:5001
```

---

## 🧪 Concurrencia y simulación segura

* Uso de `Task.Run()` y `async/await`
* Eliminación de `Thread.Sleep()` en los controladores
* Simulaciones desacopladas mediante servicios

---

## 👨‍💻 Autor

**Nombre:** José Guadalupe Rodríguez Sastre
**Carrera:** Ingeniería en Informática
**Institución:** Instituto Tecnológico de Tijuana

---

## 📄 Licencia

Proyecto de uso académico bajo licencia **MIT**.
