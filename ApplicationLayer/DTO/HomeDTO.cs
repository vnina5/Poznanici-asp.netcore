namespace ApplicationLayer.DTO
{
    public class HomeDTO
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }
        public int HomeTypeId { get; set; }
        public string HomeTypeName { get; set; }

    }
}
