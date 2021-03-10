using CloudEngineering.CodeOps.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CloudEngineering.CodeOps.Abstractions.Grid
{
    public class GridActorStatus : EntityEnumeration
    {
        public static GridActorStatus Initializing = new GridActorStatus(1, nameof(Initializing).ToLowerInvariant());
        public static GridActorStatus Created = new GridActorStatus(2, nameof(Created).ToLowerInvariant());
        public static GridActorStatus Terminated = new GridActorStatus(4, nameof(Terminated).ToLowerInvariant());

        protected GridActorStatus()
        {
        }

        public GridActorStatus(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<GridActorStatus> List() => new[] { Initializing, Created, Terminated };

        public static GridActorStatus FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new ArgumentException();
            }

            return state;
        }

        public static GridActorStatus From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new ArgumentException();
            }

            return state;
        }
    }
}
