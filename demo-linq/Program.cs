﻿using System;
using System.Linq;
using Entities;
using System.Collections.Generic;

namespace demo_linq
{
    class Program
    {


        private static List<Produto> Produtos;
        private static Categoria c1, c2, c3;


        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine(message);
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }


        private static void IniciarDados()
        {

            c1 = new Categoria() { Id = 1, Nome = "Tools", Camada = 2 };
            c2 = new Categoria() { Id = 2, Nome = "Computers", Camada = 1 };
            c3 = new Categoria() { Id = 3, Nome = "Electronics", Camada = 1 };

            Program.Produtos = new List<Produto>() {
                new Produto() { Id = 1, Nome = "Computer", Preco = 1100.0, Categoria = c2 },
                new Produto() { Id = 2, Nome = "Hammer", Preco = 90.0, Categoria = c1 },
                new Produto() { Id = 3, Nome = "TV", Preco = 1700.0, Categoria = c3 },
                new Produto() { Id = 4, Nome = "Notebook", Preco = 1300.0, Categoria = c2 },
                new Produto() { Id = 5, Nome = "Saw", Preco = 80.0, Categoria = c1 },
                new Produto() { Id = 6, Nome = "Tablet", Preco = 700.0, Categoria = c2 },
                new Produto() { Id = 7, Nome = "Camera", Preco = 700.0, Categoria = c3 },
                new Produto() { Id = 8, Nome = "Printer", Preco = 350.0, Categoria = c3 },
                new Produto() { Id = 9, Nome = "MacBook", Preco = 1800.0, Categoria = c2 },
                new Produto() { Id = 10, Nome = "Sound Bar", Preco = 700.0, Categoria = c3 },
                new Produto() { Id = 11, Nome = "Level", Preco = 70.0, Categoria = c1 }
            };

        }

        static void Main(string[] args)
        {
            IniciarDados();

            var r1 = Produtos.Where(p => p.Categoria.Camada == 1 && p.Preco < 900.0);
            Print("CAMADA 1 AND PREÇO < 900:", r1);

            var r2 = Produtos.Where(p => p.Categoria.Nome == "Tools").Select(p => p.Nome);
            Print("NOMES DOS PRODUTOS DA CATEGORIA 'TOOLS'", r2);

            var r3 = Produtos.Where(p => p.Nome[0] == 'C').Select(p => new { p.Nome, p.Preco, NomeCategoria = p.Categoria.Nome });
            Print("NOMES INICIADOS COM 'C' E UM OBJETO ANÔNIMO (ANONYMOUS OBJECT)", r3);

            var r4 = Produtos.Where(p => p.Categoria.Camada == 1).OrderBy(p => p.Preco).ThenBy(p => p.Nome);
            Print("CAMADA 1 ORDENADO POR PRECO E NOME", r4);

            var r5 = r4.Skip(2).Take(4);
            Print("CAMADA 1 ORDENADO POR PRECO E NOME PULA(SKIP) 2 PEGA(TAKE) 4", r5);

        }
    }
}
