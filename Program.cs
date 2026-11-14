abusing System.Diagnostics;
/* 
            EQUIPO LOS 3 MOSQUETEROS GNSS
=====================================================
ESTACIÓN DE MONITOREO Y ANÁLISIS DE DATOS GNSS(EMADG)
=====================================================
                                                  AEM
                                   CREDES - Zacatecas
=====================================================
EQUIPO LOS 3 MOSQUETEROS
=====================================================
- 
- 
- Erik Alejandro García Aparicio.
=====================================================
*/

interfacestationGNSS();

void interfacestationGNSS()
{
    string menu="";
    bool continua = true;

    while(continua==true)
    {
        
        Console.Clear();
        Console.WriteLine("===================================\n\nESTACIÓN DE MONITOREO Y ANÁLISIS DE DATOS GNSS\n\n===================================");
        Console.WriteLine("1. Unerinex.");
        Console.WriteLine("2. Identificador de Señales");
        Console.WriteLine("3. Servidores SFTP");
        Console.WriteLine("Selección de Opción (1-3), \"i\" para ver información o \"e\" para salir" );
        string respuesta = Console.ReadLine();

        if (respuesta!= null)
        {
            menu=respuesta;
        }

        switch (menu)
        {
            default:
            Console.WriteLine("Opción no válida, intente nuevamente.\n\nPresiona \"enter\" para continuar");
            Console.ReadLine();
            break;
            
            case "1":
            try
            {
                unerinex();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Es necesario añadir el software al directorio\n{ex}");
                Console.ReadLine();
            }
            break; 
            
            case "2":
            Console.Clear();
            Console.WriteLine("================================\nLista de señales GNSS\n================================\n");
            try
            {
                formato();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Formato no compatible o documento inexistente\n{ex.Message}");
                Console.ReadLine();
            }
            break;

            case "3":
            Console.Clear();
            Console.WriteLine("================================\nLista de servidores SFTP\n================================\n");
            listaServidores();
            try
            {
                servidoressftp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Es necesario instalar o/e integrar el software dentro de el directorio compatible\n{ex}");
                Console.ReadLine();
            }
            break; 
            
            case "i":
            Console.Clear();
			Console.WriteLine("================================\nGlobal Navigation Satellite System\n================================\n");
            Console.WriteLine("Aplicación prototipo para concurso:\n\n Hackathon en línea AEM\n \"HackAEMthonGNSS 2026\"\n     by García Aparicio Erik Alejandro\n\n\nESTACIÓN DE MONITOREO Y ANÁLISIS DE DATOS GNSS Copyrigth (c) 2026 Erik Alejandro García Aparicio.\n\n\n Para presentar ante:\n\nAgencia de Transformación Digital y Telecomunicaciones\nAgencia Espacial Mexicana (AEM)\nCentro Regional de Desarrollo Espacial en el Estado de Zacatecas (CREDES - zacatecas)");
            Console.WriteLine("\n====================\nAVISO\n====================\n\n - Observación:\n1. Los datos descargados corresponden a datos accesibles públicamente, presentados por la institución INEGI de acceso gratuito; Es necesario identificar el modelo de dispositivo y formatos rinex usado por dispositivos privados o de uso restringido o cifrado y contar con acceso autorisado al material para su visualización así como contar con un formato estandar de compatibilidad adecuado para lectura y manipulación de datos.\nLos datos públicos accesibles se integran dentro de una tabla para identificarlos según la estandarización EGNOS que identifica canales públicos de datos GNSS\n2. UNERINEXv6.0: Aplicación presentada por institución INEGI, compatible con formatos RINEX 2.11 de el \"IGS (International GNSS Service) Formats and Standards\" que permite generar un documento por cada tipo de información GNSS contenida en un conjunto de documentos.\n3. FileZilla: Software para acceso a servidores remotos de bases de datos, manejado bajo la licencia de uso GPL.\n4. En caso de que un servidor remoto no identifica usuario y contraseña, visitar la pagina web.");
            Console.ReadLine();
            break; 
            
            case "e":
            Console.Clear();
            Console.WriteLine("============================================================");
            Console.WriteLine("\n\n  ESTACIÓN DE MONITOREO Y ANÁLISIS DE DATOS GNSS\n\n");
            Console.WriteLine("            Proyecto Scriptorium / Caverna Studio\n                            by Erik García.");
            Console.WriteLine("\n============================================================\n\n");
            Console.WriteLine("Copyright © 2026, García Aparicio Erik Alejandro.");
            Console.WriteLine("\n\nHerramientas Anexas:\nUNERINEXv6.0, Copyright © 2026, Instituto Nacional de Estadistica y Geografía\nArchivos RINEX de la Red Geodésica Nacional Activa, Copyright © 2026, Instituto Nacional de Estadística y Geografía\nFileZilla3, Copyright © 2004-2026, Tim Kosse.");
            Console.ReadLine();
            continua=false;
            break; 
        }
    }    
}

