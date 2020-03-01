using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Switch.Domain.Entities;
using Switch.Infra.CrossCutting.Logging;
using Switch.Infra.Data.Context;
using SwitchAPP.Reports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SwitchAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario = new Usuario()
            {
                Nome = "Maurício",
                SobreNome = "Almeron",
                Senha = "teste",
                Email = "malmeron@hotmail.com",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Entities.Enums.SexoEnum.Masculino,
                UrlFoto = @"c:\temp"
            };
            var usuario2 = new Usuario()
            {
                Nome = "Maurício",
                SobreNome = "Almeron",
                Senha = "teste",
                Email = "malmeron@hotmail.com",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Entities.Enums.SexoEnum.Masculino,
                UrlFoto = @"c:\temp"
            };
            var usuario3 = new Usuario()
            {
                Nome = "Ana",
                SobreNome = "XXX",
                Senha = "teste",
                Email = "malmeron@hotmail.com",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Entities.Enums.SexoEnum.Masculino,
                UrlFoto = @"c:\temp"
            };
            var usuario4 = new Usuario()
            {
                Nome = "Maurício",
                SobreNome = "Almeron",
                Senha = "teste",
                Email = "malmeron@hotmail.com",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Entities.Enums.SexoEnum.Masculino,
                UrlFoto = @"c:\temp"
            };
            //Console.WriteLine("Hello World!");
            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql("Server=localhost;userid=root;password=mauroalme3;database=SwitchDB;", m => m.MigrationsAssembly("Switch.Infra.Data"));
            List<Usuario> usuarios = new List<Usuario>() { usuario, usuario2, usuario3, usuario4 };
            try
            {
                using (var dbContext = new SwitchContext(optionsBuilder.Options))
                {
                    //dbContext.GetService<ILoggerFactory>().AddProvider(new Logger());
                    
                    //PARA ADICIONAR UMA LISTA DE USUARIOS - COMANDOS EM BACH
                    //dbContext.AddRange(usuario, usuario2, usuario3, usuario4);
                    //OU
                    //dbContext.AddRange(usuarios);
                    //PARA ADICIONAR SOMENTE UM USUARIO
                    //dbContext.Usuarios.Add(usuario3);
                    //dbContext.SaveChanges();
                    var resultado = dbContext.Usuarios.ToList();

                    var resultado1 = dbContext.Usuarios.Where(u => u.Nome == "Ana").ToList().FirstOrDefault();
                    //var resultado1 = dbContext.Usuarios.Where(u => u.Id == 1).ToList().FirstOrDefault();

                    //InstituicaoEnsino instituicao = new InstituicaoEnsino()
                    //{
                    //    Nome = "Centro Universitário Franciscano",
                    //    AnoFormacao = new DateTime(2016, 7, 22)
                    //};
                    //dbContext.InstituicoesEnsino.Add(instituicao);
                    //resultado1.InstituicoesEnsino.Add(instituicao);

                    //A diferença do SingleOrDefault() é que se tiver duplicado ele retorna um erro
                    //var resultado1 = dbContext.Usuarios.Where(u => u.Nome == "Ana1").ToList().SingleOrDefault();

                    //DELETA USUÁRIO
                    //dbContext.Usuarios.Remove(resultado1);
                    //OU
                    //dbContext.Remove<Usuario>(resultado1);
                    //dbContext.SaveChanges();

                    //ATUALIZANDO USUÁRIO
                    //resultado1.Email = "anaNovo@Novo.com.br"; //ATUALIZA SOMENTE A PROPRIEDADE SE NÃO USAR O UPDATE ABAIXO
                    //OU
                    //SE FOR USADO O UPDATE ABAIXO ELE ATUALIZA TODOS AS PROPRIEDADES (OPCIONAL)
                    //dbContext.Update<Usuario>(resultado1);
                    //dbContext.SaveChanges();

                    //DELETAR 
                    

                    var user = dbContext.Usuarios.FirstOrDefault(u => u.Nome == "Mauricio");
                    //user.InstituicoesEnsino.Add(new InstituicaoEnsino { Nome = "Unisinos" });
                    //user.InstituicoesEnsino.Add(new InstituicaoEnsino { Nome = "UFRGS" });
                    //dbContext.SaveChanges();

                    //var instituicaoRemover = dbContext.InstituicoesEnsino.FirstOrDefault(i => i.Nome == "");
                    //dbContext.InstituicoesEnsino.Remove(instituicaoRemover);
                    //dbContext.SaveChanges();

                    //var inst = user.InstituicoesEnsino.FirstOrDefault(i => i.Nome == "Unisinos");
                    //inst.Nome = "Universidade do Vale do Rio dos Sinos";

                    //var inst1 = user.InstituicoesEnsino.FirstOrDefault(i => i.Nome == "UFRGS");
                    //inst1.Nome = "Universidade Federal do Rio Grande do Sul";
                    //dbContext.SaveChanges();

                    //PROJEÇÃO DE QUERY
                    //var sql = "select Nome, SobreNome from Usuarios";
                    //FAZENDO USO DE STORE PROCEDURE
                    var sql = "call sp_OBTER_NOME_SOBRENOME_TODOSUSUARIOS";

                    
                    var connection = dbContext.Database.GetDbConnection();
                    var listaUsuarios = new List<UsuariosDTO>();


                    using(var command = connection.CreateCommand())
                    {
                        connection.Open();
                        command.CommandText = sql;
                        using(var dataReader = command.ExecuteReader())
                        {
                            if(dataReader.HasRows)
                            {
                                while(dataReader.Read())
                                {
                                    var usuarioDTO = new UsuariosDTO()
                                    {
                                        Nome = dataReader["Nome"].ToString(),
                                        SobreNome = dataReader["SobreNome"].ToString()
                                    };
                                    listaUsuarios.Add(usuarioDTO);
                                }
                            }

                        }
                        //STORE PROCEDURE COM PARÂMETRO
                        /*command.CommandText = "call sp_OBTER_USUARIO_POR_ID(@usuarioId)";
                        MySqlParameter param = new MySqlParameter("usuarioId", MySqlDbType.Int32);
                        command.Parameters.Add(param);
                        param.Value =
                        1;
                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    var usuarioDTO = new UsuariosDTO()
                                    {
                                        Nome = dataReader["Nome"].ToString(),
                                        SobreNome = dataReader["SobreNome"].ToString()
                                    };
                                    listaUsuarios.Add(usuarioDTO);
                                }
                            }

                        }*/
                        var listaUsuariosInsEnsino = new List<UsuariosInstEnsinoDTO>();
                        command.CommandText = "call sp_OBTER_USERS_POR_INST_ENSINO";
                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    var usuarioInstEnsinoDTO = new UsuariosInstEnsinoDTO()
                                    {
                                        NomeUsuario = dataReader["NomeUsuario"].ToString(),
                                        SobreNomeUsuario = dataReader["SobreNomeUsuario"].ToString(),
                                        NomeInstEnsino = dataReader["NomeInstEnsino"].ToString()
                                    };
                                    listaUsuariosInsEnsino.Add(usuarioInstEnsinoDTO);
                                }
                            }

                        }

                    }

                    /*using (var command = connection.CreateCommand())
                    {
                        connection.Open();
                        command.CommandText = "call sp_OBTER_USUARIO_POR_ID(@usuarioId)";
                        MySqlParameter param = new MySqlParameter("usuarioId", MySqlDbType.Int32);
                        command.Parameters.Add(param);
                        param.Value = 1;
                        using (var dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    var usuarioDTO = new UsuariosDTO()
                                    {
                                        Nome = dataReader["Nome"].ToString(),
                                        SobreNome = dataReader["SobreNome"].ToString()
                                    };
                                    listaUsuarios.Add(usuarioDTO);
                                }
                            }

                        }
                    }*/

                    foreach (Usuario r in resultado)
                    {
                        Console.WriteLine(r.Nome);
                        Console.WriteLine(r.Email);
                        Console.WriteLine(r.InstituicoesEnsino.Count);
                    }

                    Console.WriteLine($"Foram encontrados {resultado.Count()} registros.");

                    if (resultado1 == null)
                    {
                        Console.WriteLine("Nenhum usuário foi encontrado.");
                    }
                    else
                    {
                        Console.WriteLine(resultado1.Nome);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
