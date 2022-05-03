using TechHealth.Model;

namespace TechHealth.Repository
{
    public class SpecializationRepository : GenericRepository<int, Specialization>
    {
        private static readonly SpecializationRepository instance = new SpecializationRepository();

        static SpecializationRepository()
        {
        }

        private SpecializationRepository()
        {
        }

        public static SpecializationRepository Instance => instance;
        protected override string GetPath()
        {
            return @"../../Json/specialization.json";
        }

        protected override int GetKey(Specialization entity)
        {
            return entity.IdSpecialization;
        }

        protected override void RemoveAllReference(int key)
        {
            throw new System.NotImplementedException();
        }

        protected override void ShouldSerialize(Specialization entity)
        {
            throw new System.NotImplementedException();
        }
    }
}