// UNERINEX, aplicación básica para manipulación de archivos estandarizados rinex emitidos por INEGI

void unerinex()
{
	
    string homeDrive = Environment.GetEnvironmentVariable("HOMEDRIVE");
    string ruta = $@"{homeDrive}\Windows";  
    Console.Clear();
    Console.WriteLine("=======================\nUNERINEX v6.0\n=======================\n\n");
        

    if (File.Exists(ruta))
    {
        string programbat = "@echo off\nTitle UNERINEX V6.0\ncd ./scripts/UNERINEXV60\njava -jar UNERINEXv6.0.jar\n pause";
        exeProgram(programbat);
    }
    else
    {
        string programpy = "import subprocess\njar_path = \"./scripts/UNERINEXV60/UNERINEXv6.0.jar\"\nproceso = subprocess.Popen([\"java\", \"-jar\", jar_path])\nproceso.wait()";
        pyProgram(programpy);
    }
}

// Código de ejecución de archivos .bat para automatización de windows y .py para automatización en linux

void pyProgram(string p_program)
{
    try
    {
        string texto = p_program;
        string ruta = "./scripts/estacionGNSS.py"; 
        bool documento = File.Exists(ruta);
    
        if (documento == true)
        {
          File.Delete(ruta);   
        }

        File.AppendAllText(ruta,texto);
        
        Process processo = Process.Start("python3", $"{ruta}");
        processo.WaitForExit();

        File.Delete(ruta);       
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error" + ex.Message);
    }
}

void exeProgram(string p_program)
{
    try
    {
        string texto = p_program;
        string ruta = "./scripts/estacionGNSS.bat"; 
        bool documento = File.Exists(ruta);
    
        if (documento == true)
        {
          File.Delete(ruta);   
        }

        File.AppendAllText(ruta,texto);
        
        Process proceso = Process.Start(ruta);
        proceso.WaitForExit();

        File.Delete(ruta);
            
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error" + ex.Message);
    }
}

// Cálculos para integrar un documento de reconocimento de salida para identificación de señales satelitales

void formato()
{
    Console.WriteLine("Ingresa la ruta de el documento:");
    string p_documento=Console.ReadLine();
            
    string documento = identificadorFormato(p_documento);

    if (documento == "galileo")
    {
        señalGalileo(p_documento,documento);
    }
    else if (documento == "gps")
    {
		señalGps(p_documento,documento); 
    }
    else if (documento == "observation")
    {
                    
    }
    else if (documento == "glonass")
    {
                    
    }
    else
    {
        Console.WriteLine("Documento no compatible");
        Console.ReadLine();
    }
}

