namespace VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;
public class Client{

    public int clientID{get;set;}
    public string Nume{get;set;}=string.Empty;
    public string Prenume{get;set;}=string.Empty;
    public ICollection<Pet> Pets {get;set;} =new List<Pet>();
    public ICollection<Appointment> Appointments {get;set;}= new List<Appointment>();
    public string NrTelefon{get;set;}=string.Empty;
    public string Email{get;set;}=string.Empty;

}