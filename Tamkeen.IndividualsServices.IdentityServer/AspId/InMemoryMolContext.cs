using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tamkeen.IndividualServices.IdentityServer.AspId.Entities;

namespace Tamkeen.IndividualServices.IdentityServer.AspId
{
    public class InMemoryMolContext
    {
        private static List<MolUser> _usersList { get; set; }


        public static List<MolUser> Users { get { return _usersList; } }

        static InMemoryMolContext()
        {
            _usersList = new List<MolUser>();
        }
        public static bool Add(MolUser user)
        {
            _usersList.Add(user);
            return true;
        }

        public static bool Update(MolUser user)
        {
            var found = _usersList.Exists(usr => usr.Id == user.Id);

            if (found)
            {
                _usersList.Remove(_usersList.Find(usr => usr.Id == user.Id));
                _usersList.Add(user);
                return true;
            }
            return false;

        }


        public static bool Delete(MolUser user)
        {
            var found = _usersList.Exists(usr => usr.Id == user.Id);

            if (found)
            {
                _usersList.Remove(_usersList.Find(usr => usr.Id == user.Id));
                return true;
            }
            return false;
        }
    }
}