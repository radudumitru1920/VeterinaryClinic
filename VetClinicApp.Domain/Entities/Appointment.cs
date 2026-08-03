namespace VetClinicApp.Domain.Entities;
using VetClinicApp.Domain.Enums;
public class Appointment{
    public int appointmentID{get;set;}    
    public int clientID{get;set;}
    public string Nume{get;set;}=null!;
    public string Email{get;set;}=null!;
    public string NrTelefon{get;set;}=null!;
    public Client Client{get;set;}=null!;
    public DateTime Data{get;set;}
    public DateTime Ora{get;set;}
    public string Motiv{get;set;}=string.Empty;
    public AppointmentStatus Status{get;set;}
}