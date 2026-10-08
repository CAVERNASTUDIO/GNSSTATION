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
Esta aplicación presenta una marco de aplicación dentro de la identificación de el funciónamiento de una estación satelital para datos GNSS por estado, de modo que al realizar la identificación de cada estación de el pais es posible generar un conjunto de datos estadístico de los satélites dentro de las órbitas terrestres sobre el área nacional.<br>
Se plantea en el código la definición de las variables respectivas para cada transmisión de satélite, preámbulo para el cálculo de coordenadas de cada satélite (aún en desarrollo).

MATRIZ DE DATOS GALILEO Y GPS Formato RINEX 2.11:

**GPS:** <br>

$$ 
\begin{bmatrix} \text{PRN} & \text{Año} & \text{Mes} & \text{Día} & \text{Hora} & \text{Min} & \text{Sec} & a_0 & a_1 & a_2 \\
\text{IODE} & C_{rs} & \Delta n & M_0 \\ 
C_{uc} & e & C_{us} & \sqrt{A} \\ 
t_{oe} & C_{ic} & \Omega_0 & C_{is} \\ 
i_0 & C_{rc} & \omega & \dot{\Omega} \\ 
\dot{i}\text{ (IDOT)} & \text{Códigos L2} & W_N & \text{Flag Data L2 P} \\ 
\text{Precisión SV} & \text{Salud SV} & \text{TGD} & \text{IODC} \\
\text{Tiempo Transmisión} & \text{Fit Interval} & \text{Spare}_2 & \text{Spare}_3 \end{bmatrix} 
$$

**GALILEO:** <br>

$$
\begin{bmatrix} \text{PRN} & \text{Año} & \text{Mes} & \text{Día} & \text{Hora} & \text{Min} & \text{Sec} & a_0 & a_1 & a_2 \\ 
\text{IODE} & C_{rs} & \Delta n & M_0 \\ 
C_{uc} & e & C_{us} & \sqrt{A} \\
t_{oe} & C_{ic} & \Omega_0 & C_{is} \\ 
i_0 & C_{rc} & \omega & \dot{\Omega} \\ 
\dot{i}\text{ (IDOT)} & \text{Data Src} & W_N & \text{Spare}_1 \\ 
\text{SISA} & \text{Health} & \text{BGD}_{E5a/E1} & \text{BGD}_{E5b/E1} \\ 
t_{tm} & \text{Spare}_2 & \text{Spare}_3 & \text{Spare}_4 \end{bmatrix} 
$$


**Estandar RINEX:**
El formato RINEX (Receiver Independent Exchange Format) es el estándar universal que permite la interoperabilidad de datos geodésicos sin importar la marca del hardware. [1] 
(https://www.comnavtech.com/sp/about/blogs/647.html), [2] 
(https://translate.google.com/translate?u=https://www.earthdata.nasa.gov/about/esdis/esco/standards-practices/rinex&hl=es&sl=en&tl=es&client=sge)
Los dispositivos capaces de recolectar datos brutos de posicionamiento se dividen en aquellos que generan RINEX de forma nativa y aquellos que graban en formatos propietarios (binarios) que requieren un software de conversión (habitualmente provisto por el mismo fabricante o mediante herramientas web integradas). [1] (https://www.youtube.com/watch?v=J7ddH5yN1Y8&t=672), [2] (https://www.youtube.com/watch?v=bO4Fltk6bHM)

