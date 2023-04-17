using StandartMTConversionTool;

class Program
{
    static void Main(string[] args)
    {
        TextToText funcionesTexto = new TextToText();

        string nombreCarpetaEntrada = "Entrada";
        string nombreCarpetaSalida = "Salida";
        string nombreCarpetaSalidaOneLine = "OneLine";


        string rutaDirectorioBase = AppDomain.CurrentDomain.BaseDirectory;

        string rutaPadre = Directory.GetParent(rutaDirectorioBase).Parent.Parent.Parent.FullName;

        string rutaEntrada = Path.Combine(rutaPadre, nombreCarpetaEntrada);

        string rutaSalida = Path.Combine(rutaPadre, nombreCarpetaSalida);

        string rutaOneLine = Path.Combine(rutaPadre, nombreCarpetaSalidaOneLine);

        // Obtener todos los archivos de la carpeta
        string[] archivosEntrada = Directory.GetFiles(rutaEntrada);
        // Iterar sobre cada archivo en la carpeta

        funcionesTexto.createModifyDocuments(rutaEntrada, rutaOneLine, rutaSalida);




    }
}