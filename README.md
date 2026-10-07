# GNSSTATION

Aplicación para manipulación de datos GNSS en formato estandar RINEX 2.11, principal fuente de emisión: INEGI referente a la red geodésica nacional.

bitacora de eventos:

**[1]** Ejecuta aplicación UNERINEXv6.0.<br>
**[2]** Muestra los datos de muestreo de satelites (gps y galileo), genera documentos .gnss y .png resumen de avistamientos de constelación satelital.<br>
**[3]** Muestra lista de paginas web o servidores sftp y ejecuta aplicación FileZilla.<br>

Compatibilidad comprobada en linux.<br>
Compatible con software UNERINEXv6.0, y FileZilla.<br>
Necesario identificar la ruta para cada software dentro de la ruta de la aplicación principal:<br>
```
/scripts/sftp/FileZilla3
/scripts/UNERINEXV60
```
Esta aplicación presenta una marco de aplicación dentro de la identificación de el funciónamiento de una estación satelital por estado, de modo que al realizar la identificación de cada estación de el pais es posible generar un conjunto estadístico de los satelites dentro de las orbitas terrestres.
Se plante en el código la definiciones de las variables respectivas para cada satelite iniciando con ello el preámbulo para el cálculo de coordenadas de cada satelite (aún en desarrollo)
