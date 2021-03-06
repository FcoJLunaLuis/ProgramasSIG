﻿using System;
Escuela e = null;

inicializa(ref e);
    
        void inicializa(ref Escuela e)
        {
            e = new Escuela(){Nombre ="Universidad Patotp SA de CV", Encargado = "Ing. Juan Perez", Domicilio= "Av. De la Juventud 348"};
            e.Profesores.Add(new Profesor() {Nombre="Jose Diaz", FechaIng= DateTime.Parse("1/1/2018"), Materia= "Fisica", Salario= "1200"});
            e.Profesores.Add(new Profesor() {Nombre="Maria Perez", FechaIng= DateTime.Parse("10/2/2016"), Materia= "Algebra", Salario= "3400"});
            e.Profesores.Add(new Profesor() {Nombre="Claudia Sid", FechaIng= DateTime.Parse("1/4/2019"), Materia= "Calculo", Salario= "3800"});
            e.Profesores.Add(new Profesor() {Nombre="Carlos Lopez", FechaIng= DateTime.Parse("10/3/2016"), Materia= "Quimica", Salario= "1000"});

            e.Profesores[0].Grupos.Add(new Grupo() {Id = "1A"});
            e.Profesores[1].Grupos.Add(new Grupo() {Id = "2A"});
            e.Profesores[2].Grupos.Add(new Grupo() {Id = "4B"});
            e.Profesores[3].Grupos.Add(new Grupo() {Id = "8A"});
            
            
            e.Profesores[0].Grupos[0].Alumnos.Add(new Alumno(){Nombre = "Fatima Soto", Edad = 23,
             FechaIng = DateTime.Parse("1/1/2019"), Becado= "Si"});
            e.Profesores[0].Grupos[0].Alumnos.Add(new Alumno(){Nombre = "Damian Diaz", Edad = 25,
             FechaIng = DateTime.Parse("1/1/2016"), Becado= "No"});
            e.Profesores[0].Grupos[0].Alumnos.Add(new Alumno(){Nombre = "Fatima Soto", Edad = 23,
             FechaIng = DateTime.Parse(" 1/1/2018"), Becado= "Si"});
             
            e.Profesores[0].Grupos[0].Alumnos[0].Calificaciones.Add(7);
            e.Profesores[0].Grupos[0].Alumnos[0].Calificaciones.Add(7);
            e.Profesores[0].Grupos[0].Alumnos[0].Calificaciones.Add(7);
            
            e.Profesores[0].Grupos[0].Alumnos[1].Calificaciones.Add(8);
            e.Profesores[0].Grupos[0].Alumnos[1].Calificaciones.Add(8);
            e.Profesores[0].Grupos[0].Alumnos[1].Calificaciones.Add(8);
            
            e.Profesores[0].Grupos[0].Alumnos[2].Calificaciones.Add(6);
            e.Profesores[0].Grupos[0].Alumnos[2].Calificaciones.Add(6);
            e.Profesores[0].Grupos[0].Alumnos[2].Calificaciones.Add(6);

            e.Profesores[1].Grupos[0].Alumnos.Add(new Alumno(){Nombre = "Maria Ochoa", Edad = 20,
             FechaIng = DateTime.Parse("1/10/2018"), Becado= "Si"});
            e.Profesores[1].Grupos[0].Alumnos.Add(new Alumno(){Nombre = "Carlos Diaz", Edad = 23,
             FechaIng = DateTime.Parse("1/10/2018"), Becado= "No"});

            e.Profesores[1].Grupos[0].Alumnos[0].Calificaciones.Add(9);
            e.Profesores[1].Grupos[0].Alumnos[0].Calificaciones.Add(9);
            e.Profesores[1].Grupos[0].Alumnos[0].Calificaciones.Add(9);
            
            e.Profesores[1].Grupos[0].Alumnos[1].Calificaciones.Add(8);
            e.Profesores[1].Grupos[0].Alumnos[1].Calificaciones.Add(8);
            e.Profesores[1].Grupos[0].Alumnos[1].Calificaciones.Add(8);

            e.Profesores[3].Grupos[0].Alumnos.Add(new Alumno(){Nombre = " Jose Ochoa", Edad = 19,
             FechaIng = DateTime.Parse("1/10/2016"), Becado= "No"});
            e.Profesores[3].Grupos[0].Alumnos[0].Calificaciones.Add(7);
            e.Profesores[3].Grupos[0].Alumnos[0].Calificaciones.Add(7);
            e.Profesores[3].Grupos[0].Alumnos[0].Calificaciones.Add(7);



            reporte(e);
        }

        void reporte(Escuela e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine(">> Datos generales de los profesores:");
            e.Profesores.ForEach(n => Console.WriteLine(n.ToString()));
            Console.WriteLine(">> Alumnos por profesor:");
            foreach(Profesor p in e.Profesores){
                Console.WriteLine($"> {p.Nombre},\tGrupo: {p.Grupos[0].Id}");
                if(p.Grupos.Count >= 0){
                    p.Grupos[0].Alumnos.ForEach(n => Console.WriteLine(n.ToString()));
                }
                Console.WriteLine(p.Grupos[0].ToString());
            }
        }
    
