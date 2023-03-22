using System.Collections.Generic;

Dictionary<string, int> Recaudaciones_Cursos = new Dictionary<string, int>();
string curso= " ", max_curso= " ";
int opcion=-1, total_un_curso=0, max=0, cont_cursos = 0, total_cursos= 0;
double promedio = 0;


while(opcion != 0)
{
    opcion= Menu();
switch (opcion)
{
    case 1:
        total_un_curso= IngresarImporte_Curso(ref curso);
        Recaudaciones_Cursos.Add(curso, total_un_curso);
    break;

    case 2:
        MayorPlataRecaudada_Curso( ref max, ref max_curso, ref total_cursos);
        Console.WriteLine($"el curso que puso más plata fue {max_curso} con un total de {max}");
        PromedioEntreCursos(ref promedio, ref cont_cursos);
        Console.WriteLine($"El promedio de plata recaudada es {promedio}");
        Console.WriteLine($"Se regaló en total: {total_cursos}");
        Console.WriteLine($"Participan del regalo {cont_cursos} cursos");
    break;
}
}
int IngresarImporte_Curso(ref string curso)
{
    int regalo= 0, total = 0;
    curso= IngresarString("¿Curso?"); 
    int cant_estudiantes = IngresarEntero("Ingrese la cantidad de estudiantes:");
    for(int i=0; i<cant_estudiantes; i++)
    {
     Console.Write("Regalo: ");
     total += regalo=int.Parse(Console.ReadLine());
    }
    return total;
}
void MayorPlataRecaudada_Curso(ref int max, ref string max_curso, ref int total)
{
    int recaudacion_un_curso = 0;
    foreach (string curso in Recaudaciones_Cursos.Keys)
    {
        recaudacion_un_curso = Recaudaciones_Cursos[curso];
        if(max < recaudacion_un_curso)
        {
            max = recaudacion_un_curso;
            max_curso = curso;
        }
        total+=recaudacion_un_curso;
    }
}
void PromedioEntreCursos(ref double promedio, ref int cursos)
{
    int total = 0;
    foreach(int plata in Recaudaciones_Cursos.Values)
    {
        total += plata;
        cursos++;
    }
    promedio = total/cursos;
}
int Menu()
{
    do 
    {
        Console.WriteLine(" ");
        Console.WriteLine("1. Ingresar importes de un curso");
        Console.WriteLine("2. Ver estadísticas");
        opcion = IngresarEntero("Ingrese la opción que desee ejecutar");
    }
    while(opcion<0 || opcion>2);
    return opcion;
}
string IngresarString(string msj)
{
    Console.WriteLine(msj);
    return Console.ReadLine();
}
int IngresarEntero(string msj)
{
    Console.WriteLine(msj);
    int num= int.Parse(Console.ReadLine());
    while(num<0)
    {
        Console.WriteLine("el número debe ser mayor a cero");
        num= int.Parse(Console.ReadLine());
    }
    return num;
}



