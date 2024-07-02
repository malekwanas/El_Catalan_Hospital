namespace El_Catalan_Hospital.BLL.DTO
{
    public class WorkingScheduleDTO
    {
        public int Id { get; set; }
        public string Working_Schedule_Start_Time { get; set; }
        public string Working_Schedule_End_Time { get; set; }
        public DayOfWeek Working_Schedule_Day { get; set; }  //Day ONLY (enum)
        public int Doctor_ID { get; set; }
    }
}
