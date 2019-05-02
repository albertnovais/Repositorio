﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Rosnando_semG.Models;

namespace Rosnando_semG.Security
{
    public class ProvedorDeSeguranca : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var bd = new DB_A41AF6_rosnandoEntities();


            //captura o id da pessoa e converte para inteiro
            var idPessoa = Convert.ToInt32(username);

            //busca no banco pela pessoa mencionada no username
            var usuario = bd.Usuario.FirstOrDefault(x => x.usuario_id == idPessoa);

            var acesso = bd.Acesso.FirstOrDefault(x => x.acesso_id == usuario.acesso_id);
            //busca por todos os acessos salvos

            var acessosSalvos = acesso.acesso_desricao;

            string[] vs = new string[1];
            vs[0] = acessosSalvos;

            return vs;

            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}