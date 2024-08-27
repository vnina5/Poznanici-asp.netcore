namespace ApplicationLayer.Interfaces
{
    public interface IService<TDTO> where TDTO : class
    {
        public List<TDTO> GetAll();
        public TDTO GetById(int id);
        public TDTO Save(TDTO dto);
        public TDTO UpdateById(int id, TDTO dto);
        public void DeleteById(int id);
    }
}
