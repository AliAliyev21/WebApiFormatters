using System.ComponentModel.DataAnnotations;

namespace WebApiDemo3_22_10.Dtos
{
    public class PlayerDto
    {
     
        public string? City { get; set; }
        [Required]
        public string? PlayerName { get; set; }
        [Required]
        public int Score { get; set; }
    }
}


/*
 const obj={
    city:"Baku",
    playerName:"Elvin",
    score:100
}
 */