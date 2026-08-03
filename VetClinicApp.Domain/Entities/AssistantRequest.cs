namespace VetClinicApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using VetClinicApp.Domain.Enums;
public class AssistantRequest{
    public int requestID{get;set;}
    public int staffID{get;set;}
    public Staff Staff{get;set;}=null!;
    [Required(ErrorMessage= "Data obligatorie")]
    public DateTime Data{get;set;}
    [Required(ErrorMessage = "Ora obligatorie")]
    public DateTime Ora{get;set;}
    public string Motiv{get;set;}=string.Empty;
    public RequestStatus Status{get;set;}
}