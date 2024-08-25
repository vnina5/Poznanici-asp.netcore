namespace ApplicationLayer.DTO
{
    public class AddressDTO
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }
        public int CityId { get; set; }
        public int HomeTypeId { get; set; }
        public string HomeTypeName { get; set; }

    }
}
