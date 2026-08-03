namespace VetClinicApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using VetClinicApp.Domain.Enums;
public class Pet{
    public int petID{get;set;}
    public int clientID{get;set;}
    public Client Client{get;set;}=null!;
    public string Nume{get;set;}=string.Empty;
    public AnimalType Tip{get;set;}
    [Required(ErrorMessage = "Varsta obligatorie")]
    public int Varsta{get;set;}
    [Required(ErrorMessage = "Greutate obligatorie")]
    public int Greutate{get;set;}
}