namespace StandartMTConversionTool
{
    public class TextToText
    {

        public void createModifyDocuments(string rutaEntrada, string rutaOne, string rutaSalida)
        {
            string[] archivosEntrada = Directory.GetFiles(rutaEntrada);
            List<string> lineasMod = new List<string>();

            // Iterar sobre cada archivo en la carpeta
            foreach (string archivo in archivosEntrada)
            {
                string miContenido = "";
                string nombreArchivoOne = "";
                string contenidoFinal = "";
                string RutaOneLineFinal = "";
                string contenidoOneLine = "";
                string contenidoOneLineFinal = "";

                string nombreArchivoEntrada = Path.GetFileNameWithoutExtension(archivo);

                // Leer el contenido del archivo original
                string contenidoArchivoOriginal = File.ReadAllText(archivo);

                //Proceso de Conversion del MT al formato especificado

                miContenido = ",," + nombreArchivoEntrada;
                miContenido.PadRight(66);
                string instrucciones = ",,                COMO SE ARMA EL MT POR FFS                     \r\n,,SE DEBEN ELIMINAR LAS COMAS QUE FIGURAN AL PRINCIPIO DE CADA   \r\n,,CAMPO DESTINADO A LA GENERACION DE LOS TAGS EJEMPLO:           \r\n,,:SRI: O :20: Y COMPLETAR EN LA MISMA LINEA LUEGO DE LOS DOS    \r\n,,PUNTOS CON LA INFORMACION NECESARIA RESPETANDO EL FORMATO DE   \r\n,,CADA TAG SEGUN LO INDICA SWIFT. EJEMPLO :20:BKTD-I002137000    \r\n,,SI DEBEN ESCRIBIR MAS DE UNA LINEA, ESCIBIR DEBAJO DEL TAG     \r\n,,CORRESPONDIENTE, UNA LINEA DEBAJO DE LA OTRA RESPETANDO LA     \r\n,,CANTIDAD DE CARACTERES DEL TAG Y NO DEBE EMPEZAR CON COMAS     \r\n,,EN EL CAMPO :SRI: DEBE IR LA DIRECCION BIC DEL BANCO DE        \r\n,,DESTINATARIO DEL MENSAJE.                                      ";

                string ContenidoArchivoNuevo = "";
                ContenidoArchivoNuevo += miContenido;
                ContenidoArchivoNuevo += "\n";
                ContenidoArchivoNuevo += instrucciones;
                ContenidoArchivoNuevo += "\n,,:SRI: BIC RECEIVER BANK (11X)                                  \r\n,:SRI:                                                           ";
                string ContenidoModificado = modificarContenido(contenidoArchivoOriginal, ContenidoArchivoNuevo);

                //verificacion de formato

                contenidoFinal = verifyFormatContent(ContenidoModificado);


                //Crear la ruta del archivo nuevo
                string nombreArchivoNuevo = Path.GetFileNameWithoutExtension(archivo) + "_Modify.txt";
                string rutaArchivoNuevo = Path.Combine(rutaSalida, nombreArchivoNuevo);

                //Escribir el contenido modificado en el archivo nuevo
                File.WriteAllText(rutaArchivoNuevo, contenidoFinal);

                //Crear la ruta del archivo nuevo
                nombreArchivoOne = Path.GetFileNameWithoutExtension(archivo) + "_OneLine.txt";
                RutaOneLineFinal = Path.Combine(rutaOne, nombreArchivoOne);

                string[] lines = File.ReadAllLines(rutaArchivoNuevo);
                contenidoOneLineFinal = string.Join("", lines).Replace("\r\n", "");
                File.WriteAllText(RutaOneLineFinal, contenidoOneLineFinal);
            }

        }

        public string modificarContenido(string contenidoArchivoOriginal, string ContenidoArchivoNuevo)
        {
            string[] lineas = contenidoArchivoOriginal.Split('\n');
            string[] partes;
            List<string> lineaDebajoNueva = new List<string>();
            List<string> lineasMod = new List<string>();

            foreach (string line in lineas)
            {
                if (!String.IsNullOrWhiteSpace(line))
                {
                    partes = line.Split('\t');
                    string status = partes[0];
                    string tag = $"TAG{partes[1]}";
                    string fieldName = partes[2];
                    string contentOptions = $"({partes[3]})";
                    string numero = partes[4];


                    //example
                    //,,:TAG20:	DOCUMENTARY CREDIT NUMBER (M) (16X)
                    //,:20: 

                    string nuevaLinea = "\n" + ",,"; // P
                                                     // refijo para la nueva línea
                    nuevaLinea += $":TAG{partes[1]}:";// Campo de etiqueta (e.g. TAG32B:)
                    nuevaLinea += " ";
                    nuevaLinea += $"{partes[2]}({partes[0]})({partes[3]})";

                    string lineaDebajo = $"\n,:{partes[1]}:";

                    ContenidoArchivoNuevo += nuevaLinea;
                    ContenidoArchivoNuevo += lineaDebajo;
                }
                else
                {
                    continue;
                }
            }
            return ContenidoArchivoNuevo;
        }

        public string verifyFormatContent(string ContenidoArchivoNuevo)
        {
            string contNuevo = "";
            List<string> lineasNuevas = new List<string>();
            string contFinal = "";
            string[] lineas = ContenidoArchivoNuevo.Split('\n');
            List<string> lineasList = lineas.ToList();
            int contador = 0;

            foreach (string line in lineasList)
            {

                if (line.Length > 65)
                {
                    lineasNuevas.AddRange(filtradoEspacios(line.PadRight(66)));

                }
                else
                {
                    lineasNuevas.Add(line.PadRight(65));
                }
            };
            foreach (var item in lineasNuevas)
            {
                string line = "";
                if (contador != 0)
                {
                    contador++;
                    line = "\n" + item;
                    contFinal += line.PadRight(66);
                }
                else
                {
                    contador++;
                    line = item;
                    contFinal += line.PadRight(65);
                }
            }
            return contFinal;

        }

        public List<string> filtradoEspacios(string line)
        {
            List<string> lineasNuevas = new List<string>();
            int len = line.Length;

            string nuevaLiena = "";

            nuevaLiena += line.Substring(0, 65);

            lineasNuevas.Add(nuevaLiena);


            //sobrante
            string sobrante = ",," + line.Substring(66);

            if (!String.IsNullOrWhiteSpace(sobrante) && sobrante.Trim() != ",,")
            {
                lineasNuevas.Add(sobrante.PadRight(65));
                int num = lineasNuevas.Count();

            }

            return lineasNuevas;
        }
    }
}
