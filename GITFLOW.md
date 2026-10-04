# GitFlow aplicado al proyecto

Durante la práctica se utilizará Git para mantener el historial del proyecto y GitFlow como modelo de organización de las ramas.

El objetivo es separar el desarrollo de cada funcionalidad y mantener una versión estable del proyecto.

---

# 1. Preparación del repositorio

Antes de realizar el primer commit, comprobar que el proyecto contiene un archivo `.gitignore`.

## 1.1. .gitignore

El archivo `.gitignore` indica qué archivos y carpetas no deben añadirse al repositorio.

En un proyecto .NET no deben versionarse los archivos generados durante la compilación ni los archivos propios del entorno de desarrollo.

Como mínimo, deberán excluirse:

```gitignore 
bin/
obj/
.vs/
```

Si se utiliza Rider:

```gitignore 
.idea/
```

El repositorio debe contener el código fuente y los archivos necesarios para reconstruir el proyecto, no los archivos generados durante la compilación.

Una estructura correcta podría ser:

```text 
Restaurante/
├── .gitignore
├── Restaurante.sln
├── Restaurante/
│   ├── Restaurante.csproj
│   ├── Program.cs
│   ├── Producto.cs
│   ├── Bebida.cs
│   ├── Postre.cs
│   └── ...
```

No deberían aparecer en el repositorio:

```text 
bin/
obj/
.vs/
.idea/
```

Antes de realizar el primer commit:

```bash 
git status
```

Revisar los archivos detectados por Git.

Si aparecen carpetas como `bin`, `obj`, `.vs` o `.idea`, revisar el `.gitignore` antes de continuar.

Añadir una carpeta al `.gitignore` no elimina automáticamente archivos que ya hayan sido añadidos anteriormente al repositorio.

Por este motivo, el `.gitignore` debe configurarse antes del primer commit.

---

## 1.2. Inicialización

Si el proyecto todavía no utiliza Git:

```bash 
git init
```

Comprobar el estado:

```bash 
git status
```

Realizar el primer commit:

```bash 
git add .
git commit -m "Proyecto inicial del restaurante"
```

Volver a comprobar:

```bash 
git status
```

El repositorio debería quedar sin cambios pendientes.

---

# 2. Ramas principales

Durante el desarrollo se utilizarán dos ramas principales:

```text 
main
develop
```

## main

Contiene las versiones estables del proyecto.

No se desarrollarán funcionalidades directamente en esta rama.

## develop

Contiene el estado actual del desarrollo.

Las funcionalidades terminadas se integrarán en esta rama.

Si todavía no existe:

```bash 
git switch -c develop
```

El flujo general será:

```text 
feature/* ──────┐
feature/* ──────┼──> develop ──> main
feature/* ──────┘
```

---

# 3. Ramas de funcionalidad

Cada funcionalidad se desarrollará en una rama independiente.

Las ramas utilizarán el prefijo:

```text 
feature/
```

Por ejemplo:

```text 
feature/entrantes
feature/carta
feature/menu
feature/pedidos
```

Las ramas deben representar funcionalidades, no ejercicios.

Evitar nombres como:

```text 
feature/ejercicio-1
feature/ejercicio-2
feature/ejercicio-3
```

Por ejemplo, los ejercicios relacionados con mostrar la carta, numerar productos, buscar productos o filtrar por precio pueden formar parte de:

```text 
feature/carta
```

---

# 4. Crear una feature

Antes de comenzar una nueva funcionalidad, volver a `develop`:

```bash 
git switch develop
```

Si se trabaja con un repositorio remoto:

```bash 
git pull
```

Crear la nueva rama:

```bash 
git switch -c feature/carta
```

Comprobar la rama actual:

```bash 
git branch
```

El desarrollo de la funcionalidad se realizará en esta rama.

---

# 5. Commits durante el desarrollo

No se realizará un único commit al terminar toda la práctica.

Los commits deben representar cambios concretos realizados durante el desarrollo.

Por ejemplo:

```bash 
git add .
git commit -m "Añadida carta de productos"
```

Después:

```bash 
git add .
git commit -m "Añadida numeración de productos"
```

Y posteriormente:

```bash 
git add .
git commit -m "Añadido filtro de productos por precio"
```

Antes de realizar un commit puede utilizarse:

```bash 
git status
```

para comprobar los archivos modificados.

También puede utilizarse:

```bash 
git diff
```

para revisar los cambios realizados.

---

# 6. Mensajes de commit

Los mensajes deben indicar qué cambio se ha realizado.

Ejemplos:

```text 
Añadida clase Entrante
Añadida carta de productos
Añadida búsqueda de productos
Añadida validación con TryParse
Añadido menú principal
Añadida gestión de pedidos
Corregida validación al eliminar productos
```

Evitar mensajes como:

```text 
Cambios
Cosas
Commit
Práctica
Terminado
Final
```

El historial puede consultarse con:

```bash 
git log --oneline
```

El historial debería permitir entender cómo ha evolucionado el proyecto.

---

# 7. Finalizar una feature

Cuando una funcionalidad esté terminada, comprobar primero que el proyecto funciona correctamente.

Revisar:

```bash 
git status
```

No debería haber cambios pendientes.

Volver a `develop`:

```bash 
git switch develop
```

Si existe repositorio remoto:

```bash 
git pull
```

Integrar la funcionalidad:

```bash 
git merge feature/carta
```

Si la integración es correcta, eliminar la rama local:

```bash 
git branch -d feature/carta
```

En este momento la funcionalidad ya forma parte de `develop`.

---

# 8. Comenzar la siguiente funcionalidad

Las nuevas ramas deberán crearse siempre desde `develop`.

Por ejemplo:

