using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Basic {
    class Authen {
        private static string _user, _name, _position;
        private static int _id;
        public void setUser(string users) {
            _user = users;
        }
        public static string getUser() {
            return _user;
        }
        public void setName(string name) {
            _name = name;
        }
        public static string getName() {
            return _name;
        }
        public void setPosition(string position) {
            _position = position;
        }
        public static string getPosition() {
            return _position;
        }
        public void setId(int id) {
            _id = id;
        }
        public static int getId() {
            return _id;
        }
    }
}