string identificadorFormato(string p_archivo)
{
    string tipoFormato="";
    string[] documento = File.ReadAllLines(p_archivo);
    string[] formato = documento[0].Trim().Replace(" ",",").Split(',');
    int num = formato.Length;

    for (int i = 0; i <num; i++)
    {   

        if (formato[i] == "GLONASS")
        {
            tipoFormato = "glonass";

        }
        else if (formato[i] == "GALILEO")
        {
            tipoFormato = "galileo";
        }
        else if (formato[i] == "GPS")
        {
            tipoFormato = "gps";
        }
        else if (formato[i] == "OBSERVATION")
        {
            tipoFormato = "observation";
        }
    }
    return tipoFormato;
}

void señalGalileo(string p_archivo,string p_id)
{
   string[,] matrix = nuevaMatriz(p_archivo,8,5,p_id);
    string[] documentoRinex = File.ReadAllLines(p_archivo);
    string identificador = documentoRinex[0];
    int lineas = documentoRinex.Length;
    int def = (lineas-5)/8;
    int count=0;
    string[] identificadorSatelite = new string[def];

	count=0;
    for (int i = 5 ; i < lineas; i=i+8)
    {   
     identificadorSatelite[count] = documentoRinex[i].Substring(0,4).Trim().Replace(" ","0");
        count++;
    }
	
    List<string> constelacion = new List<string>(identificadorSatelite);
     IEnumerable<string> satelites = constelacion.Distinct();

    Console.Clear();
    Console.WriteLine("================================\nLista de señales GNSS\n================================\n");
    Console.WriteLine($"{identificador}\n");

    Console.WriteLine("Satélites en órbita reconocidos por la estación:");
	count=1;
    foreach (string satelite in satelites)
    {
        count++;
    }
	string[] satelitesGrafico = new string[count];
    
    count=0;
    foreach (string satelitedos in satelites)
    {
        satelitesGrafico[count++]=$"{satelitedos}";
    }
	Console.WriteLine($"\nNo. de avistamientos: {def}\nNo. de satélites detectados por estación: {count}");

    coordenadasSatelite(satelitesGrafico,matrix,def,documentoRinex,5,8,p_id);

    Console.ReadLine();
}

void señalGps(string p_archivo,string p_id)
{
    string[,] matrix = nuevaMatriz(p_archivo,8,7,p_id);
    string[] documentoRinex = File.ReadAllLines(p_archivo);
    string identificador = documentoRinex[0];
    int lineas = documentoRinex.Length;
    int def = (lineas-7)/8;
    int count=0;
    string[] identificadorSatelite = new string[def];
    
    count=0;
    for (int i = 7 ; i < lineas; i=i+8)
    {   
        identificadorSatelite[count] = documentoRinex[i].Substring(0,3).Trim().Replace(" ","0");
        
        count++;
    }
	
    List<string> constelacion = new List<string>(identificadorSatelite);
    IEnumerable<string> satelites = constelacion.Distinct();
    
    Console.Clear();
    Console.WriteLine("================================\nLista de señales GNSS\n================================\n");
    Console.WriteLine($"{identificador}\n");

    Console.WriteLine("Satélites en órbita reconocidos por la estación:");
	count=1;
    foreach (string satelite in satelites)
    {
        count++;
    }
    string[] satelitesGrafico = new string[count];

    count=0;
    foreach (string satelitedos in satelites)
    {
        satelitesGrafico[count++]=$"{satelitedos}";
    }

	Console.WriteLine($"No. de avistamientos: {def}\nNo. de satélites detectados por estación: {count}");

    coordenadasSatelite(satelitesGrafico,matrix,def,documentoRinex,7,8,p_id);

	Console.ReadLine();
}