```bash 
git switch develop
git switch -c feature/menu
```

En esta rama podrían desarrollarse:

- Menú principal.
- Lectura de opciones.
- `switch`.
- Validación mediante `TryParse`.
- Separación de las opciones en métodos.

Cuando la funcionalidad esté terminada:

```bash 
git switch develop
git merge feature/menu
git branch -d feature/menu
```

---

# 9. Organización de las ramas de la práctica

Una posible organización sería:

```text 
main
 |
 +-- develop
      |
      +-- feature/entrantes
      |
      +-- feature/carta
      |
      +-- feature/menu
      |
      +-- feature/pedidos
```

No es obligatorio utilizar exactamente estos nombres.

La división deberá tener sentido según las funcionalidades desarrolladas.

No es necesario crear una rama diferente para cada ejercicio.

---

# 10. Desarrollo de pedidos

Para comenzar la gestión de pedidos:

```bash 
git switch develop
git switch -c feature/pedidos
```

Durante el desarrollo pueden realizarse varios commits:

```text 
Añadida colección de productos al pedido
Añadida opción para añadir productos
Añadida visualización del pedido
Añadida eliminación de productos
Añadida finalización del pedido
```

Una vez terminada la funcionalidad:

```bash 
git switch develop
git merge feature/pedidos
git branch -d feature/pedidos
```

---

# 11. Publicar la versión

Cuando la versión esté preparada:

```bash 
git switch main
git merge develop
```

Crear una etiqueta para identificar la versión:

```bash 
git tag v1.0.0
```

El resultado será:

```text 
feature/* ──> develop ──> main
```

---

# 12. Repositorio remoto

Si se utiliza GitHub, GitLab u otro repositorio remoto, las ramas pueden publicarse durante el desarrollo.

La primera vez que se publica `develop`:

```bash 
git push -u origin develop
```

Para publicar una feature:

```bash 
git push -u origin feature/carta
```

Después de configurar la relación con la rama remota:

```bash 
git push
```

Cuando se publique la versión final:

```bash 
git push origin main
git push origin develop
git push origin --tags
```

---

# 13. Flujo habitual de trabajo

## Crear una funcionalidad

```bash 
git switch develop
git pull
git switch -c feature/nombre-funcionalidad
```

## Trabajar

```bash 
git status
git add .
git commit -m "Descripción del cambio"
git push
```

Pueden realizarse varios commits mientras se desarrolla la funcionalidad.

## Integrar

```bash 
git switch develop
git pull
git merge feature/nombre-funcionalidad
git push
```

## Comenzar otra funcionalidad

```bash 
git switch develop
git switch -c feature/otra-funcionalidad
```

---

# 14. Qué debe evitarse

No desarrollar directamente sobre:

```text 
main
```

Evitar crear una rama por cada ejercicio:

```text 
feature/ejercicio1
feature/ejercicio2
feature/ejercicio3
```

Evitar realizar toda la práctica en un único commit:

```text 
Práctica terminada
```

Evitar mensajes de commit que no expliquen el cambio realizado.

Evitar mezclar funcionalidades independientes en la misma rama sin necesidad.

Evitar crear una nueva `feature` partiendo de otra `feature`. Las nuevas funcionalidades deben comenzar desde `develop`.

---

# 15. Entrega del proyecto

La entrega incluirá:

1. Enlace al repositorio Git.
2. Archivo `.zip` con el proyecto final.

El repositorio deberá conservar el historial de commits y las ramas utilizadas durante el desarrollo.

El archivo ZIP contendrá el código necesario para abrir, compilar y ejecutar el proyecto.

Antes de crear el ZIP deberán eliminarse las carpetas generadas que no forman parte de la entrega:

```text 
bin/
obj/
.vs/
.idea/
.git/
```

No debe eliminarse el archivo:

```text 
.gitignore
```

El ZIP deberá conservar los archivos necesarios del proyecto, entre ellos:

```text 
.gitignore
*.sln
*.csproj
*.cs
```

La carpeta `.git/` no debe incluirse en el ZIP. Esta carpeta contiene internamente el repositorio y su historial, que ya se entregan mediante el enlace al repositorio remoto.

El archivo `.gitignore`, en cambio, sí forma parte del proyecto y debe incluirse.

Antes de entregar, comprobar que el proyecto incluido en el ZIP puede abrirse y compilarse correctamente.

---

# 16. Comprobación final

Antes de entregar, revisar:

- Existe un archivo `.gitignore`.
- `bin`, `obj`, `.vs` e `.idea` no están versionados.
- Existe una rama `main`.
- Existe una rama `develop`.
- Se han utilizado ramas `feature/*`.
- Las ramas representan funcionalidades y no ejercicios individuales.
- Se han realizado varios commits durante el desarrollo.
- Los mensajes de commit describen los cambios realizados.
- No se ha desarrollado directamente en `main`.
- Las funcionalidades terminadas se han integrado en `develop`.
- La versión estable se encuentra en `main`.
- Existe la etiqueta `v1.0.0`.
- El proyecto compila y funciona correctamente.
- Se entrega el enlace al repositorio.
- Se entrega el proyecto en formato ZIP.
- El ZIP no contiene `bin`, `obj`, `.vs`, `.idea` ni `.git`.

---

# Resumen

| Rama | Uso |
|---|---|
| `main` | Versiones estables |
| `develop` | Desarrollo integrado |
| `feature/*` | Desarrollo de funcionalidades |
| `hotfix/*` | Correcciones urgentes sobre una versión publicada |

Para esta práctica se utilizarán principalmente:

```text 
main
develop
feature/*
```

Flujo general:

```text 
main
  ↑
develop
  ↑
feature/*
```