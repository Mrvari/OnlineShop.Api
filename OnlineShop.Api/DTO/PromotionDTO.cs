﻿namespace OnlineShop.Api.DTO
{
    public class PromotionDTO
    {
        public int PromotionID { get; set; }
        public int Cuponcode { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
