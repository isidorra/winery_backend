﻿namespace winery_backend.Activity.Dto
{
    public class HarvestingDto
    {
        public int parcelId {  get; set; }
        public DateTime startDate { get; set; }
        public long amount { get; set; }

        public HarvestingDto(int parcelId, DateTime startDate, long amount)
        {
            this.parcelId = parcelId;
            this.startDate = startDate;
            this.amount = amount;
        }
    }
}