string[,] nuevaMatriz(string p_path,int p_matrixSatellite, int p_linesOff,string p_id){
    // A partir de un arcihivo rinex crea una matriz exacta a el número de lineas * 5 renglones, el parametro 0 de la matriz se encuentra predeterminadamente vacio
    string[] documento = File.ReadAllLines(p_path);
    int def = (documento.Length-p_linesOff)/p_matrixSatellite;
    string[] matriz =  new string[documento.Length-p_linesOff];
    int count = 0;

    for (int i = p_linesOff; i < documento.Length; i++)
    {

        matriz[count] = documento[i].Trim().Replace(".",",.");
        matriz[count] = matriz[count].Replace("-,",",-");
        if (p_id=="gps")
        {
            matriz[count] = matriz[count].Replace(",.0 ","0");
        }
            
        if (matriz[count].Split(',').Length == 4)
        {
            matriz[count] = $",{matriz[count]}";
        }
        else if (matriz[count].Split(',').Length == 2)
        {
            matriz[count] = $"{matriz[count]},,,";
        }
        else if (matriz[count].Split(',').Length == 3)
        {
            matriz[count]=$"{matriz[count]},,";
        }
        
        count++;
    }
    string[,] matrix = new string[count,5];

    for (int i =0; i < count; i++)
    {
        string[] valores = matriz[i].Split(',');
        for (int j =0; j < 5; j++)
        {
            matrix[i,j]= valores[j];
        }
    }
int cont =0;
    for (int i = 0;i<count;i++)
{
    for (int j = 0; j<5;j++)
    {
        matrix[i,j]=matrix[i,j].Trim().Replace("D","E");
        cont++;
    }
}

    return matrix;
}

