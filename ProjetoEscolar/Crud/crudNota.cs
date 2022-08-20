using MySql.Data.MySqlClient;
using ProjetoEscolar.Banco;
using ProjetoEscolar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ProjetoEscolar.Crud
{
    public class crudNota
    {
        conexao con = new conexao();
        public void insert(modelNota cm)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbNotas (codProf,codAluno,codDisciplina,Nota) values (@codProf,@codAluno,@codDisciplina,@Nota);", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@codProf", MySqlDbType.VarChar).Value = cm.codProf;
            cmd.Parameters.Add("@codAluno", MySqlDbType.VarChar).Value = cm.codAluno;
            cmd.Parameters.Add("@codDisciplina", MySqlDbType.VarChar).Value = cm.codDisciplina;
            cmd.Parameters.Add("@Nota", MySqlDbType.VarChar).Value = cm.Nota;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void update(modelNota cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbNotas set codProf=@codProf, codAluno=@codAluno,codDisciplina=@codDisciplina,Nota=@Nota where codNotas=@codNotas;", con.MyConectarBD());
            // @: PARAMETRO
            cmd.Parameters.Add("@codNotas", MySqlDbType.VarChar).Value = cm.codNota;
            cmd.Parameters.Add("@codProf", MySqlDbType.VarChar).Value = cm.codProf;
            cmd.Parameters.Add("@codAluno", MySqlDbType.VarChar).Value = cm.codAluno;
            cmd.Parameters.Add("@codDisciplina", MySqlDbType.VarChar).Value = cm.codDisciplina;
            cmd.Parameters.Add("@Nota", MySqlDbType.VarChar).Value = cm.Nota;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public DataTable read()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tbProfessor.nomeProf,tbAluno.nomeAluno,tbDisciplina.Disciplina,tbNotas.Nota FROM tbNotas INNER JOIN tbProfessor ON tbProfessor.codProf = tbNotas.codProf INNER JOIN tbAluno ON tbAluno.codAluno = tbNotas.codAluno INNER JOIN tbDisciplina on tbDisciplina.codDisciplina = tbNotas.codDisciplina; ",con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable Nota = new DataTable();
            da.Fill(Nota);
            con.MyDesConectarBD();
            return Nota;
        }

        public DataTable readO(modelNota cm)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tbProfessor.nomeProf,tbAluno.nomeAluno,tbDisciplina.Disciplina,tbNotas.Nota FROM tbNotas INNER JOIN tbProfessor ON tbProfessor.codProf = tbNotas.codProf INNER JOIN tbAluno ON tbAluno.codAluno = tbNotas.codAluno INNER JOIN tbDisciplina on tbDisciplina.codDisciplina = tbNotas.codDisciplina and tbAluno.codAluno=@codAluno; ", con.MyConectarBD());
            cmd.Parameters.Add("@codAluno", MySqlDbType.VarChar).Value = cm.codAluno;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable Nota = new DataTable();
            da.Fill(Nota);
            con.MyDesConectarBD();
            return Nota;
        }
    }
}