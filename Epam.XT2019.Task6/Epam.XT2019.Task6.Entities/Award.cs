using System;
using System.Collections.Generic;

namespace Epam.XT2019.Task6.Entities
{
    [Serializable]
    public class Award
    {
        public List<User> userIds;
        public Award()
        {
            userIds = new List<User>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
