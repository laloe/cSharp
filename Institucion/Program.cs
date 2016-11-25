using Institucion.Misc;
using Institucion.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institucion
{
    class Program
    {
        public static void Main(string[] args)
        {
            var prefesores = new List<Profesor>();
            string[] lineas = File.ReadAllLines("./Files/Profesores.txt");
            int localId = 0; 
            foreach(var li in lineas)
            {
                prefesores.Add(new Profesor() { Nombre = li , Id = localId++});
            }

            foreach (var profe in prefesores)
            {
                Console.WriteLine(profe.Nombre + " " + profe.Id);
            }

            var archivo = File.Open("profesBinarios.bin", FileMode.OpenOrCreate);
            var binFile = new BinaryWriter(archivo);
            foreach (var profe in prefesores)
            {
                //var bytesNombre = Encoding.UTF8.GetBytes(profe.Nombre);
                //archivo.Write(bytesNombre, 0 , bytesNombre.Length);
                binFile.Write(profe.Nombre);
                binFile.Write(profe.Id);

            }
            binFile.Close();
            archivo.Close();

            Console.ReadLine();
        }

        private static void rutina6()
        {
            var profe = new Profesor() { Id = 1, Nombre = "michel", Apellido = "pereira", CodigoInterno = "SMART" };
            var transmisor = new TrasmisorDeDatos();

            transmisor.InformacionEnviada += transmisor_InformacionEnviada;
            transmisor.InformacionEnviada += (objs, eventarg) =>
            {
                Console.WriteLine("Se enviaron datos");
            };

            transmisor.FormatearYEnviar(profe, formatter, "LALO");

            transmisor.FormatearYEnviar(profe, ReverseFormatter, "LALO");
            transmisor.InformacionEnviada -= transmisor_InformacionEnviada;
            transmisor.FormatearYEnviar(profe, (s) => new string(s.Reverse().ToArray<char>()), "LALO");


            Console.ReadLine();
        }

        private static void transmisor_InformacionEnviada(object sender, EventArgs e)
        {
            Console.WriteLine("Transmisión de información");
        }
        private static string ReverseFormatter(string input)
        {
            return new string(input.Reverse().ToArray<char>());
        }
        private static string formatter(string input)
        {
            byte[] stringBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(stringBytes);
        }

        private static void rutina5()
        {
            List<Persona> listaPersonas = new List<Persona>();
            //ArrayList listaPersonas = new ArrayList();
            listaPersonas.Add(new Alumno("Juan", "Casteñeda") { NickName = "juanito" });
            listaPersonas.Add(new Alumno("Juan", "Casteñeda") { NickName = "petro" });
            listaPersonas.Add(new Profesor() { Nombre = "Maria", Apellido = "Rosales" });
            listaPersonas.Add(new Alumno("Pedro", "Rivas"));
            listaPersonas.Add(new Profesor() { Nombre = "Mag", Apellido = "Neto" });
            listaPersonas.Add(new Alumno("Ponciano", "Arriaga"));

            //for (int i = 0; i < listaPersonas.Count; i++)
            //{
            //    if (listaPersonas[i] is Alumno)
            //    {
            //        var al = (Alumno)listaPersonas[i];
            //        Console.WriteLine(al.NickName != null ? al.NickName : "Sin NickName");
            //    }
            //    else
            //    {
            //        var per = listaPersonas[i] as Persona; 

            //        if (per != null)
            //            Console.WriteLine(per.NombreCompleto);
            //    }
            //}

            foreach (var obj in listaPersonas)
            {
                if (obj is Alumno)
                {
                    var al = (Alumno)obj;
                    Console.WriteLine(al.NickName != null ? al.NickName : "Sin NickName");
                }
                else
                {
                    var per = obj as Persona;

                    if (per != null)
                        Console.WriteLine(per.NombreCompleto);
                }
            }

            Console.ReadLine();
        }

        private static void rutina4()
        {
            Persona[] arregloPersona = new Persona[5];
            arregloPersona[0] = new Alumno("Juan", "Casteñeda") { NickName = "juanito" };
            arregloPersona[1] = new Profesor() { Nombre = "Maria", Apellido = "Rosales" };
            arregloPersona[2] = new Alumno("Pedro", "Rivas");
            arregloPersona[3] = new Profesor() { Nombre = "Mag", Apellido = "Neto" };
            arregloPersona[4] = new Alumno("Ponciano", "Arriaga");

            for (int i = 0; i < arregloPersona.Length; i++)
            {
                if (arregloPersona[i] is Alumno)
                {
                    var al = (Alumno)arregloPersona[i];
                    Console.WriteLine(al.NickName != null ? al.NickName : "Sin NickName");
                }
                else
                {
                    Console.WriteLine(arregloPersona[i].NombreCompleto);
                }
            }
            Console.ReadLine();
            //arregloPersona[5] = new Profesor() { Nombre = "Juan", Apellido = "Es" };
        }

        private static void rutina3()
        {
            var alumno = new Alumno("", "");
            var profesor = new Profesor();
            Console.ReadLine();
        }

        private static void rutina2()
        {
            //-32.000 +32.000
            short s = 32000;
            int i = 33000;
            float f = 2.35f;

            Console.WriteLine(i);
            s = (short)i;
            Console.WriteLine(s);
            i = (int)f;
            Console.WriteLine(f);
            Console.WriteLine(i);
        }
        
        public static void rutina1()
        {
            Persona[] lista = new Persona[3];
            lista[0] = new Alumno("Eduardo", "González")
            {
                Id = 1,
                Edad = 26,
                Email = "laloe.90@gmail.com",
                NickName = "lalo"
            };
            lista[1] = new Profesor()
            {
                Id = 2,
                Nombre = "Julio",
                Apellido = "Acevedo",
                Edad = 36,
                Catedra = "Programación"
            };
            lista[2] = new Profesor()
            {
                Id = 3,
                Nombre = "Roberto",
                Apellido = "Sanchez",
                Edad = 36,
                Catedra = "Programación"
            };

            Console.WriteLine(Persona.ContadorPersonas);
            foreach (Persona p in lista)
            {
                Console.WriteLine("Tipo: " + p.GetType());
                Console.WriteLine(p.ConstruirResumen());
            }

            Console.WriteLine("S T R U C T");
            CursoStruct c = new CursoStruct(70);
            c.Curso = "101-B";

            var newC = new CursoStruct();
            newC.Curso = "54-C";

            var cursoF = c;
            cursoF.Curso = "356-A";

            Console.WriteLine("Curso c = " + c.Curso);
            Console.WriteLine("Curso F = " + cursoF.Curso);
            Console.WriteLine("Curso new = " + newC.Curso);

            Console.WriteLine("C L A S E S");
            CursoClass c_class = new CursoClass(70);
            c_class.Curso = "101-B";

            var newC_class = new CursoClass(50);
            newC_class.Curso = "54-C";

            var cursoF_class = c_class;
            cursoF_class.Curso = "356-A";

            Console.WriteLine("Curso c = " + c_class.Curso);
            Console.WriteLine("Curso F = " + cursoF_class.Curso);
            Console.WriteLine("Curso new = " + newC_class.Curso);

            Console.WriteLine("E N U M E R A C I O N E S");
            var alumnoEst = new Alumno("Eduardo", "González")
            {
                Id = 4,
                Edad = 26,
                Email = "laloe.90@gmail.com",
                NickName = "lalo",
                Estado = EstadosAlumnos.Egresado
            };
            Console.WriteLine("Estado del alumno: " + alumnoEst.Estado);
            Console.WriteLine("Tipo: " + typeof(Alumno));
            Console.WriteLine(alumnoEst.GetType());
            Console.WriteLine("Tamaño: " + sizeof(int));
            Console.Read();
        }
    }
}