void coordenadasSatelite(string[] p_grafico,string[,] p_matrix,int p_noSatellites,string[] p_document,int p_linesOff, int p_matrixSatellites,string p_id)
{
    // Constantes:
    double axisEllipse = 6378137;
    double flattenFactor = 1/298.257222101;
    double angularVelocity = 7292115.0E-11;
    double gravitacionalConstant = 3986004.418E8;
    double speedLight = 2.99792458E8;

    Console.WriteLine($"\nConstantes Universales para cálculo de coordenadas de satélites (GNSS: Galileo y gps):\nSemieje mayor de elípse terrestre :{axisEllipse}\nFlatten factor: {flattenFactor}\nVelocidad angular de la orbita terrestre: {angularVelocity}\nConstante gravitacional: {gravitacionalConstant}\nVelocidad de la luz: {speedLight}\n");
    //Matrices de datos principales de los datos referidos 
    // a cada satelite
    // variable \t símbolo \t coordenada matricial
    string[] identificador = new string[p_noSatellites];
    string[] fechaSatellite = new string[p_noSatellites];
    string[] horaSatellite = new string[p_noSatellites]; 

    double[] tiemporeferencia = new double[p_noSatellites];                   //toe       3,1
    double[] excentricidad = new double[p_noSatellites];                      // e        2,2
    double[] raizSemiejemayor = new double[p_noSatellites];                   // sqrt(a)  2,4
    double[] anomaliaOrbital = new double[p_noSatellites];                    // Mo       1,4 
    double[] perigeoOrbital = new double[p_noSatellites];                     // w        4,3 
    double[] anguloInclinacion = new double[p_noSatellites];                  // io       4,1 
    double[] longitudNodo = new double[p_noSatellites];                       // ohm0     3,3 
    double[] diferenciaMovimiento = new double[p_noSatellites];               // delta n  1,3
    double[] tasaVariacioninclinacion = new double[p_noSatellites];           // i~       5,1
    double[] tasaVariacionlongitud = new double[p_noSatellites];              // ohm~     4,4
    double[] correccionLatitudc = new double[p_noSatellites];                 // Cuc      2,1
    double[] correccionLatituds = new double[p_noSatellites];                 // Cus      2,3
    double[] radioOrbitalc = new double[p_noSatellites];                      // Crc      4,2
    double[] radioOrbitals = new double[p_noSatellites];                      // Crs      1,2
    double[] inclinacionc = new double[p_noSatellites];                       // Cic      3,2
    double[] inclinacions = new double[p_noSatellites];                       // Cis      3,4
    
    double[] offset = new double[p_noSatellites];                             // a0       0,2
    double[] drift = new double[p_noSatellites];                              // a1       0,3  
    double[] driftRate = new double[p_noSatellites];                          // a2       0,4

    int count = 0;
    int n= p_document.Length-p_linesOff;

    for (int i = 0; i < n; i=i+p_matrixSatellites)
    {
        
        identificador[count] = p_matrix[i,1].Substring(0,3).Trim().Replace(" ","0");
        
        //fechaSatellite[count] = p_matrix[i,1].Substring(4,14).Replace(" ","/");
        //horaSatellite[count] = p_matrix[i,1].Substring(15,22).Replace(" ",":");
        
        offset[count] = double.Parse(p_matrix[i,2]);
        drift[count] = double.Parse(p_matrix[i,3]);
        driftRate[count] = double.Parse(p_matrix[i,4]);
   
        radioOrbitals[count] = double.Parse(p_matrix[i+1,2]);
        diferenciaMovimiento[count] = double.Parse(p_matrix[i+1,3]);
        anomaliaOrbital[count] = double.Parse(p_matrix[i+1,4]);
        correccionLatitudc[count] = double.Parse(p_matrix[i+2,1]);
        excentricidad[count] = double.Parse(p_matrix[i+2,2]); 
        correccionLatituds[count] = double.Parse(p_matrix[i+2,3]);
        raizSemiejemayor[count] = double.Parse(p_matrix[i+2,4]);
        tiemporeferencia[count] = double.Parse(p_matrix[i+3,1]); 
        inclinacionc[count] = double.Parse(p_matrix[i+3,2]);
        longitudNodo[count] = double.Parse(p_matrix[i+3,3]);
        inclinacions[count] = double.Parse(p_matrix[i+3,4]);
        anguloInclinacion[count] = double.Parse(p_matrix[i+4,1]); 
        radioOrbitalc[count] = double.Parse(p_matrix[i+4,2]);
        perigeoOrbital[count] = double.Parse(p_matrix[i+4,3]);
        tasaVariacionlongitud[count] = double.Parse(p_matrix[i+4,4]);
        
        count++;
    }

    string graficoRuta="./scripts/graficar.py";
    if (File.Exists(graficoRuta))
    {
        File.Delete(graficoRuta);
    }
    File.AppendAllText(graficoRuta,"import matplotlib.pyplot as plt\nimport numpy as np\nfrom mpl_toolkits.mplot3d import Axes3D\n");
    string[] variables = new string[count];
    string[] labelLine = new string[count];
    string[] texts = new string[count];
    Console.WriteLine("ID Satelite\tFrecuencia de Muestreo de datos\n");
    for (int i = 0; i < p_grafico.Length-1; i++)
    {
        int contadorID = 1;
        for(int j = 0; j < count; j++)
        {
            if (p_grafico[i] == identificador[j])
            {
                contadorID++;
            }
            variables[i]=$"x{i}={i+1}\ny{i}={contadorID}";
            labelLine[i]=$"ax.scatter(x{i},y{i},color='blue',s=50,alpha=0.7)";
            texts[i]=$"ax.annotate(\"{p_grafico[i]}\", xy=(x{i}, y{i}), xytext=({i+1}, {contadorID+0.5}),fontsize=10,ha='left',va='bottom')";
        }
        
        File.AppendAllText($"{p_id}constelación{DateTime.Now.ToString("ddMMyyyy")}.gnss",$"{p_grafico[i]}\t{contadorID}\n");
        Console.WriteLine($"{p_grafico[i]}\t{contadorID}");
    }
    for(int i = 0; i < p_grafico.Length-1; i++)
    {
        File.AppendAllText(graficoRuta,$"{variables[i]} \n");
    }
    File.AppendAllText(graficoRuta,"fig, ax = plt.subplots(figsize=(15, 10)) \n");
    for(int i = 0; i < p_grafico.Length-1; i++)
    {
        File.AppendAllText(graficoRuta,$"{labelLine[i]}\n");
    }

    for(int i = 0; i < p_grafico.Length-1; i++)
    {
        File.AppendAllText(graficoRuta,$"{texts[i]}\n");
    }

    File.AppendAllText(graficoRuta,$"plt.title(\"Frecuencia de Muestreo de Constelación Satelital\") \nplt.xlabel(\"satélite\") \nplt.ylabel(\"frecuencia\") \nplt.grid(True) \nplt.savefig(\"{p_id}constelación{DateTime.Now.ToString("ddMMyyyy")}.png\",dpi=300) \n");

    Process processo = Process.Start("python3", $"{graficoRuta}");
    processo.WaitForExit();

    if (File.Exists(graficoRuta))
    {
        File.Delete(graficoRuta);

        if (File.Exists($"{p_id}constelación{DateTime.Now.ToString("ddMMyyyy")}.png")){
            Console.WriteLine("\nSe a añadido gráfico de frecuencia de constelaciones");
        }

    }

}

