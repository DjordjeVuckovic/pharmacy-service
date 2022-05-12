using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechHealth.Model;

namespace TechHealth.Repository
{
    public class SubstanceRepository : GenericRepository<string, Substance>
    {
        private static readonly SubstanceRepository instance = new SubstanceRepository();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static SubstanceRepository()
        {
        }

        private SubstanceRepository()
        {
        }

        public static SubstanceRepository Instance => instance;
        protected override string GetKey(Substance entity)
        {
            return entity.SubstanceId;
        }

        protected override string GetPath()
        {
            return @"../../Json/substance.json";
        }

        protected override void RemoveAllReference(string key)
        {
            throw new NotImplementedException();
        }

        protected override void ShouldSerialize(Substance entity)
        {
            throw new NotImplementedException();
        }
    }
}
