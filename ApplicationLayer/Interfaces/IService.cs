namespace ApplicationLayer.Interfaces
{
    public interface IService<TDTO> where TDTO : class
    {
        public List<TDTO> GetAll();
        public TDTO GetById(long id);
        public TDTO Save(TDTO dto);
        public TDTO UpdateById(long id, TDTO dto);
        public void DeleteById(long id);
    }
}
