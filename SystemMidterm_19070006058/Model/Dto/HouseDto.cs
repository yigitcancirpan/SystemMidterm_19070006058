﻿namespace SystemMidterm_19070006058.Model.Dto
{
    public class HouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxCustomerCount { get; set; }
        public string City { get; set; }
        public bool IsAvailable { get; set; }

    }
    public class HouseResultDto : APIResultDto
    {
        public int Id { get; set; }

    }
}
