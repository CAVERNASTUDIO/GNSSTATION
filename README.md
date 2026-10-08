# GNSSTATION

 - Aplicación para manipulación de datos GNSS en formato estandar RINEX 2.11.
 - Principal fuente de emisión de datos Rinex 2.11: INEGI (Red Geodésica Nacional).

bitácora de eventos:

**[1]** Ejecuta aplicación UNERINEXv6.0.<br>
**[2]** Muestra los datos de muestreo de satélites (cantidad de veces que un satélite identificado transmitió señal de registro con la estación RGNA) a partir de los formatos galileo y gps emitidos por aplicación UNERINEXv6.0, genera documentos .gnss y .png resumen de avistamientos de constelación satelital en gráfica y tabla.<br>
**[3]** Muestra lista de páginas web o servidores sftp accesibles desde aplicación FileZilla y ejecuta aplicación FileZilla.<br>

Compatibilidad comprobada en linux.<br>
Compatible con software UNERINEXv6.0, y FileZilla.<br>
Necesario identificar la ruta para cada software dentro de la ruta de la aplicación principal:<br>
```
/scripts/sftp/FileZilla3
/scripts/UNERINEXV60
```
Esta aplicación presenta una marco de aplicación dentro de la identificación de el funciónamiento de una estación satelital para datos GNSS por estado, de modo que al realizar la identificación de cada estación de el pais es posible generar un conjunto de datos estadístico de los satélites dentro de las órbitas terrestres sobre el área nacional.
Se plantea en el código la definiciones de las variables respectivas para cada satelite iniciando con ello el preámbulo para el cálculo de coordenadas de cada satelite (aún en desarrollo)
