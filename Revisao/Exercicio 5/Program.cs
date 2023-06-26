using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Questão_5
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string ra { get; set; }
    }

    public class Program
    {
        static async Task Main()
        {
            string url = "http://localhost:3000/alunos";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Fazendo o parsing da resposta JSON
                    List<Aluno> alunos = JsonConvert.DeserializeObject<List<Aluno>>(responseBody);

                    // Exibindo os dados dos alunos
                    foreach (Aluno aluno in alunos)
                    {
                        Console.WriteLine($"ID: {aluno.id}");
                        Console.WriteLine($"Nome: {aluno.nome}");
                        Console.WriteLine($"Idade: {aluno.idade}");
                        Console.WriteLine($"RA: {aluno.ra}");
                        Console.WriteLine("--------");
                    }

                    Console.Write("Digite o nome do aluno que será adicionado: ");
                    string nome = Console.ReadLine();

                    Console.Write("Digite a idade do aluno: ");
                    int idade = int.Parse(Console.ReadLine());

                    Console.Write("Digite o RA do aluno: ");
                    string ra = Console.ReadLine();

                    // Obtendo o maior ID da lista atual de alunos
                    int maiorId = alunos.Count > 0 ? alunos.Max(a => a.id) : 0;

                    // Criando o novo aluno com ID incrementado
                    Aluno novoAluno = new Aluno
                    {
                        id = maiorId + 1,
                        nome = nome,
                        idade = idade,
                        ra = ra
                    };

                    // Convertendo o objeto em JSON
                    string alunoJson = JsonConvert.SerializeObject(novoAluno);

                    // Criando a requisição POST
                    var content = new StringContent(alunoJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage postResponse = await client.PostAsync(url, content);
                    postResponse.EnsureSuccessStatusCode();

                    // Obtendo a lista atualizada de alunos
                    response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();

                    // Fazendo o parsing da resposta JSON atualizada
                    alunos = JsonConvert.DeserializeObject<List<Aluno>>(responseBody);

                    // Exibindo os dados dos alunos atualizados
                    Console.Clear();
                    Console.WriteLine("   xxx   Lista de Alunos Atualizada   xxx   ");
                    foreach (Aluno aluno in alunos)
                    {
                        Console.WriteLine($"ID: {aluno.id}");
                        Console.WriteLine($"Nome: {aluno.nome}");
                        Console.WriteLine($"Idade: {aluno.idade}");
                        Console.WriteLine($"RA: {aluno.ra}");
                        Console.WriteLine("--------");
                    }

                    Console.WriteLine("Novo aluno inserido com sucesso!");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                }
            }

            Console.ReadLine();
        }
    }
}