void printEgnos(string p_document, int _impresoraDefault)
{
    try
    {
    string impresora = "";
    if (_impresoraDefault == 1)
    {
        impresora= "[id impresora]";
    }
    else
    {
        Console.WriteLine("Identificador de impresora");
        impresora = Console.ReadLine();
    }
    string programbat = $"PRINT \"{impresora}\" \"{p_document}\""; // codigo de impresion para archivo .bat
    exeProgram(programbat);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.WriteLine($"Máquina no encontrada {ex.Message}");
        Console.ReadLine();
    }
}

void alertaLife(string p_alerta, int p_num)
{
    string[] egnosAlerts = new string[p_num];


    for (int i =0;i<egnosAlerts.Length;i++)
    {    
        if (p_alerta == egnosAlerts[i])
        {
            string ruta = $"./Data{egnosAlerts[i]}.md";
            string contenidoTexto = "[Tabla de datos calculados necesarios para respuesta inmediata]";
     
            File.AppendAllText(ruta,contenidoTexto);
            Console.WriteLine($"Alerta encontrada, datos almacenados en /Data{egnosAlerts[i]}.md\n\n imprimiendo documento...");
            printEgnos(ruta,1);
        }
    }
}

// Acceso a bases de datos en linea de archivos RINEX de datos GNSS por medio de applicaciones de servidores remotos

void servidoressftp()
{
    string homeDrive = Environment.GetEnvironmentVariable("HOMEDRIVE");
    string ruta = $@"{homeDrive}\Windows";  
    string programbat = "@echo off\ncd /scripts/sftp\fileZilla.exe";
    string programpy = "import subprocess\njar_path = \"./scripts/sftp/FileZilla3/bin/filezilla\"\nproceso = subprocess.Popen([jar_path])\nproceso.wait()";
    if (File.Exists(ruta))
    {
        exeProgram(programbat);
    }
    else
    {
        pyProgram(programpy);
    }
}

void listaServidores()
{
	int n = 3;
    string[,] station = new string[n,5];
    // host, puerto, usuario, pasword
    station[0,0]="geodesia2.inegi.org.mx";
    station[0,1]="22";
    station[0,2]="rgnasftp";
    station[0,3]="rgnasftp";
    station[0,4]="https://www.inegi.org.mx/app/geo2/rgna/";

	station[1,0]="cddis.gsfc.nasa.gov/gnss/data/daily";
	station[1,1]="-";
	station[1,2]="-";
	station[1,3]="-";
	station[1,4]="https://cddis.nasa.gov/archive/";


	station[2,0]="https://www.esa.int/publications/about-us/publications/esa-tm-23-gnss-data-processing";
	station[2,1]="-";
	station[2,2]="-";
	station[2,3]="-";
	station[2,4]="https://gssc.esa.int/navipedia/GNSS_Book/ESA_GNSS-Book_TM-23_Vol_I.pdf";

    Console.WriteLine("Host\tPuerto\tuser\tpassword\tPagina Web");

    for(int i = 0; i < n ; i++)
    {
        for(int j = 0; j < 5; j++)
        {
            Console.Write($"{station[i,j]}\t");
        }
        Console.Write("\n");
    }
    Console.Write("\n\n========================================================\n");
}
